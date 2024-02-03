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
            var listUser = await _commonService.GetStatesByCountryId(apiRequest.LanguageId, apiRequest.CountryId);
            return Ok(listUser);
        }

        #region EmailTemplates

        [HttpPost]
        [Route("GetMasterEmailTemplates")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMasterEmailTemplates([FromBody] ApiRequest apiRequest)
        {
            var languageId = apiRequest.RequestValue != null ? Convert.ToInt32(apiRequest.RequestValue) : 1;
            var listMasterEmailTemplates = await _commonService.GetMasterEmailTemplates(languageId);
            return Ok(listMasterEmailTemplates);
        }

        [HttpPost]
        [Route("GetAllEmailTemplates")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEmailTemplates()
        {
            var emailTemplateList = await _commonService.GetAllEmailTemplates();
            return Ok(emailTemplateList);
        }

        [HttpPost]
        [Route("CreateEmailTemplates")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmailTemplates([FromBody] EmailTemplatesModel emailObj)
        {
            var result = await _commonService.CreateEmailTemplates(emailObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateEmailTemplates")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEmailTemplates([FromBody] EmailTemplatesModel emailObj)
        {
            var result = await _commonService.UpdateEmailTemplates(emailObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteEmailTemplates")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmailTemplates([FromBody] ApiRequest request)
        {
            var userId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _commonService.DeleteEmailTemplates(userId);
            return Ok(result);
        }

        #endregion
    }
}
