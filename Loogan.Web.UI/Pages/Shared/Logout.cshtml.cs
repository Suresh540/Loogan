using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Shared
{
    public class LogoutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
        }
    }
}
