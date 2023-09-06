namespace GoldGym.Controllers
{
    using GoldGym.Data;
    using GoldGym.Models;
    using GoldGym.Repository;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _userRepository.GetAllUsers();
            var genders = GoldStaticUtility.GetGenderList();
            foreach (var item in result)
            {
                item.Gender = genders.First(g => g.Value == item.Gender.Trim()).Text;
            }
            return View(result);
        }

        public ActionResult Create()
        {
            var model = new UserModel() { Id = Guid.NewGuid(), Role = UserRole.User, Gender = "M" };
            setUpViewBags(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = this.GetLoggedInUserId();
                    _userRepository.CreateUser(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        private void setUpViewBags(UserModel model)
        {
            ViewBag.Genders = GoldStaticUtility.GetGenderList(model.Gender);
            ViewBag.Roles = GoldStaticUtility.GetRoleList(model.Role.ToString());
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _userRepository.GetUserById(id);
            result.ConfirmPassword = result.Password;
            setUpViewBags(result);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy= this.GetLoggedInUserId();
                    await _userRepository.UpdateUser(model);
                    return RedirectToAction(nameof(Index));
                }
                setUpViewBags(model);
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _userRepository.DeleteUser(id, this.GetLoggedInUserId());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
