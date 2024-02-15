using Azure.Core;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.BusinessService.Services;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Loogan.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #region Course

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
        [Route("DeleteCourse")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCourse([FromBody] ApiRequest request)
        {
            var courseId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteCourse(courseId);
            return Ok(result);
        }

        #endregion

        #region Staff

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
        [Route("DeleteStaff")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStaff([FromBody] ApiRequest request)
        {
            var staffId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteStaff(staffId);
            return Ok(result);
        }

        #endregion

        #region Student

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

        [HttpPost]
        [Route("DeleteStudent")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudent([FromBody] ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteStudent(studentId);
            return Ok(result);
        }

        #endregion

        #region RoleMapping

        [HttpPost]
        [Route("GetUserRoles")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetUserRoles([FromBody] Loogan.API.Models.Models.Request request)
        {
            var listMenus = await _adminService.GetUserRoles(request.LanguageId);
            return Ok(listMenus);
        }

        [HttpPost]
        [Route("GetMenus")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetAllMenus([FromBody] Loogan.API.Models.Models.Request request)
        {
            var listMenus = await _adminService.GetAllMenus(request.LanguageId);
            return Ok(listMenus);
        }

        [HttpPost]
        [Route("GetRoleMenus")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetRoleMenus([FromBody] RoleMenuRequest request)
        {
            var listMenus = await _adminService.GetRoleMenus(request.RoleId,request.LanguageId);
            return Ok(listMenus);
        }

        [HttpPost]
        [Route("SaveRoleMenus")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> SaveRoleMenus([FromBody] List<SaveRoleMenuRequest> request)
        {
            var listMenus = await _adminService.SaveRoleMenus(request);
            return Ok(listMenus);
        }



        #endregion

        #region Institution

        [HttpPost]
        [Route("GetAllInstitutions")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllInstitutions([FromBody] ApiRequest request)
        {
            var userId = request.RequestValue;
            var listStudent = await _adminService.GetAllInstitutions(userId);
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("CreateInstitution")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateInstitution([FromBody] InstitutionModel institutionModelObj)
        {
            var result = await _adminService.CreateInstitution(institutionModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateInstitution")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateInstitution([FromBody] InstitutionModel institutionModelObj)
        {
            var result = await _adminService.UpdateInstitution(institutionModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteInstitution")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInstitution([FromBody] ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteStudent(studentId);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetInstitutionsList")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetInstitutionsList()
        {
            var institutionsList = await _adminService.GetInstitutionsList();
            return Ok(institutionsList);
        }

        #endregion

        #region InstitutionNews

        [HttpPost]
        [Route("GetAllInstitutionNews")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllInstitutionNews([FromBody] ApiRequest request)
        {
            var userId = request.RequestValue;
            var listStudent = await _adminService.GetAllInstitutionNews(userId);
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("CreateInstitutionNews")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateInstitutionNews([FromBody] InstitutionNewsModel institutionNewsModelObj)
        {
            var result = await _adminService.CreateInstitutionNews(institutionNewsModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateInstitutionNews")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateInstitutionNews([FromBody] InstitutionNewsModel institutionNewsModelObj)
        {
            var result = await _adminService.UpdateInstitutionNews(institutionNewsModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteInstitutionNews")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInstitutionNews([FromBody] ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteInstitutionNews(studentId);
            return Ok(result);
        }

        #endregion

        #region InstitutionAnnouncement

        [HttpPost]
        [Route("GetAllInstitutionAnnouncement")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllInstitutionAnnouncement([FromBody] ApiRequest request)
        {
            var userId = request.RequestValue;
            var listStudent = await _adminService.GetAllInstitutionAnnouncement(userId);
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("CreateInstitutionAnnouncement")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateInstitutionAnnouncement([FromBody] InstitutionAnnouncementModel institutionAnnouncementModelObj)
        {
            var result = await _adminService.CreateInstitutionAnnouncement(institutionAnnouncementModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateInstitutionAnnouncement")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateInstitutionAnnouncement([FromBody] InstitutionAnnouncementModel institutionAnnouncementModelObj)
        {
            var result = await _adminService.UpdateInstitutionAnnouncement(institutionAnnouncementModelObj);
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteInstitutionAnnouncement")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteInstitutionAnnouncement([FromBody] ApiRequest request)
        {
            var studentId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var result = await _adminService.DeleteInstitutionAnnouncement(studentId);
            return Ok(result);
        }

        #endregion

        #region Grades

        [HttpPost]
        [Route("GetAllMasterGrades")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMasterGrades([FromBody] ApiRequest request)
        {
            var languageId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var listStudent = await _adminService.GetAllMasterGrades(languageId);
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("GetStudentGradesByStaffId")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentGradesByStaffId([FromBody] ApiRequest request)
        {
            var staffId = request.RequestValue != "" ? Convert.ToInt32(request.RequestValue) : 0;
            var listStudent = await _adminService.GetStudentGradesByStaffId(staffId);
            return Ok(listStudent);
        }

        [HttpPost]
        [Route("SaveStudentGradeMapping")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> SaveStudentGradeMapping([FromBody] List<SaveStudentGradeMappingModel> request)
        {
            var listInstitutionUsers = await _adminService.SaveStudentGradeMapping(request);
            return Ok(listInstitutionUsers);
        }

        #endregion


    }
}
