using Loogan.API.BusinessService.Interfaces;
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
    }
}
