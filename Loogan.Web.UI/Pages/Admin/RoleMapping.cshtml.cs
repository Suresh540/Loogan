using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Admin
{
    [LooganAdminAuthorize("Admin")]
    public class RoleMappingModel : PageModel
    {
        readonly IUtilityHelper _utilityHelper;

        public RoleMappingModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [BindProperty]
        public List<MenuModel>? MenuItems { get; set; }

        public async Task OnGetAsync()
        {
            var languageId = HttpContext?.Session.GetInt32("LanguageId") ?? 1;
            var apiRequest = new Request() { LanguageId = languageId };
            MenuItems = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetMenus");
        }
    }
}
