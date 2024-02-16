using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Loogan.Web.UI.Pages.Institution
{
    public class InstitutionModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;

        [BindProperty]
        public List<InstitutionModelExtended>? Institutionlist { get; set; }

        [BindProperty]
        public List<InstitutionNewsModel>? InstituteNews { get; set; }

        [BindProperty]
        public List<InstitutionAnnouncementModel>? InstituteAnouncements { get; set; }

        public InstitutionModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }
        public async Task OnGetAsync()
        {
            var today = DateTime.Now.Date;
            var apiRequest = new ApiRequest() { RequestValue = HttpContext.Session.GetInt32("LoginUserId").ToString() };
            Institutionlist = await _utilityHelper.ExecuteAPICall<List<InstitutionModelExtended>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutions");

            //News
            await GetNews(today, apiRequest);

            //Announcements
            await GetAnnouncements(today, apiRequest);
        }

        private async Task GetAnnouncements(DateTime today, ApiRequest apiRequest)
        {
            InstituteAnouncements = await _utilityHelper.ExecuteAPICall<List<InstitutionAnnouncementModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionAnnouncement");
            InstituteAnouncements = InstituteAnouncements?.Where(x => GetDate(x.StartDate,x.EndDate)).Select(x => x).ToList();
        }

        private async Task GetNews(DateTime today, ApiRequest apiRequest)
        {
            InstituteNews = await _utilityHelper.ExecuteAPICall<List<InstitutionNewsModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionNews");
            InstituteNews = InstituteNews?.Where(x => GetDate(x.StartDate, x.EndDate)).Select(x => x).ToList();
        }

        private bool GetDate(string? startDateString, string? endDateString)
        {
            if (string.IsNullOrEmpty(startDateString) || string.IsNullOrEmpty(endDateString))
            {
                return true;
            }
            DateTime.TryParseExact(startDateString, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out var startDate);
            DateTime.TryParseExact(endDateString, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.NoCurrentDateDefault, out var endDate);
            if(DateTime.Now.Date >= startDate && DateTime.Now.Date <= endDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
