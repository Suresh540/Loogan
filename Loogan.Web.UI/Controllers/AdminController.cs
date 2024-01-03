using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [Route("Admin")]
    [LooganStudentAuthorize("Admin")]
    public class AdminController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;
        public AdminController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        #region Staff

        [Route("GetAllStaff")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllStaff(PagingModel pageModel)
        {
            var staffs = await _utilityHelper.ExecuteAPICall<List<StaffModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllStaff");
            var pageList = staffs.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateStaff")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateStaff(StaffModel staff)
        {
            var staffModel = await _utilityHelper.ExecuteAPICall<bool>(staff, RestSharp.Method.Post, resource: "api/Admin/CreateStaff");
            return Json(new { value = "Success" });
        }

        [Route("UpdateStaff")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> UpdateStaff(StaffModel staff)
        {
            var staffModel = await _utilityHelper.ExecuteAPICall<bool>(staff, RestSharp.Method.Post, resource: "api/Admin/UpdateStaff");
            return Json(new { value = "Success" });
        }

        [Route("DeleteStaff")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteUser(string userid)
        {
            var apiRequest = new ApiRequest() { RequestValue = userid };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteStaff");
            return Json(new { value = "Success" });
        }
        #endregion

        #region Student
        [Route("GetAllStudents")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllStudents(PagingModel pageModel)
        {
            var students = await _utilityHelper.ExecuteAPICall<List<StudentModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllStudents");
            var pageList = students?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }
        #endregion

        [Route("GetUserRoles")]
        public async Task<JsonResult> GetUserRoles(int languageId)
        {
            var apiRequest = new Request() { LanguageId = languageId };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<UserTypeModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetUserRoles");
            return Json(userRoles);
        }

        [Route("GetMenus")]
        public async Task<JsonResult> GetMenus(int languageId)
        {
            var apiRequest = new Request() { LanguageId = languageId };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetMenus");
            return Json(userRoles);
        }

        [Route("GetRoleMenus")]
        public async Task<JsonResult> GetRoleMenus(RoleMenuRequest request)
        {
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(request, RestSharp.Method.Post, resource: "api/Admin/GetRoleMenus");
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
