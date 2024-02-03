using Loogan.API.Database.Models;
using Loogan.API.Models.Enums;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [Route("Common")]
    public class CommonController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;

        public CommonController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [Route("GetMasterLookupValues")]
        public async Task<JsonResult> GetMasterLookupValues(string lookUpType)
        {
            var apiRequest = new ApiLookUpRequest() { LookupType = lookUpType, LanguageId = HttpContext?.Session?.GetInt32("LanguageId") ?? 1 };
            var masterLookUpValues = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetMasterLookupValues");
            return Json(masterLookUpValues);
        }

        [Route("Index/{route}")]
        public async Task<IActionResult> Index([FromRoute] string route = "")
        {
            if (IsValidContext())
            {
                var email = HttpContext?.User?.Identity?.Name;
                ForgotPswdModel request = new ForgotPswdModel()
                {
                    EmailId = email,
                    Password = "",
                    UserName = "",
                };
                var model = await _utilityHelper.ExecuteAPICall<UserModel>(request, RestSharp.Method.Post, resource: "api/User/UserByEmailAddress");
                if (model != null && HttpContext != null)
                {
                    HttpContext.Session.SetInt32("LoginUserId", model.UserId);
                    HttpContext.Session.SetInt32("LoginUserTypeId", model.UserTypeId);
                    Enum.TryParse(typeof(UserTypeEnum), model.UserTypeId.ToString(), out object? usertypeName);
                    AssignToUserTypeSession(usertypeName);
                    HttpContext.Session.SetString("UserName", model?.UserName ?? "");
                    HttpContext.Session.SetString("FullName", model?.FirstName + ' ' + model?.LastName);
                    return RedirectToUserPages(usertypeName);
                }
            }
            return RedirectToPage($"");
        }

        private void AssignToUserTypeSession(object? usertypeName)
        {
            if (usertypeName != null)
            {
                var utype = Convert.ToString(usertypeName);
                HttpContext.Session.SetString("LoginUserType", utype ?? "");
            }
        }

        private IActionResult RedirectToUserPages(object? usertypeName)
        {
            var utype = Convert.ToString(usertypeName);
            if (usertypeName != null && (utype ?? "").Equals(UserTypeEnum.student.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return LocalRedirect("/Courses/courses");
            }
            else
            {
                return LocalRedirect("/Admin/AdminDashboard");
            }
        }

        private bool IsValidContext()
        {
            return HttpContext != null && HttpContext?.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated;
        }

        [HttpPost]
        [Route("GetCountrys")]
        public async Task<IActionResult> GetCountrys()
        {
            var languageId = HttpContext?.Session?.GetInt32("LanguageId");

            var apiRequest = new ApiRequest() { RequestValue = languageId > 0 ? languageId.ToString() : "1" };
            var countryList = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetCountrys");
            return Json(countryList);
        }

        [HttpPost]
        [Route("GetStatesByCountryId")]
        public async Task<IActionResult> GetStatesByCountryId(int countryId)
        {
            var apiRequest = new RequestStateModel() { LanguageId = HttpContext?.Session?.GetInt32("LanguageId") ?? 1,CountryId = countryId };
            var countryList = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetStatesByCountryId");
            return Json(countryList);
        }

        [HttpPost]
        [Route("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courseList = await _utilityHelper.ExecuteAPICall<List<CourseModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllCourses");
            return Json(courseList);
        }

        [HttpPost]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var courseList = await _utilityHelper.ExecuteAPICall<List<StudentModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllStudents");
            return Json(courseList);
        }

        [HttpPost]
        [Route("GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var courseList = await _utilityHelper.ExecuteAPICall<List<StaffModel>>(null, RestSharp.Method.Post, resource: "api/Admin/GetAllStaff");
            return Json(courseList);
        }

        #region EmailTemplates

        [HttpPost]
        [Route("GetMasterEmailTemplates")]
        public async Task<IActionResult> GetMasterEmailTemplates()
        {
            var languageId = HttpContext?.Session?.GetInt32("LanguageId");

            var apiRequest = new ApiRequest() { RequestValue = languageId > 0 ? languageId.ToString() : "1" };

            var masterEmailTemplateList = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetMasterEmailTemplates");
            return Json(masterEmailTemplateList);
        }

        [HttpPost]
        [Route("GetAllEmailTemplates")]
        public async Task<IActionResult> GetAllEmailTemplates()
        {
            var emailTemplateList = await _utilityHelper.ExecuteAPICall<List<EmailTemplatesModel>>(null, RestSharp.Method.Post, resource: "api/Common/GetAllEmailTemplates");
            return Json(emailTemplateList);
        }

        [Route("CreateEmailTemplates")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateEmailTemplates(EmailTemplatesModel emailTemplateModel)
        {
            emailTemplateModel.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            emailTemplateModel.CreatedDate = DateTime.Now;

            await _utilityHelper.ExecuteAPICall<bool>(emailTemplateModel, RestSharp.Method.Post, resource: "api/Common/CreateEmailTemplates");
            return Json(new { value = "Success" });
        }

        [Route("UpdateEmailTemplates")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> UpdateEmailTemplates(EmailTemplatesModel emailTemplateModel)
        {
            emailTemplateModel.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            emailTemplateModel.ModifyDate = DateTime.Now;

            await _utilityHelper.ExecuteAPICall<bool>(emailTemplateModel, RestSharp.Method.Post, resource: "api/Common/UpdateEmailTemplates");
            return Json(new { value = "Success" });
        }

        [Route("DeleteEmailTemplates")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteEmailTemplates(string emailTemplateId)
        {
            var apiRequest = new ApiRequest() { RequestValue = emailTemplateId };
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/Common/DeleteEmailTemplates");
            return Json(new { value = "Success" });
        }

        #endregion
    }
}
