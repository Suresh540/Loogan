using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Pages.Shared
{
    public class RightSidePopupModel : PageModel
    {
        public UserModel UserProfileModel { get; set; }

        public RightSidePopupModel()
        {
            
        }

        public void OnGet()
        {
        }
    }
}
