using Loogan.Web.UI.Resources.Pages;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Pages.Admin
{
    [LooganAdminAuthorize("Admin")]
    public class AdminDashboardModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
