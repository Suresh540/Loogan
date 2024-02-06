using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Interfaces
{
    public interface ILooganAdmin
    {
        public Task<List<CourseModel>?> GetAllCourses();

        public Task<int?> CreateCourse(Course courseModelObj);
        public Task<int?> UpdateCourse(Course courseModelObj);

        public Task<int?> DeleteCourse(int courseId);

        public Task<List<StaffModel>?> GetAllStaff();

        public Task<int?> CreateStaff(Staff staffModelObj);
        public Task<int?> UpdateStaff(Staff staffModelObj);

        public Task<int?> DeleteStaff(int staffId);

        public Task<List<StudentModel>?> GetAllStudents();

        public Task<int?> CreateStudent(Student studentModelObj);
        public Task<int?> UpdateStudent(Student studentModelObj);

        public Task<int?> DeleteStudent(int studentId);

        public Task<List<UserTypeModel>?> GetUserRoles(int languageId);

        public Task<List<MenuModel>?> GetAllMenus(int languageId);

        public Task<List<RoleMenuModel>> GetRoleMenus(int roleId, int languageId);

        public Task<int> SaveRoleMenus(List<SaveRoleMenuRequest> request);

        public Task<List<InstitutionModel>?> GetAllInstitutions();
        public Task<int?> CreateInstitution(Institution institutionObj);
        public Task<int?> UpdateInstitution(Institution institutionObj);
        public Task<int?> DeleteInstitution(int institutionId);

        public Task<List<DropDownListModel>?> GetInstitutionsList();

        public Task<List<InstitutionNewsModel>?> GetAllInstitutionNews();
        public Task<int?> CreateInstitutionNews(InstitutionNews institutionNewsObj);
        public Task<int?> UpdateInstitutionNews(InstitutionNews institutionNewsObj);
        public Task<int?> DeleteInstitutionNews(int institutionNewsId);

        public Task<List<InstitutionAnnouncementModel>?> GetAllInstitutionAnnouncement();
        public Task<int?> CreateInstitutionAnnouncement(InstitutionAnnouncement institutionAnnouncementObj);
        public Task<int?> UpdateInstitutionAnnouncement(InstitutionAnnouncement institutionAnnouncementObj);
        public Task<int?> DeleteInstitutionAnnouncement(int institutionAnnouncementId);
    }
}
