using Loogan.API.Models.Models;
using Loogan.Web.UI.Resources.Pages;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Loogan.API.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace Loogan.Web.UI.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public string? UserName { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        [BindProperty]
        public string? DisplayMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUtilityHelper utilityHelper)
        {
            _logger = logger;
            _utilityHelper = utilityHelper;
        }

        public void OnGet([FromRoute] string route = "")
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            DisplayMessage = "";
            if (string.IsNullOrEmpty(UserName))
            {
                DisplayMessage = "";
                return Page();
            }
            if (string.IsNullOrEmpty(Password))
            {
                DisplayMessage = "";
                return Page();
            }
            UserQuery query = new UserQuery();
            query.UserName = UserName;
            query.Password = Password;
            var model = await _utilityHelper.ExecuteAPICall<UserLoginModel>(query, RestSharp.Method.Get, resource: "api/User");
            if (model != null)
            {
                _logger.LogError("Logging info log");
                HttpContext.Session.SetInt32("LoginUserId", model.UserId);
                HttpContext.Session.SetInt32("LoginUserTypeId", model.UserTypeId);
                HttpContext.Session.SetString("LoginUserType", model?.UserTypeName ?? "");
                HttpContext.Session.SetString("UserName", model?.UserName ?? "");
                HttpContext.Session.SetString("FullName", model?.FullName ?? "");
                HttpContext.Session.SetInt32("StudentId", model?.StudentId ?? 0);
                HttpContext.Session.SetInt32("TeacherId", model?.TeacherId ?? 0);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model?.UserName??""),
                    new Claim(ClaimTypes.Authentication, model?.FullName??""),
                    new Claim(ClaimTypes.Role, model?.UserTypeName??"")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (model != null && model.UserTypeName != null && model.UserTypeName.Equals(UserTypeEnum.student.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Courses/courses");
                }
                else if (model != null && model.UserTypeName != null && model.UserTypeName.Equals(UserTypeEnum.teacher.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Staff/StaffDashboard");
                }
                else if (model != null && model.UserTypeName != null && model.UserTypeName.Equals(UserTypeEnum.admin.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Profile/Profile");
                }
            }
            DisplayMessage = "";
            return Page();
        }
    }
}
