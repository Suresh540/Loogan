using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Services;
using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly ICalendarService _calendarService;

        public CalendarController(ICommonService commonService, ICalendarService calendarService)
        {
            _commonService = commonService;
            _calendarService = calendarService;
        }

        [HttpPost]
        [Route("GetStudentCourseCalendar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentCourseCalendar(ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var courseCalendarDetails = await _calendarService.GetCourseCalendarDetails();
            var studentCalendarDetails = courseCalendarDetails.Where(x=>x.StudentId ==  studentId).ToList();
            return Ok(studentCalendarDetails);
        }

        [HttpPost]
        [Route("GetStaffCourseCalendar")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStaffCourseCalendar(ApiRequest request)
        {
            var staffId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var courseCalendarDetails = await _calendarService.GetCourseCalendarDetails();
            var staffCalendarDetails = courseCalendarDetails.Where(x => x.StaffId == staffId).ToList();
            return Ok(staffCalendarDetails);
        }
    }
}
