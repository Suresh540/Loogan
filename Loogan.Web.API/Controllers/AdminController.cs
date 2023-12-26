using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Services;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("GetAllCourses")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCourses()
        {
            var listCourses = await _adminService.GetAllCourses();
            return Ok(listCourses);
        }

        [HttpPost]
        [Route("CreateCourse")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse([FromBody] CourseModel courseObj)
        {
            var result = await _adminService.CreateCourse(courseObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateCourse")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseModel courseObj)
        {
            var result = await _adminService.UpdateCourse(courseObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllStaff")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStaff()
        {
            var listStaff = await _adminService.GetAllStaff();
            return Ok(listStaff);
        }

        [HttpPost]
        [Route("CreateStaff")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStaff([FromBody] StaffModel staffObj)
        {
            var result = await _adminService.CreateStaff(staffObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateStaff")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStaff([FromBody] StaffModel staffObj)
        {
            var result = await _adminService.UpdateStaff(staffObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllStudents")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStudents()
        {
            var listStudent = await _adminService.GetAllStudents();
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("CreateStudent")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel studentObj)
        {
            var result = await _adminService.CreateStudent(studentObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateStudent")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentModel studentObj)
        {
            var result = await _adminService.UpdateStudent(studentObj);
            return Ok(result);
        }
    }
}
