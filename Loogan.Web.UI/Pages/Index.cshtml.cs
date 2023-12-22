using Loogan.API.Models.Models;
using Loogan.Web.UI.Resources.Pages;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Pages
{
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
                HttpContext.Session.SetString("LoginUserType", model?.UserTypeName);
                HttpContext.Session.SetString("UserName", model?.UserName);

                if (model.UserTypeName == "Student")
                    return RedirectToPage("/Dashboard/dashboard");
                else
                    return RedirectToPage("/Dashboard/admindashboard");
            }
            DisplayMessage = ""; //Localizer != null ? Localizer["UserPwdWrongKey"] : "";
            return Page();
        }
    }
}
