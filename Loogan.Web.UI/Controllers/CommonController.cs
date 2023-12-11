using Loogan.API.Models.Models;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.UI.Controllers
{
    [Route("Language")]
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
            var apiRequest = new ApiRequest() { RequestValue = lookUpType };
            var forgotPswdModels = await _utilityHelper.ExecuteAPICall<List<ForgotPswdModel>>(apiRequest, RestSharp.Method.Post, resource: "api/Common/GetMasterLookupValues");
            return Json(forgotPswdModels);
        }
    }
}
