using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [LooganStudentAuthorize("Student")]
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
    }
}
