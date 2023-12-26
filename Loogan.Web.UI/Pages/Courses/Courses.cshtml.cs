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
        public List<GroupCourseType>? CourseTypes { get; set; }

        [BindProperty]
        public string? SelectedCourseType { get; set; }

        [BindProperty]
        public string? CurrentCourseType { get; set; }

        public CoursesModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        public async Task OnGetAsync()
        {
            var courseType = TempData?["courseType"]?.ToString();
            await FetchCourseData(courseType);
        }

        private async Task FetchCourseData(string? courseType)
        {
            var apiRequest = new ApiLookUpRequest() { LookupType = "CourseCategory", LanguageId = 1 };
            CourseDropdown = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/StudentCourse/GetCourseCategory");

            var request = new ApiRequest { RequestValue = "1" };
            StudentCourseModels = await _utilityHelper.ExecuteAPICall<List<StudentCourseModel>>(request, RestSharp.Method.Post, resource: "api/StudentCourse/GetStudentCourseDetails");

            if (string.IsNullOrEmpty(courseType))
            {
                SelectedCourseType = CourseDropdown?[0].Name;
                CourseTypes = StudentCourseModels?.GroupBy(x => new { x.CourseType }).Select(x => new GroupCourseType
                {
                    CourseType = x.Key.CourseType,
                    StudentCourseModels = x.Where(y => y.CourseType == x.Key.CourseType).ToList()
                }).ToList();
            }
            else
            {
                int? index = CourseDropdown?.FindIndex(x => x.Name == courseType);
                var i = index.GetValueOrDefault() + 1;
                if (CourseDropdown != null && i < CourseDropdown.Count)
                {
                    SelectedCourseType = CourseDropdown[i].Name;
                }
                else
                {
                    SelectedCourseType = CourseDropdown?[0].Name;
                }

                CourseTypes = StudentCourseModels?.Where(x=>x.CourseType == courseType).GroupBy(x => new { x.CourseType }).Select(x => new GroupCourseType
                {
                    CourseType = x.Key.CourseType,
                    StudentCourseModels = x.Where(y => y.CourseType == x.Key.CourseType).ToList()
                }).ToList();

                CurrentCourseType = courseType;
            }
        }
    }

    public class GroupCourseType
    {
        public string? CourseType { get; set; }

        public List<StudentCourseModel>? StudentCourseModels { get; set; }
    }
}
