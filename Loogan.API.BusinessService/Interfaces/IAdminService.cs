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

        public Task<List<StaffModel>?> GetAllStaff();

        public Task<int?> CreateStaff(StaffModel staffModelObj);
        public Task<int?> UpdateStaff(StaffModel staffModelObj);

        public Task<List<StudentModel>?> GetAllStudents();

        public Task<int?> CreateStudent(StudentModel studentModelObj);
        public Task<int?> UpdateStudent(StudentModel studentModelObj);

        public Task<List<UserTypeModel>?> GetUserRoles(int languageId);

        public Task<List<MenuModel>?> GetAllMenus(int languageId);

        public Task<List<RoleMenuModel>> GetRoleMenus(int roleId, int languageId);

        public Task<int> SaveRoleMenus(List<SaveRoleMenuRequest> request);
    }
}
