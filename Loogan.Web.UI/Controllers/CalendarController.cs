using Loogan.API.Models.Models.Admin;
using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [Route("Calendar")]
    public class CalendarController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;

        public CalendarController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [Route("GetStudentCourseCalendar")]
        public async Task<JsonResult> GetStudentCourseCalendar(int studentId)
        {
            var apiRequest = new ApiRequest() { RequestValue = studentId.ToString() };
            var studentCourseCalendarModel = await _utilityHelper.ExecuteAPICall<List<CourseCalendarModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Calendar/GetStudentCourseCalendar");
            return Json(studentCourseCalendarModel);
        }

        [Route("GetStaffCourseCalendar")]
        public async Task<JsonResult> GetStaffCourseCalendar(int staffId)
        {
            var apiRequest = new ApiRequest() { RequestValue = staffId.ToString() };
            var staffCourseCalendarModel = await _utilityHelper.ExecuteAPICall<List<CourseCalendarModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Calendar/GetStaffCourseCalendar");
            return Json(staffCourseCalendarModel);
        }
    }

}
