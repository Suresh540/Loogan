using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserLoginDetails([FromBody] UserQuery query)
        {
            UserLoginModel? model = await _userService.GetUserLoginDetailsService(query);
            return Ok(model);
        }

        [HttpPost]
        [Route("AllUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUserDetails()
        {
            var listUser = await _userService.GetAllUserDetailsService();
            return Ok(listUser);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserDetails([FromBody] UserQuery query)
        {
            var userId = query.UserId != null ? Convert.ToInt32(query.UserId) : 0;
            UserModel ? model = await _userService.GetUserDetailsService(userId);
            return Ok(model);
        }

        [HttpPost]
        [Route("GetUserEmailByUserName")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserEmailByUserName([FromBody] ForgotPswdModel userNameModel)
        {
            var ForgotPswdModel = await _userService.GetUserEmailByUserName(userNameModel.UserName);
            return Ok(ForgotPswdModel);
        }

        

        [HttpPost]
        [Route("CreateUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userObj)
        {
            var result = await _userService.CreateUser(userObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userObj)
        {
            var result = await _userService.UpdateUser(userObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser ([FromBody] ApiRequest request)
        {
            var userId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _userService.DeleteUser(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("UserByEmailAddress")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserDetailsUsingEmailAddress([FromBody] ForgotPswdModel request)
        {
            var result = await _userService.GetUserDetailsUsingEmailAddress(request?.EmailId);
            return Ok(result);
        }

        [HttpPost]
        [Route("IsUserNameExist")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IsUserNameExist([FromBody] UserNameEmailRequest request)
        {
            var result = await _userService.IsUserNameExist(request?.Text,request.UserId);
            return Ok(result);
        }

        [HttpPost]
        [Route("IsUserEmailExist")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IsUserEmailExist([FromBody] UserNameEmailRequest request)
        {
            var result = await _userService.IsUserEmailExist(request?.Text, request.UserId);
            return Ok(result);
        }

        #region InstitutionUserMapping

        [HttpPost]
        [Route("GetUsersByUserType")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetUsersByUserType([FromBody] ApiRequest request)
        {
            var userTypeId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 1;
            var listMenus = await _userService.GetUsersByUserType(userTypeId);
            return Ok(listMenus);
        }

        [HttpPost]
        [Route("GetInstitutionUserList")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetInstitutionUserList([FromBody] InstitutionUserRequest request)
        {
            var listMenus = await _userService.GetInstitutionUserList(request.InstitutionId,request.UserTypeId);
            return Ok(listMenus);
        }

        //[HttpPost]
        //[Route("GetMenus")]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //public async Task<IActionResult> GetAllMenus([FromBody] Request request)
        //{
        //    var listMenus = await _adminService.GetAllMenus(request.LanguageId);
        //    return Ok(listMenus);
        //}

        //[HttpPost]
        //[Route("GetRoleMenus")]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //public async Task<IActionResult> GetRoleMenus([FromBody] RoleMenuRequest request)
        //{
        //    var listMenus = await _adminService.GetRoleMenus(request.RoleId, request.LanguageId);
        //    return Ok(listMenus);
        //}

        //[HttpPost]
        //[Route("SaveRoleMenus")]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //public async Task<IActionResult> SaveRoleMenus([FromBody] List<SaveRoleMenuRequest> request)
        //{
        //    var listMenus = await _adminService.SaveRoleMenus(request);
        //    return Ok(listMenus);
        //}



        #endregion
    }
}
