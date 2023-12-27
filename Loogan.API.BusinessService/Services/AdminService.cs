using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Services
{
    public class AdminService : IAdminService
    {
        private readonly ILooganAdmin _looganAdmin;
        private readonly IMapper _mapper;

        public AdminService(ILooganAdmin looganAdmin, IMapper mapper)
        {
            _looganAdmin = looganAdmin;
            _mapper = mapper;
        }
        public async Task<List<CourseModel>?> GetAllCourses()
        {
            var coursesList = await _looganAdmin.GetAllCourses();
            return coursesList;
        }

        public async Task<int?> CreateCourse(CourseModel courseModelObj)
        {
            var courseObj = _mapper.Map<Course>(courseModelObj);
            var result = await _looganAdmin.CreateCourse(courseObj);
            return result;
        }
        public async Task<int?> UpdateCourse(CourseModel courseModelObj)
        {
            var courseObj = _mapper.Map<Course>(courseModelObj);
            var result = await _looganAdmin.UpdateCourse(courseObj);
            return result;
        }

        public async Task<List<StaffModel>?> GetAllStaff()
        {
            var staffList = await _looganAdmin.GetAllStaff();
            return staffList;
        }

        public async Task<int?> CreateStaff(StaffModel staffModelObj)
        {
            var staffObj = _mapper.Map<Staff>(staffModelObj);
            var result = await _looganAdmin.CreateStaff(staffObj);
            return result;
        }
        public async Task<int?> UpdateStaff(StaffModel staffModelObj)
        {
            var staffObj = _mapper.Map<Staff>(staffModelObj);
            var result = await _looganAdmin.UpdateStaff(staffObj);
            return result;
        }

        public async Task<List<StudentModel>?> GetAllStudents()
        {
            var studentList = await _looganAdmin.GetAllStudents();
            return studentList;
        }

        public async Task<int?> CreateStudent(StudentModel studentModelObj)
        {
            var studentObj = _mapper.Map<Student>(studentModelObj);
            var result = await _looganAdmin.CreateStudent(studentObj);
            return result;
        }
        public async Task<int?> UpdateStudent(StudentModel studentModelObj)
        {
            var studentObj = _mapper.Map<Student>(studentModelObj);
            var result = await _looganAdmin.UpdateStudent(studentObj);
            return result;
        }

        public async Task<List<UserTypeModel>?> GetUserRoles(int languageId)
        {
            var userRolesList = await _looganAdmin.GetUserRoles(languageId);
            return userRolesList;
        }

        public async Task<List<MenuModel>?> GetAllMenus(int languageId)
        {
            var allMenus = await _looganAdmin.GetAllMenus(languageId);
            return allMenus;
        }

        public async Task<List<RoleMenuModel>> GetRoleMenus(int languageId)
        {
            var roleMenus = await _looganAdmin.GetRoleMenus(languageId);
            return roleMenus;
        }
    }
}
