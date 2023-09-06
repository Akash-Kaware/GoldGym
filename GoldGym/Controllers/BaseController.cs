using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldGym.Controllers
{
    public class BaseController : Controller
    {
        public Guid GetLoggedInUserId()
        {
            var UserDetails = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (Guid.TryParse(UserDetails.Value, out Guid userId))
            {
                return userId;
            }
            throw new InvalidOperationException();
        }
    }
}
