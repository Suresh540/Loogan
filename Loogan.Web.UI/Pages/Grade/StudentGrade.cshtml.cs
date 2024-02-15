using Azure.Core;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Grade
{
    public class StudentGradeModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public List<MasterGradeModel>? Grades { get; set; }

        [BindProperty]
        public List<StudentGradeMappingModel>? StudentGradeMappingModels { get; set; }

        public StudentGradeModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        public async Task OnGetAsync()
        {
            var languageId = HttpContext?.Session.GetInt32("LanguageId") ?? 1;
            var apiRequest = new ApiRequest() { RequestValue = languageId.ToString() };
            Grades = await _utilityHelper.ExecuteAPICall<List<MasterGradeModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllMasterGrades");
            var userTypeId = HttpContext?.Session?.GetInt32("TeacherId");
            apiRequest = new ApiRequest() { RequestValue = userTypeId.ToString() };
            StudentGradeMappingModels = await _utilityHelper.ExecuteAPICall<List<StudentGradeMappingModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetStudentGradesByStaffId");
        }

        
    }
}
