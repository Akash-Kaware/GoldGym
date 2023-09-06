namespace GoldGym.Controllers
{
    using GoldGym.Models;
    using GoldGym.Repository;
    using Microsoft.AspNetCore.Mvc;

    public class ValidationController : Controller
    {
        private readonly IUserRepository _userRepository;
        public ValidationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public JsonResult IsValidDateOfBirth(string dob)
        {
            var min = DateTime.Now.AddYears(-5);
            var max = DateTime.Now.AddYears(-110);
            var msg = string.Format("Please enter a value between {0:MM/dd/yyyy} and {1:MM/dd/yyyy}", max, min);
            try
            {
                var date = DateTime.Parse(dob);
                if (date > min || date < max)
                    return Json(msg);
                else
                    return Json(true);
            }
            catch (Exception)
            {
                return Json(msg);
            }
        }

        [HttpPost]
        public async Task<JsonResult> CheckDuplicateEmail(string email, Guid id)
        {
            var msg = string.Format("{0} already exists.", email);
            try
            {
                UserModel? user = await _userRepository.GetUserByEmail(email, id);
                if (user != null)
                    return Json(msg);
                else
                    return Json(true);
            }
            catch (Exception ex)
            {
                return Json(msg);
            }
        }
    }
}
