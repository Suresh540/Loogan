using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Loogan.Web.UI.Models;
using Loogan.Web.UI.Pages.Shared;
using Loogan.Web.UI.Resources.Pages;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

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
            var apiRequest = new ApiRequest() { RequestValue = HttpContext.Session.GetInt32("LoginUserId").ToString() };
            Institutionlist = await _utilityHelper.ExecuteAPICall<List<InstitutionModelExtended>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutions");
            InstituteNews = await _utilityHelper.ExecuteAPICall<List<InstitutionNewsModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionNews");
            InstituteAnouncements = await _utilityHelper.ExecuteAPICall<List<InstitutionAnnouncementModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Admin/GetAllInstitutionAnnouncement");
        }
    }
}
