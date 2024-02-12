using Loogan.API.Models.Enums;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.Admin
{
    public class InstitutionMappingModel : PageModel
    {
        readonly IUtilityHelper _utilityHelper;

        public InstitutionMappingModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [BindProperty]
        public List<UserModel>? UserItems { get; set; }

        [BindProperty]
        public List<InstitutionUserModel>? SelectedUserItems { get; set; }


        public async Task OnGet()
        {
            var languageId = HttpContext?.Session.GetInt32("LanguageId") ?? 1;
            var apiRequest = new ApiRequest() { RequestValue = "0"};
            UserItems = await _utilityHelper.ExecuteAPICall<List<UserModel>>(apiRequest, RestSharp.Method.Post, resource: "api/User/GetUsersByUserType");

            InstitutionUserRequest instUserRequest = new InstitutionUserRequest();
            instUserRequest.InstitutionId = 0;
            instUserRequest.UserTypeId = 0;

            SelectedUserItems = await _utilityHelper.ExecuteAPICall<List<InstitutionUserModel>>(instUserRequest, RestSharp.Method.Post, resource: "api/User/GetInstitutionUserList");

            //Menu items
            UserItems = UserItems.Where(x => !SelectedUserItems.Any(y => y.UserId == x.UserId)).ToList();
        }
    }
}
