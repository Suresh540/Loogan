using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Calendar
{
    public class IndexModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public List<CourseCalendarModel>? CourseCalendars { get; set; }

        public IndexModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        public async Task OnGetAsync()
        {
            var specificId = GetSpecificId();
            var apiRequest = new ApiRequest() { RequestValue = specificId?.ToString() };
            CourseCalendars = await _utilityHelper.ExecuteAPICall<List<CourseCalendarModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Calendar/GetStudentCourseCalendar");
        }

        public int? GetSpecificId()
        {
            if (HttpContext != null && HttpContext.Session != null && HttpContext?.Session?.GetInt32("StudentId") != null && HttpContext.Session.GetInt32("StudentId") != 0)
            {
                return HttpContext?.Session?.GetInt32("StudentId");
            }

            if (HttpContext != null && HttpContext.Session != null && HttpContext?.Session?.GetInt32("TeacherId") != null && HttpContext.Session.GetInt32("TeacherId") != 0)
            {
                return HttpContext?.Session?.GetInt32("TeacherId");
            }

            return default(int?);
        }
    }
}
