using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    }
}
