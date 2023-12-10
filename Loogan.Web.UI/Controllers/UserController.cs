using Loogan.API.Models.Models;
using Loogan.Web.UI.Pages.Shared;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Loogan.Web.UI.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUtilityHelper _utilityHelper;
        public UserController(IUtilityHelper utilityHelper)
        {
            _utilityHelper = utilityHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("GetAllUser")]
        public async Task<JsonResult> GetAllUser(UserModel user)
        {
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(user, RestSharp.Method.Post, resource: "api/User/AllUser");
            return Json(new { value = "Success" });
        }

        [Route("CreateUser")]
        public async Task<JsonResult> CreateUser(UserModel user)
        {
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(user, RestSharp.Method.Post, resource: "api/User/CreateUser");
            return Json(new { value = "Success" });
        }

        [Route("UpdateUser")]
        public async Task<JsonResult> UpdateUser(UserModel user)
        {
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(user, RestSharp.Method.Post, resource: "api/User/UpdateUser");
            return Json(new { value = "Success" });
        }
    }
}
