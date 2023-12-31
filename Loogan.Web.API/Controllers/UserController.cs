using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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
    }
}
