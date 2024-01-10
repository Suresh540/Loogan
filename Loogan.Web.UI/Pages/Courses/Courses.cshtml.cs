using Loogan.API.Models.Models;
using Loogan.Web.UI.Models;
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

            await FetchCourseData();
        }

        private async Task FetchCourseData()
        {
            var apiRequest = new ApiLookUpRequest() { LookupType = "CourseCategory", LanguageId = 1 };
            CourseDropdown = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/StudentCourse/GetCourseCategory");

            var request = new ApiRequest { RequestValue = HttpContext.Session.GetInt32("StudentId").ToString() };
            StudentCourseModels = await _utilityHelper.ExecuteAPICall<List<StudentCourseModel>>(request, RestSharp.Method.Post, resource: "api/StudentCourse/GetStudentCourseDetails");

            var courseType = TempData?["courseType"]?.ToString();
            var status = TempData?["status"]?.ToString();

            //Filter based on course type
            FilterDatabasedOnCourseType(courseType);

            //Filter based on status
            FilterDatabasedOnStatus(status);
        }
        private void FilterDatabasedOnCourseType(string? courseType)
        {
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

                CourseTypes = StudentCourseModels?.Where(x => x.CourseType == courseType).GroupBy(x => new { x.CourseType }).Select(x => new GroupCourseType
                {
                    CourseType = x.Key.CourseType,
                    StudentCourseModels = x.Where(y => y.CourseType == x.Key.CourseType).ToList()
                }).ToList();

                CurrentCourseType = courseType;
            }
        }

        private void FilterDatabasedOnStatus(string? status)
        {
            if (!string.IsNullOrWhiteSpace(status))
            {
                CourseTypes = CourseTypes?.Where(x => x.StudentCourseModels != null && x.StudentCourseModels.Any(y => y?.StudentCourseStatus?.ToUpper()?.Trim() == status.ToUpper().Trim()))
                    .Select(x => x).ToList();
            }
        }

    }
}
