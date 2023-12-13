using Loogan.API.Models.Models;
using Loogan.Web.UI.Pages.Shared;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public List<SectionModel>? LeftSectionValues { get; set; }

        [BindProperty]
        public List<SectionModel>? RightSectionValues { get; set; }

        [BindProperty]
        public IStringLocalizer<LeftSideBarModel> _localizer { get; set; }

        [BindProperty]
        public string? ProfileName { get; set; }

        [BindProperty]
        public UserModel UserProfileModel { get; set; }


        public ProfileModel(IStringLocalizer<LeftSideBarModel> localizer, IUtilityHelper utilityHelper)
        {
            _localizer = localizer;
            _utilityHelper = utilityHelper;
        }

        public async Task OnGetAsync()
        {
            UserQuery query = new UserQuery();
            query.UserId = HttpContext?.Session?.GetInt32("LoginUserId");
            query.UserName = string.Empty;
            query.Password = string.Empty;

            var userModel = await _utilityHelper.ExecuteAPICall<UserModel>(query, RestSharp.Method.Post, resource: "api/User");
            if (userModel != null)
            {
                UserProfileModel = userModel;
                ProfileName = userModel?.FirstName + " " + userModel?.LastName;

                LeftSectionValues = new List<SectionModel> {
                new SectionModel()
                {
                    SectionName = "Basic Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Full Name", ProfileName },
                        {"Email Address", userModel?.EmailAddress }

                    }
                },
                new SectionModel()
                {
                    SectionName = "Additional Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Gender",userModel?.Gender },
                        {"Additional Name", userModel?.AdditionalName  },
                        {"Education Level", userModel?.EducationLevel  },
                        {"Website", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.WebSite) ? userModel.WebSite : "Add Website") + "</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = "Contact Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                         {"Mailing Address", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.EmailAddress) ? userModel.EmailAddress : "Add mailing address") + "</a>" },
                         {"Phone Number", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.PhoneNumber) ? userModel.PhoneNumber : "Add phone number") + "</a>" },
                         {"Business Fax Number", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Fax) ? userModel.Fax : "Add business fax number") + "</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = "Job Information",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Company", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Company) ? userModel.Company : "Add company") + "</a>" },
                        {"Job Title", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.JobTitle) ? userModel.JobTitle : "Add job title") + "</a>" },
                        {"Department", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Department) ? userModel.Department : "Add department") + "</a>" },
                    }
                }

            };

                RightSectionValues = new List<SectionModel> {
                new SectionModel()
                {
                    SectionName = "System Settings",
                    SectionValueData = new Dictionary<string, string>
                    {
                        {"Langauage",userModel?.UserLanguage },
                        {"Privacy Settigs", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">Only instructors can <br/> view my profile<br/> information</a>" },
                        {"Global Notification Settings", "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">Stream notifications</a> <br/><a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">Email notifications</a><br/><a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">Push notifications</a>" },
                    }
                },
            };
            }
        }
    }

    public class SectionModel
    {
        public string? SectionName { get; set; }

        public Dictionary<string, string>? SectionValueData { get; set; }
    }
}
