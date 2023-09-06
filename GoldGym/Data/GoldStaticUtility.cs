using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldGym.Data
{
    public static class GoldStaticUtility
    {
        public static List<SelectListItem> GetGenderList(string selectedvalue = "M")
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Male", Value = "M", Selected = "M" == selectedvalue.Trim() },
                new SelectListItem(){ Text = "Female", Value = "F", Selected = "F" == selectedvalue.Trim()  },
                new SelectListItem(){ Text = "Other", Value = "O", Selected = "O" == selectedvalue.Trim()  }
            };
        }

        public static List<SelectListItem> GetRoleList(string selectedvalue = "User")
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(){ Text = UserRole.Admin.ToString(), Value = UserRole.Admin.ToString(), Selected = UserRole.Admin.ToString() == selectedvalue.Trim() },
                new SelectListItem(){ Text = UserRole.User.ToString(), Value = UserRole.User.ToString(), Selected = UserRole.User.ToString() == selectedvalue.Trim()  },
            };
        }
    }

    public enum UserRole
    {
        MasterAdmin,
        Admin,
        User
    }
}
