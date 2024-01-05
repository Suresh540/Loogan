using Loogan.API.Models.Enums;
using Loogan.API.Models.Models;
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
    }
}
