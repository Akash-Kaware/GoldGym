using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoldGym.Data
{
    public static class GoldStaticUtility
    {
        public static List<SelectListItem> GetGenderList(string selectedvalue = "M")
        {
            return new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Male", Value = "M", Selected = "M" == selectedvalue },
                new SelectListItem(){ Text = "Female", Value = "F", Selected = "F" == selectedvalue  },
                new SelectListItem(){ Text = "Other", Value = "O", Selected = "O" == selectedvalue  }
            };
        }
    }
}
