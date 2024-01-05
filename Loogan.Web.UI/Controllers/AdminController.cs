using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
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
            staff.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            staff.ModifyDate = DateTime.Now;
            var staffModel = await _utilityHelper.ExecuteAPICall<bool>(staff, RestSharp.Method.Post, resource: "api/Admin/UpdateStaff");
            return Json(new { value = "Success" });
        }

        [Route("DeleteStaff")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteStaff(string staffId)
        {
            var apiRequest = new ApiRequest() { RequestValue = staffId };
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

        [Route("UpdateStudent")]
        [LooganAdminAuthorize("Admin")]
        public async Task<IActionResult> UpdateStudent(StudentModel studentObj)
        {
            studentObj.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            studentObj.ModifyDate = DateTime.Now;
            var studentModel = await _utilityHelper.ExecuteAPICall<bool>(studentObj, RestSharp.Method.Post, resource: "api/Admin/UpdateStudent");
            return Json(new { value = "Success" });
        }

        [Route("DeleteStudent")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteStudent(string studentId)
        {
            var apiRequest = new ApiRequest() { RequestValue = studentId };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteStudent");
            return Json(new { value = "Success" });
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

        [Route("RoleChange")]
        [AllowAnonymous]
        public async Task<IActionResult> OnGetRoleChange([FromQuery] string selectedVal)
        {
            var languageId = HttpContext?.Session.GetInt32("LanguageId") ?? 1;
            var apiRequest = new Request() { LanguageId = languageId };
            var menuItems = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetMenus");

            RoleMenuRequest roleMenu = new RoleMenuRequest();
            roleMenu.RoleId = Convert.ToInt32(selectedVal);
            roleMenu.LanguageId = languageId;
            var selectedMenuItems = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(roleMenu, RestSharp.Method.Post, resource: "api/Admin/GetRoleMenus");

            //Menu items
            menuItems = menuItems.Where(x => !selectedMenuItems.Any(y => y.MenuName == x.MenuName)).ToList();

            return new JsonResult(new { actualmenus = menuItems, selectMenus = selectedMenuItems });
        }


    }
}
