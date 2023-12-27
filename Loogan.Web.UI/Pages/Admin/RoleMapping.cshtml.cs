using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Admin
{
    [LooganAdminAuthorize("Admin")]
    public class RoleMappingModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
