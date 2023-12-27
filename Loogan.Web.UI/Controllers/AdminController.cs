using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [Route("User")]
    public class AdminController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;
        public AdminController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [Route("GetUserRoles")]
        public async Task<JsonResult> GetUserRoles()
        {
            var apiRequest = new Request() { LanguageId = 1 };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<UserTypeModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetUserRoles");
            return Json(userRoles);
        }

        [Route("GetMenus")]
        public async Task<JsonResult> GetMenus()
        {
            var apiRequest = new Request() { LanguageId = 1 };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetMenus");
            return Json(userRoles);
        }

        [Route("GetRoleMenus")]
        public async Task<JsonResult> GetRoleMenus(int roleId)
        {
            var apiRequest = new RoleMenuRequest() { RoleId = roleId, LanguageId = 1 };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetRoleMenus");
            return Json(userRoles);
        }

        [Route("SaveRoleMenus")]
        public async Task<JsonResult> SaveRoleMenus(List<SaveRoleMenuRequest> request)
        {
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(request, RestSharp.Method.Post, resource: "api/Admin/SaveRoleMenus");
            return Json(userRoles);
        }


    }
}
