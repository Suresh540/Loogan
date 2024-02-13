using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Interfaces
{
    public interface IAdminService
    {
        public Task<List<CourseModel>?> GetAllCourses();

        public Task<int?> CreateCourse(CourseModel courseModelObj);
        public Task<int?> UpdateCourse(CourseModel courseModelObj);

        Task<int?> DeleteCourse(int courseId);

        public Task<List<StaffModel>?> GetAllStaff();

        public Task<int?> CreateStaff(StaffModel staffModelObj);
        public Task<int?> UpdateStaff(StaffModel staffModelObj);

        public Task<int?> DeleteStaff(int staffId);

        public Task<List<StudentModel>?> GetAllStudents();

        public Task<int?> CreateStudent(StudentModel studentModelObj);
        public Task<int?> UpdateStudent(StudentModel studentModelObj);

        public Task<int?> DeleteStudent(int studentId);

        public Task<List<UserTypeModel>?> GetUserRoles(int languageId);

        public Task<List<MenuModel>?> GetAllMenus(int languageId);

        public Task<List<RoleMenuModel>> GetRoleMenus(int roleId, int languageId);

        public Task<int> SaveRoleMenus(List<SaveRoleMenuRequest> request);

        public Task<List<InstitutionModel>?> GetAllInstitutions(string? userId);
        public Task<int?> CreateInstitution(InstitutionModel institutionModelObj);
        public Task<int?> UpdateInstitution(InstitutionModel institutionModelObj);
        public Task<int?> DeleteInstitution(int institutionId);

        public Task<List<DropDownListModel>?> GetInstitutionsList();

        public Task<List<InstitutionNewsModel>?> GetAllInstitutionNews(string? userId);
        public Task<int?> CreateInstitutionNews(InstitutionNewsModel institutionNewsModelObj);
        public Task<int?> UpdateInstitutionNews(InstitutionNewsModel institutionNewsModelObj);
        public Task<int?> DeleteInstitutionNews(int institutionId);

        public Task<List<InstitutionAnnouncementModel>?> GetAllInstitutionAnnouncement(string? userId);
        public Task<int?> CreateInstitutionAnnouncement(InstitutionAnnouncementModel institutionAnnouncementModelObj);
        public Task<int?> UpdateInstitutionAnnouncement(InstitutionAnnouncementModel institutionAnnouncementModelObj);
        public Task<int?> DeleteInstitutionAnnouncement(int institutionId);

        public Task<List<MasterGradeModel>?> GetAllMasterGrades(int languageId);
        public Task<List<StudentGradeMappingModel>?> GetStudentGradesByStaffId(int staffId);

    }
}
