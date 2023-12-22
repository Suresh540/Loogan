using Loogan.API.Models.Models;
using Loogan.Web.UI.Pages.Shared;
using Loogan.Web.UI.Resources.Pages;
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
        public IStringLocalizer<ContentLabel> _localizer { get; set; }

        [BindProperty]
        public string? ProfileName { get; set; }

        [BindProperty]
        public UserModel UserProfileModel { get; set; }


        public ProfileModel(IStringLocalizer<ContentLabel> localizer, IUtilityHelper utilityHelper)
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
                    SectionName = _localizer["BasicInformationKey"],
                    SectionValueData = new Dictionary<string, string>
                    {
                        {_localizer["FullNameKey"], ProfileName },
                        {_localizer["EmailAddressKey"], userModel?.EmailAddress }

                    }
                },
                new SectionModel()
                {
                    SectionName = _localizer["AdditionalInformationKey"],
                    SectionValueData = new Dictionary<string, string>
                    {
                        {_localizer["GenderKey"],userModel?.Gender },
                        {_localizer["AdditionalNameKey"], userModel?.AdditionalName  },
                        {_localizer["EducationLevelKey"], userModel?.EducationLevel  },
                        {_localizer["WebsiteKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.WebSite) ? userModel.WebSite : _localizer["AddWebsiteKey"]) + "</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = _localizer["ContactInformationKey"],
                    SectionValueData = new Dictionary<string, string>
                    {
                         {_localizer["MailingAddressKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.EmailAddress) ? userModel.EmailAddress : _localizer["AddMailingAddressKey"]) + "</a>" },
                         {_localizer["PhoneNumberKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.PhoneNumber) ? userModel.PhoneNumber : _localizer["AddPhoneNumberKey"]) + "</a>" },
                         {_localizer["FaxNumberKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Fax) ? userModel.Fax : _localizer["AddBusinessFaxNumberKey"]) + "</a>" },
                    }
                },
                new SectionModel()
                {
                    SectionName = _localizer["JobInformationKey"],
                    SectionValueData = new Dictionary<string, string>
                    {
                        {_localizer["CompanyKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Company) ? userModel.Company : _localizer["AddCompanyKey"]) + "</a>" },
                        {_localizer["JobTitleKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.JobTitle) ? userModel.JobTitle : _localizer["AddJobTitleKey"]) + "</a>" },
                        {_localizer["DepartmentKey"], "<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">" + (!string.IsNullOrEmpty(userModel.Department) ? userModel.Department : _localizer["AddDepartmentKey"]) + "</a>" },
                    }
                }

            };

                RightSectionValues = new List<SectionModel> {
                new SectionModel()
                {
                    SectionName = _localizer["SystemSettingsKey"],
                    SectionValueData = new Dictionary<string, string>
                    {
                        {_localizer["LanguageKey"],userModel?.UserLanguage },
                        {_localizer["PrivacySettigsKey"], $"<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">{_localizer["OnlyInstructorViewKey"]}</a>" },
                        {_localizer["GlobalNotificationSettingsKey"], $"<a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">{_localizer["StreamNotificationsKey"]}</a> <br/><a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">{_localizer["EmailNotificationsKey"]}</a><br/><a href='#' data-toggle=\"modal\" data-target=\"#right_modal\">{_localizer["PushNotificationsKey"]}</a>" },
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
