using Loogan.API.Models.Models;
using Loogan.Web.UI.Pages.Shared;
using Loogan.Web.UI.Utilities;
using Microsoft.AspNetCore.Authorization;
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


        [Route("GetAllUser")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> GetAllUser(PagingModel pageModel)
        {
            var users = await _utilityHelper.ExecuteAPICall<List<PagingUserModel>>(null, RestSharp.Method.Post, resource: "api/User/AllUser");
            var pageList = users.Skip(pageModel.Pagesize * (pageModel.PageIndex - 1))
                        .Take(pageModel.Pagesize).ToList();

            return Json(pageList);
        }

        [Route("GetUserEmailByUserName")]
        public async Task<JsonResult> GetUserEmailByUserName(string userName)
        {
            var request = new { userName = userName };
            var forgotPswdModels = await _utilityHelper.ExecuteAPICall<List<ForgotPswdModel>>(request, RestSharp.Method.Post, resource: "api/User/GetUserEmailByUserName");
            return Json(forgotPswdModels);
        }

        [Route("CreateUser")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> CreateUser(UserModel user)
        {
            user.CreatedBy = HttpContext?.Session?.GetInt32("LoginUserId");
            user.CreatedDate = DateTime.Now;
            await _utilityHelper.ExecuteAPICall<bool>(user, RestSharp.Method.Post, resource: "api/User/CreateUser");
            return Json(new { value = "Success" });
        }

        [Route("UpdateUser")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> UpdateUser(UserModel user)
        {
            user.ModifyBy = HttpContext?.Session?.GetInt32("LoginUserId");
            user.ModifyDate = DateTime.Now;
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(user, RestSharp.Method.Post, resource: "api/User/UpdateUser");
            return Json(new { value = "Success" });
        }

        [Route("DeleteUser")]
        [LooganAdminAuthorize("Admin")]
        public async Task<JsonResult> DeleteUser(string userid)
        {
            var apiRequest = new ApiRequest() { RequestValue = userid };
            var userModel = await _utilityHelper.ExecuteAPICall<bool>(apiRequest, RestSharp.Method.Post, resource: "api/User/DeleteUser");
            return Json(new { value = "Success" });
        }

        [Route("UserByEmailAddress")]
        [Authorize]
        public async Task<JsonResult> GetUserDetailsUsingEmailAddress(string email)
        {
            ForgotPswdModel request = new ForgotPswdModel();
            request.EmailId = email;

            var userModel = await _utilityHelper.ExecuteAPICall<UserModel>(request, RestSharp.Method.Post, resource: "api/User/UserByEmailAddress");
            return Json(userModel);
        }
    }
}
