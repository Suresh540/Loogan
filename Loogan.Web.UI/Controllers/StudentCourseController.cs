using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [LooganStudentAuthorize("Student,Admin")]
    [Route("StudentCourse")]
    public class StudentCourseController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;

        public StudentCourseController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [Route("GetCourseCategory")]
        public async Task<JsonResult> GetCourseCategory(string lookUpType)
        {
            var apiRequest = new ApiLookUpRequest() { LookupType = lookUpType, LanguageId = 1 };
            var masterLookUpValues = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/StudentCourse/GetCourseCategory");
            return Json(masterLookUpValues);
        }


        [Route("GetStudentCourseDetails")]
        public async Task<JsonResult> GetStudentCourseDetails(int studentId)
        {
            var studentCourseList = await _utilityHelper.ExecuteAPICall<List<StudentCourseModel>>(null, RestSharp.Method.Post, resource: "api/StudentCourse/GetStudentCourseDetails");
            return Json(studentCourseList);
        }

        [HttpPost]
        [Route("CourseSelection")]
        public IActionResult CourseSelection()
        {
            TempData["courseType"] = Request.Form["courseType"].ToString();
            TempData["status"] = Request.Form["status"].ToString();
            return RedirectToPage("/Courses/courses");
        }

        #region StudentCourseMapping

        [Route("GetAllStudentCourseMapping")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllStudentCourseMapping(PagingModel pageModel)
        {
            var courses = await _utilityHelper.ExecuteAPICall<List<StudentCourseMappingModel>>(null, RestSharp.Method.Post, resource: "api/StudentCourse/GetAllStudentCourseMapping");
            var pageList = courses?.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("CreateStudentCourseMapping")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateStudentCourseMapping(StudentCourseMappingModel studentCourseMapping)
        {
            studentCourseMapping.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            studentCourseMapping.CreatedDate = DateTime.Now;
            var courseModel = await _utilityHelper.ExecuteAPICall<bool>(studentCourseMapping, RestSharp.Method.Post, resource: "api/StudentCourse/CreateCourse");
            return Json(new { value = "Success" });
        }

        [Route("UpdateStudentCourseMapping")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> UpdateStudentCourseMapping(StudentCourseMappingModel studentCourseMapping)
        {
            studentCourseMapping.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            studentCourseMapping.ModifyDate = DateTime.Now;
            var courseModel = await _utilityHelper.ExecuteAPICall<bool>(studentCourseMapping, RestSharp.Method.Post, resource: "api/StudentCourse/UpdateCourse");
            return Json(new { value = "Success" });
        }

        [Route("DeleteStudentCourseMapping")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteStudentCourseMapping(string courseId)
        {
            var apiRequest = new ApiRequest() { RequestValue = courseId };
            var IsDeleted = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/StudentCourse/DeleteCourse");
            return Json(new { value = "Success" });
        }

        #endregion
    }
}
