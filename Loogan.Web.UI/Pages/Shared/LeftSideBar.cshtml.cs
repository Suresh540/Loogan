using Loogan.Web.UI.Pages.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Pages.Shared
{
    public class LeftSideBarModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/");

        }
    }
}
