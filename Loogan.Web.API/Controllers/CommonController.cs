using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Services;
using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpPost]
        [Route("GetMasterLookupValues")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMasterLookupValues([FromBody] ApiLookUpRequest apiRequest)
        {
            var listUser = await _commonService.GetMaserLookUpValues(apiRequest.LookupType, apiRequest.LanguageId);
            return Ok(listUser);
        }

        [HttpPost]
        [Route("GetCountrys")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountrys([FromBody] ApiRequest apiRequest)
        {
            var languageId = apiRequest.RequestValue != null ? Convert.ToInt32(apiRequest.RequestValue) : 1;
            var listUser = await _commonService.GetCountryList(languageId);
            return Ok(listUser);
        }

        [HttpPost]
        [Route("GetStatesByCountryId")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStatesByCountryId([FromBody] RequestStateModel apiRequest)
        {
            var listUser = await _commonService.GetStatesByCountryId(apiRequest.LanguageId, apiRequest.LanguageId);
            return Ok(listUser);
        }
    }
}
