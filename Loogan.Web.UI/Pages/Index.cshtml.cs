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
                DisplayMessage = ""; //Localizer != null ? Localizer["UserNameEmptyKey"] : "";
                return Page();
            }
            if (string.IsNullOrEmpty(Password))
            {
                DisplayMessage = ""; //Localizer != null ? Localizer["PasswordEmptyKey"] : "";
                return Page();
            }
            UserQuery query = new UserQuery();
            query.UserName = UserName;
            query.Password = Password;
            var model = await _utilityHelper.ExecuteAPICall<UserLoginModel>(query, RestSharp.Method.Get, resource: "api/User");
            if (model != null)
            {
                HttpContext.Session.SetInt32("LoginUserId", model.UserId);
                HttpContext.Session.SetInt32("LoginUserTypeId", model.UserTypeId);
                HttpContext.Session.SetString("LoginUserType", model?.UserTypeName);
                HttpContext.Session.SetString("UserName", model?.UserName);
                HttpContext.Session.SetString("FullName", model?.FullName);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Authentication, model.FullName),
                    new Claim(ClaimTypes.Role, model.UserTypeName)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (model.UserTypeName.Equals(UserTypeEnum.student.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Courses/courses");
                }
                else if (model.UserTypeName.Equals(UserTypeEnum.teacher.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Staff/StaffDashboard");
                }
                else if (model.UserTypeName.Equals(UserTypeEnum.admin.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    return LocalRedirect("/Admin/AdminDashboard");
                }
            }
            DisplayMessage = ""; //Localizer != null ? Localizer["UserPwdWrongKey"] : "";
            return Page();
        }
    }
}
