using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
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
            var courseCategoryList = await _commonService.GetCoursRelatedLookUp(apiRequest.LookupType, apiRequest.LanguageId);
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

        #region StudentCourse

        [HttpPost]
        [Route("GetAllStudentCourseMapping")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStudentCourseMapping()
        {
            var listStudentCourseMappingList = await _studentCourseService.GetStudentCourseMappingDetails();
            return Ok(listStudentCourseMappingList);
        }

        [HttpPost]
        [Route("CreateStudentCourseMapping")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStudentCourseMapping([FromBody] StudentCourseMappingModel studentCourseMapping)
        {
            var result = await _studentCourseService.CreateStudentCourseMapping(studentCourseMapping);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateStudentCourseMapping")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudentCourseMapping([FromBody] StudentCourseMappingModel studentCourseMapping)
        {
            var result = await _studentCourseService.UpdateStudentCourseMapping(studentCourseMapping);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteStudentCourseMapping")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudentCourseMapping([FromBody] ApiRequest request)
        {
            var staffId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _studentCourseService.DeleteStudentCourseMapping(staffId);
            return Ok(result);
        }

        #endregion


    }
}
