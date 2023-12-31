using Azure.Core;
using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
            var apiRequest = new ApiLookUpRequest() { LookupType = lookUpType, LanguageId = 1 };
            var masterLookUpValues = await _utilityHelper.ExecuteAPICall<List<DropDownListModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetMasterLookupValues");
            return Json(masterLookUpValues);
        }

        [Route("Index/{route}")]
        public async Task<IActionResult> Index([FromRoute] string route = "")
        {
            if (HttpContext != null && HttpContext?.User != null && HttpContext.User.Identity.IsAuthenticated)
            {
                var email = HttpContext.User.Identity.Name;
                ForgotPswdModel request = new ForgotPswdModel()
                {
                    EmailId = email,
                    Password = "",
                    UserName = "",
                };

                var model = await _utilityHelper.ExecuteAPICall<UserModel>(request, RestSharp.Method.Post, resource: "api/User/UserByEmailAddress");
                HttpContext.Session.SetInt32("LoginUserId", model.UserId);
                HttpContext.Session.SetInt32("LoginUserTypeId", model.UserTypeId);
                var userTypeName = Enum.TryParse(typeof(UserTypeEnum), model.UserTypeId.ToString(), out object usertypeName);
                HttpContext.Session.SetString("LoginUserType", userTypeName.ToString());
                HttpContext.Session.SetString("UserName", model?.UserName);
                HttpContext.Session.SetString("FullName", model?.FirstName+' '+model.LastName);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Authentication, model?.FirstName+' '+model.LastName),
                    new Claim(ClaimTypes.Role, userTypeName.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (userTypeName.ToString() == "Student")
                    return LocalRedirect("/Courses/courses");
                else
                    return LocalRedirect("/Admin/AdminDashboard");

            }
            return RedirectToPage($"");
        }
    }
}
