using Microsoft.AspNetCore.Mvc;

namespace GoldGym.Controllers
{
    public class ValidationController : Controller
    {
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
    }
}
