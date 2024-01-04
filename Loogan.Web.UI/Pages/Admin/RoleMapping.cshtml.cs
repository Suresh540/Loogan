using Loogan.API.Models.Enums;
using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Request = Loogan.API.Models.Models.Request;

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

        [BindProperty]
        public List<MenuModel>? SelectedMenuItems { get; set; }

        public async Task OnGetAsync()
        {
            var languageId = HttpContext?.Session.GetInt32("LanguageId") ?? 1;
            var apiRequest = new Request() { LanguageId = languageId };
            MenuItems = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetMenus");

            RoleMenuRequest roleMenu = new RoleMenuRequest();
            roleMenu.RoleId = (int)UserTypeEnum.student;
            roleMenu.LanguageId = languageId;
            SelectedMenuItems = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(roleMenu, RestSharp.Method.Post, resource: "api/Admin/GetRoleMenus");

            //Menu items
            MenuItems = MenuItems.Where(x => !SelectedMenuItems.Any(y => y.MenuName == x.MenuName)).ToList();
        }

        
    }
}
