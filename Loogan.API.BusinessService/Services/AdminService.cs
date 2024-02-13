using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public async Task<int?> DeleteCourse(int courseId)
        {
            var result = await _looganAdmin.DeleteCourse(courseId);
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

        public async Task<int?> DeleteStaff(int staffId)
        {
            var result = await _looganAdmin.DeleteStaff(staffId);
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

        public async Task<int?> DeleteStudent(int studentId)
        {
            var result = await _looganAdmin.DeleteStudent(studentId);
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

        public async Task<List<RoleMenuModel>> GetRoleMenus(int roleId,int languageId)
        {
            var roleMenus = await _looganAdmin.GetRoleMenus(roleId,languageId);
            return roleMenus;
        }

        public async Task<int> SaveRoleMenus(List<SaveRoleMenuRequest> request)
        {
            var listMenus = await _looganAdmin.SaveRoleMenus(request);
            return listMenus;
        }

        public async Task<List<InstitutionModel>?> GetAllInstitutions(string? userId)
        {
            var institutionList = await _looganAdmin.GetAllInstitutions(userId);
            return institutionList;
        }

        public async Task<int?> CreateInstitution(InstitutionModel institutionModelObj)
        {
            var institutionObj = _mapper.Map<Institution>(institutionModelObj);
            var result = await _looganAdmin.CreateInstitution(institutionObj);
            return result;
        }
        public async Task<int?> UpdateInstitution(InstitutionModel institutionModelObj)
        {
            var institutionObj = _mapper.Map<Institution>(institutionModelObj);
            var result = await _looganAdmin.UpdateInstitution(institutionObj);
            return result;
        }

        public async Task<int?> DeleteInstitution(int institutionId)
        {
            var result = await _looganAdmin.DeleteInstitution(institutionId);
            return result;
        }

        public async Task<List<DropDownListModel>?> GetInstitutionsList()
        {
            var institutionsList = await _looganAdmin.GetInstitutionsList();
            return institutionsList;
        }

        public async Task<List<InstitutionNewsModel>?> GetAllInstitutionNews(string? userId)
        {
            var institutionNewsList = await _looganAdmin.GetAllInstitutionNews(userId);
            return institutionNewsList;
        }

        public async Task<int?> CreateInstitutionNews(InstitutionNewsModel institutionNewsModelObj)
        {
            var institutionNewsObj = _mapper.Map<InstitutionNews>(institutionNewsModelObj);
            var result = await _looganAdmin.CreateInstitutionNews(institutionNewsObj);
            return result;
        }
        public async Task<int?> UpdateInstitutionNews(InstitutionNewsModel institutionNewsModelObj)
        {
            var institutionNewsObj = _mapper.Map<InstitutionNews>(institutionNewsModelObj);
            var result = await _looganAdmin.UpdateInstitutionNews(institutionNewsObj);
            return result;
        }

        public async Task<int?> DeleteInstitutionNews(int institutionNewsId)
        {
            var result = await _looganAdmin.DeleteInstitutionNews(institutionNewsId);
            return result;
        }

        public async Task<List<InstitutionAnnouncementModel>?> GetAllInstitutionAnnouncement(string? userId)
        {
            var institutionNewsList = await _looganAdmin.GetAllInstitutionAnnouncement(userId);
            return institutionNewsList;
        }

        public async Task<int?> CreateInstitutionAnnouncement(InstitutionAnnouncementModel institutionAnnouncementModelObj)
        {
            var institutionAnnouncementObj = _mapper.Map<InstitutionAnnouncement>(institutionAnnouncementModelObj);
            var result = await _looganAdmin.CreateInstitutionAnnouncement(institutionAnnouncementObj);
            return result;
        }
        public async Task<int?> UpdateInstitutionAnnouncement(InstitutionAnnouncementModel institutionAnnouncementModelObj)
        {
            var institutionAnnouncementObj = _mapper.Map<InstitutionAnnouncement>(institutionAnnouncementModelObj);
            var result = await _looganAdmin.UpdateInstitutionAnnouncement(institutionAnnouncementObj);
            return result;
        }

        public async Task<int?> DeleteInstitutionAnnouncement(int institutionNewsId)
        {
            var result = await _looganAdmin.DeleteInstitutionAnnouncement(institutionNewsId);
            return result;
        }


        public async Task<List<MasterGradeModel>?> GetAllMasterGrades(int languageId)
        {
            var masterGradesList = await _looganAdmin.GetAllMasterGrades(languageId);
            var masterGradesObj = _mapper.Map<List<MasterGradeModel>>(masterGradesList);
            return masterGradesObj;
        }

        public async Task<List<StudentGradeMappingModel>?> GetStudentGradesByStaffId(int staffId)
        {
            var studentGradesMappingList = await _looganAdmin.GetStudentGradesByStaffId(staffId);
            return studentGradesMappingList;
        }
    }
}
