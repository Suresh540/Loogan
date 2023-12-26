using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Courses
{
    public class CoursesModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public List<DropDownListModel>? CourseDropdown { get; set; }

        public List<StudentCourseModel>? StudentCourseModels { get; set; }

        [BindProperty]
        public IEnumerable<string?>? CourseTypes { get; set; }

        public CoursesModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        public async Task OnGetAsync()
        {
            var apiRequest = new ApiLookUpRequest() { LookupType = "CourseCategory", LanguageId = 1 };
            CourseDropdown = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/StudentCourse/GetCourseCategory");
            
            var request = new ApiRequest { RequestValue = "1" };
            StudentCourseModels = await _utilityHelper.ExecuteAPICall<List<StudentCourseModel>>(request, RestSharp.Method.Post, resource: "api/StudentCourse/GetStudentCourseDetails");
            CourseTypes = StudentCourseModels?.GroupBy(x => new { x.CourseType }).Select(x => x.Key.CourseType);
        }
    }
}
