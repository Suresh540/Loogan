using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Loogan.Web.UI.Pages.ActivityStream
{
    public class ActivityStreamModel : PageModel
    {
        private readonly IUtilityHelper _utilityHelper;
        public ActivityStreamModel(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        [BindProperty]
        public List<PagingUserModel>? Users { get; set; } = new List<PagingUserModel>();

        public async Task OnGetAsync()
        {
            Users = await _utilityHelper.ExecuteAPICall<List<PagingUserModel>>(null, RestSharp.Method.Post, resource: "api/User/AllUser");
            Users = Users?.Where(x => x.UserName != HttpContext.Session.GetString("UserName")).Select(x => x).ToList();
        }
    }
}
