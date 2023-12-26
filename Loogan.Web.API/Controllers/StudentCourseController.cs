using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Services;
using Loogan.API.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(ICommonService commonService, IStudentCourseService studentCourseService)
        {
            _commonService = commonService;
            _studentCourseService = studentCourseService;
        }

        [HttpPost]
        [Route("GetCourseCategory")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCourseCategory(ApiLookUpRequest apiRequest)
        {
            var courseCategoryList = await _commonService.GetMaserLookUpValues(apiRequest.LookupType, apiRequest.LanguageId);
            return Ok(courseCategoryList);
        }

        [HttpPost]
        [Route("GetStudentCourseDetails")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentCourseDetails(ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var studentCourseList = await _studentCourseService.GetStudentCourseDetails(studentId);
            return Ok(studentCourseList);
        }

        
    }
}
