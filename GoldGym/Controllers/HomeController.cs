namespace GoldGym.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;

    using GoldGym.Models;
    using GoldGym.Repository;

    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Login(string ReturnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(ReturnUrl) || ReturnUrl.Equals("/"))
                {
                    return RedirectToAction("index", "payment");
                }
                return LocalRedirect(ReturnUrl);
            }
            LoginModel objLoginModel = new LoginModel();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                UserModel? user = await _userRepository.ValidateUserDetails(objLoginModel.UserName, objLoginModel.Password);
                if (user == null)
                {
                    //Add logic here to display some message to user    
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }
                else
                {
                    //A claim is a statement about a subject by an issuer and    
                    //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.Role, user.Role.ToString())
                    };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    {
                        IsPersistent = objLoginModel.RememberLogin
                    });
                    if (string.IsNullOrEmpty(objLoginModel.ReturnUrl) || objLoginModel.ReturnUrl.Equals("/"))
                    {
                        return RedirectToAction("index", "payment");
                    }
                    return LocalRedirect(objLoginModel.ReturnUrl);
                }
            }
            return View(objLoginModel);
        }

        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return LocalRedirect("/");
        }
    }
}