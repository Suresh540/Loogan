using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Loogan.Web.UI.Controllers
{
    [Route("Admin")]
    [LooganStudentAuthorize("Admin")]
    public class AdminController : Controller
    {
        private const string wwwroot = "wwwroot";
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

        #region Course

        [Route("GetAllCourses")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllCourses(PagingModel pageModel)
        {
            var courses = await _utilityHelper.ExecuteAPICall<List<CourseModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllCourses");
            var pageList = courses?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateCourse")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateCourse(CourseModel course)
        {
            course.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            course.CreatedDate = DateTime.Now;
            var courseModel = await _utilityHelper.ExecuteAPICall<bool>(course, RestSharp.Method.Post, resource: "api/Admin/CreateCourse");
            return Json(new { value = "Success" });
        }

        [Route("UpdateCourse")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> UpdateCourse(CourseModel course)
        {
            course.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            course.ModifyDate = DateTime.Now;
            var courseModel = await _utilityHelper.ExecuteAPICall<bool>(course, RestSharp.Method.Post, resource: "api/Admin/UpdateCourse");
            return Json(new { value = "Success" });
        }

        [Route("DeleteCourse")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteCourse(string courseId)
        {
            var apiRequest = new ApiRequest() { RequestValue = courseId };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteCourse");
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

        #region Institution

        [HttpPost]
        [Route("GetInstitutionsList")]
        public async Task<IActionResult> GetInstitutionsList()
        {
            var institutionlist = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetInstitutionsList");
            return Json(institutionlist);
        }

        [Route("GetAllInstitutions")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllInstitutions(PagingModel pageModel, string? userId)
        {
            var apiRequest = new ApiRequest() { RequestValue = userId };
            var institutions = await _utilityHelper.ExecuteAPICall<List<InstitutionModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutions");
            var pageList = institutions?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateInstitution")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateInstitution()
        {
            InstitutionModelExtended? instituationViewModel = null;
            if (!StringValues.IsNullOrEmpty(Request.Form["model"]))
            {
                var model = Request?.Form?["model"];
                instituationViewModel = JsonConvert.DeserializeObject<InstitutionModelExtended>(model);
                await UploadImage(Request?.Form.Files?[0]);
                if (instituationViewModel != null)
                {
                    instituationViewModel.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
                    instituationViewModel.CreatedDate = DateTime.Now;
                    await _utilityHelper.ExecuteAPICall<bool>(instituationViewModel, RestSharp.Method.Post, resource: "api/Admin/CreateInstitution");
                    return Json(new { value = "Success" });
                }
            }
            return Json(new { value = "Failure" });
        }

        private async Task UploadImage(IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), wwwroot, "institutionimages", fileName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), wwwroot, "institutionimages");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            }
        }

        [Route("UpdateInstitution")]
        [LooganAdminAuthorize("Admin")]
        public async Task<IActionResult> UpdateInstitution(InstitutionModel instituationViewModel)
        {
            instituationViewModel.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            instituationViewModel.ModifyDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(instituationViewModel, RestSharp.Method.Post, resource: "api/Admin/UpdateInstitution");
            return Json(new { value = "Success" });
        }

        [Route("DeleteInstitution")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteInstitution(int institutionId)
        {
            var apiRequest = new ApiRequest() { RequestValue = Convert.ToString(institutionId) };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteInstitution");
            return Json(new { value = "Success" });
        }
        #endregion

        #region InstitutionNews

        [Route("GetAllInstitutionNews")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllInstitutionNews(PagingModel pageModel,string? userId)
        {
            var apiRequest = new ApiRequest() { RequestValue = userId };
            var institutionNewss = await _utilityHelper.ExecuteAPICall<List<InstitutionNewsModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionNews");
            var pageList = institutionNewss?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateInstitutionNews")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateInstitutionNews(InstitutionNewsModel institutionNewsModelObj)
        {
            institutionNewsModelObj.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            institutionNewsModelObj.CreatedDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(institutionNewsModelObj, RestSharp.Method.Post, resource: "api/Admin/CreateInstitutionNews");
            return Json(new { value = "Success" });
        }

        [Route("UpdateInstitutionNews")]
        [LooganAdminAuthorize("Admin")]
        public async Task<IActionResult> UpdateInstitutionNews(InstitutionNewsModel institutionNewsModelObj)
        {
            institutionNewsModelObj.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            institutionNewsModelObj.ModifyDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(institutionNewsModelObj, RestSharp.Method.Post, resource: "api/Admin/UpdateInstitutionNews");
            return Json(new { value = "Success" });
        }

        [Route("DeleteInstitutionNews")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteInstitutionNews(int institutionNewsId)
        {
            var apiRequest = new ApiRequest() { RequestValue = Convert.ToString(institutionNewsId) };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteInstitutionNews");
            return Json(new { value = "Success" });
        }
        #endregion

        #region InstitutionAnnouncement

        [Route("GetAllInstitutionAnnouncement")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllInstitutionAnnouncement(PagingModel pageModel, string? userId)
        {
            var apiRequest = new ApiRequest() { RequestValue = userId };
            var institutions = await _utilityHelper.ExecuteAPICall<List<InstitutionAnnouncementModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionAnnouncement");
            var pageList = institutions?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateInstitutionAnnouncement")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateInstitutionAnnouncement(InstitutionAnnouncementModel instituationAnnouncementViewModel)
        {
            instituationAnnouncementViewModel.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            instituationAnnouncementViewModel.CreatedDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(instituationAnnouncementViewModel, RestSharp.Method.Post, resource: "api/Admin/CreateInstitutionAnnouncement");
            return Json(new { value = "Success" });
        }

        [Route("UpdateInstitutionAnnouncement")]
        [LooganAdminAuthorize("Admin")]
        public async Task<IActionResult> UpdateInstitutionAnnouncement(InstitutionAnnouncementModel instituationAnnouncementViewModel)
        {
            instituationAnnouncementViewModel.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            instituationAnnouncementViewModel.ModifyDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(instituationAnnouncementViewModel, RestSharp.Method.Post, resource: "api/Admin/UpdateInstitutionAnnouncement");
            return Json(new { value = "Success" });
        }

        [Route("DeleteInstitutionAnnouncement")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteInstitutionAnnouncement(int institutionId)
        {
            var apiRequest = new ApiRequest() { RequestValue = Convert.ToString(institutionId) };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/DeleteInstitutionAnnouncement");
            return Json(new { value = "Success" });
        }
        #endregion

        #region Grades

        [Route("GetAllMasterGrades")]
        public async Task<JsonResult> GetAllMasterGrades(int languageId)
        {
            var apiRequest = new ApiRequest() { RequestValue = Convert.ToString(languageId) };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllMasterGrades");
            return Json(userRoles);
        }

        [Route("GetStudentGradesByStaffId")]
        public async Task<JsonResult> GetStudentGradesByStaffId(int staffId)
        {
            var apiRequest = new ApiRequest() { RequestValue = Convert.ToString(staffId) };
            var userRoles = await _utilityHelper.ExecuteAPICall<List<MenuModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetStudentGradesByStaffId");
            return Json(userRoles);
        }
        #endregion




    }
}
