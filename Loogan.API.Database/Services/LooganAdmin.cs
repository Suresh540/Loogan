using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Services
{
    public class LooganAdmin : ILooganAdmin
    {
        string? _connectionString = string.Empty;
        public LooganAdmin(IConfiguration configuration)
        {
            _connectionString = configuration?["ConnectionStrings:looganConnectionString"];
        }
        public async Task<List<CourseModel>?> GetAllCourses()
        {
            List<CourseModel>? courses = new List<CourseModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<CourseModel>($"Get_AllCourses").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    courses.Add(item);
                }
            }
            return courses;
        }

        public async Task<int?> CreateCourse(Course courseObj)
        {
            var isCreated = 0;

            if (courseObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Courses.Add(courseObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateCourse(Course courseObj)
        {
            var isUpdated = 0;

            if (courseObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Courses.Update(courseObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteCourse(int courseId)
        {
            var isDeleted = 0;

            if (courseId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var course = context.Courses.FirstOrDefault(x => x.CourseId == courseId);

                    if (course != null)
                    {
                        course.IsDeleted = true;
                        context.Courses.Update(course);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }

        public async Task<List<StaffModel>?> GetAllStaff()
        {
            List<StaffModel>? staffs = new List<StaffModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<StaffModel>($"Get_AllStaff").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    staffs.Add(item);
                }
            }
            return staffs;
        }

        public async Task<int?> CreateStaff(Staff staffObj)
        {
            var isCreated = 0;

            if (staffObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    int? PerviousStaffId = context.Staff.Max(u => (int?)u.StaffId);
                    if (PerviousStaffId > 0)
                        staffObj.Code = "Staff_" + (PerviousStaffId + 1);
                    else
                        staffObj.Code = "Staff_1";

                    if (staffObj.UserId == 0)
                        staffObj.UserId = null;
                    context.Staff.Add(staffObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateStaff(Staff staffObj)
        {
            var isUpdated = 0;

            if (staffObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Staff.Update(staffObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }




        public async Task<int?> DeleteStaff(int staffId)
        {
            var isDeleted = 0;

            if (staffId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var staff = context.Staff.FirstOrDefault(x => x.StaffId == staffId);

                    if (staff != null)
                    {
                        staff.IsDeleted = true;
                        context.Staff.Update(staff);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }

        public async Task<List<StudentModel>?> GetAllStudents()
        {
            List<StudentModel>? studentList = new List<StudentModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<StudentModel>($"Get_AllStudents").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    studentList.Add(item);
                }
            }
            return studentList;
        }

        public async Task<int?> CreateStudent(Student studentObj)
        {
            var isCreated = 0;

            if (studentObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Students.Add(studentObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateStudent(Student studentObj)
        {
            var isUpdated = 0;

            if (studentObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Students.Update(studentObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteStudent(int studentId)
        {
            var isDeleted = 0;

            if (studentId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var student = context.Students.FirstOrDefault(x => x.StudentId == studentId);

                    if (student != null)
                    {
                        student.IsDeleted = true;
                        context.Students.Update(student);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }
        public async Task<List<UserTypeModel>?> GetUserRoles(int languageId)
        {
            var list = new List<UserTypeModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var userType = context.UserTypes.ToList();
                if (userType.Any())
                {
                    foreach (var item in userType)
                    {
                        list.Add(new UserTypeModel() { UserTypeId = item.UserTypeId, UserType = item.UserType1, Description = item.Description });
                    }

                }
            }
            return list;
        }

        public async Task<List<MenuModel>?> GetAllMenus(int languageId)
        {
            var list = new List<MenuModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<MenuModel>($"Get_AllMenus {languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public async Task<List<RoleMenuModel>> GetRoleMenus(int roleId, int languageId)
        {
            var list = new List<RoleMenuModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<RoleMenuModel>($"Get_RoleMenus {roleId},{languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public async Task<int> SaveRoleMenus(List<SaveRoleMenuRequest> request)
        {
            var isSuccess = 0;

            if (request.Count > 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var roleId = request?.FirstOrDefault()?.RoleId;
                    if (roleId > 0)
                    {
                        var menuRoleMapping = context.MenuRoleMappings.Where(x => x.RoleId == roleId).ToList();
                        if (menuRoleMapping.Any())
                        {
                            context.MenuRoleMappings.RemoveRange(menuRoleMapping.ToArray());
                        }
                    }
                    foreach (var item in request)
                    {
                        var menuRoleMapping = new MenuRoleMapping()
                        {
                            PrimaryMenuId = item.PrimaryMenuId,
                            RoleId = item.RoleId
                        };
                        context.MenuRoleMappings.Add(menuRoleMapping);
                    }

                    context.SaveChanges();
                }
            }

            return isSuccess;

        }

        public async Task<List<InstitutionModel>?> GetAllInstitutions(string? userId)
        {
            List<InstitutionModel>? institutionList = new List<InstitutionModel>();
            using (var context = new LooganContext(_connectionString))
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var Id = Convert.ToInt32(userId);
                    var query = context.Database.SqlQuery<InstitutionModel>($"Get_InstitutionsByUserId {Id}").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionList.Add(item);
                    }
                }
                else
                {
                    var query = context.Database.SqlQuery<InstitutionModel>($"Get_AllInstitutions").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionList.Add(item);
                    }
                }
            }
            return institutionList;
        }

        public async Task<int?> CreateInstitution(Institution institutionObj)
        {
            var isCreated = 0;

            if (institutionObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Institutions.Add(institutionObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateInstitution(Institution institutionObj)
        {
            var isUpdated = 0;

            if (institutionObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Institutions.Update(institutionObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteInstitution(int institutionId)
        {
            var isDeleted = 0;

            if (institutionId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var institutionobj = context.Institutions.FirstOrDefault(x => x.InstitutionId == institutionId);

                    if (institutionobj != null)
                    {
                        institutionobj.IsDeleted = true;
                        context.Institutions.Update(institutionobj);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }

        public async Task<List<DropDownListModel>?> GetInstitutionsList()
        {
            var list = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var country = context.Institutions.Where(x => x.IsDeleted == false).ToList();
                if (country.Any())
                {
                    foreach (var item in country)
                    {
                        list.Add(new DropDownListModel() { Id = item.InstitutionId, Name = item.InstitutionName });
                    }

                }
            }
            return list;
        }

        public async Task<List<InstitutionNewsModel>?> GetAllInstitutionNews(string? userId)
        {
            List<InstitutionNewsModel>? institutionNewsList = new List<InstitutionNewsModel>();

            using (var context = new LooganContext(_connectionString))
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var Id = Convert.ToInt32(userId);
                    var query = context.Database.SqlQuery<InstitutionNewsModel>($"Get_InstitutionsNewsByUserId {Id}").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionNewsList.Add(item);
                    }
                }
                else
                {
                    var query = context.Database.SqlQuery<InstitutionNewsModel>($"Get_AllInstitutionsNews").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionNewsList.Add(item);
                    }
                }
            }
            return institutionNewsList;
        }

        public async Task<int?> CreateInstitutionNews(InstitutionNews institutionNewsObj)
        {
            var isCreated = 0;

            if (institutionNewsObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.InstitutionNews.Add(institutionNewsObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateInstitutionNews(InstitutionNews institutionNewsObj)
        {
            var isUpdated = 0;

            if (institutionNewsObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.InstitutionNews.Update(institutionNewsObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteInstitutionNews(int institutionNewsId)
        {
            var isDeleted = 0;

            if (institutionNewsId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var institutionNewsobj = context.InstitutionNews.FirstOrDefault(x => x.InstitutionNewsId == institutionNewsId);

                    if (institutionNewsobj != null)
                    {
                        institutionNewsobj.IsDeleted = true;
                        context.InstitutionNews.Update(institutionNewsobj);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }

        public async Task<List<InstitutionAnnouncementModel>?> GetAllInstitutionAnnouncement(string? userId)
        {
            List<InstitutionAnnouncementModel>? institutionAnnouncementList = new List<InstitutionAnnouncementModel>();
            using (var context = new LooganContext(_connectionString))
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    var Id = Convert.ToInt32(userId);
                    var query = context.Database.SqlQuery<InstitutionAnnouncementModel>($"Get_InstitutionsAnnouncementsByUserId {Id}").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionAnnouncementList.Add(item);
                    }
                }
                else
                {
                    var query = context.Database.SqlQuery<InstitutionAnnouncementModel>($"Get_AllInstitutionsAnnouncements").AsNoTracking().AsAsyncEnumerable();
                    await foreach (var item in query)
                    {
                        institutionAnnouncementList.Add(item);
                    }
                }
            }
            return institutionAnnouncementList;
        }

        public async Task<int?> CreateInstitutionAnnouncement(InstitutionAnnouncement institutionAnnouncementObj)
        {
            var isCreated = 0;

            if (institutionAnnouncementObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.InstitutionAnnouncements.Add(institutionAnnouncementObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateInstitutionAnnouncement(InstitutionAnnouncement institutionAnnouncementObj)
        {
            var isUpdated = 0;

            if (institutionAnnouncementObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.InstitutionAnnouncements.Update(institutionAnnouncementObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteInstitutionAnnouncement(int institutionAnnouncementId)
        {
            var isDeleted = 0;

            if (institutionAnnouncementId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var institutionNewsobj = context.InstitutionAnnouncements.FirstOrDefault(x => x.InstitutionAnnouncementId == institutionAnnouncementId);

                    if (institutionNewsobj != null)
                    {
                        institutionNewsobj.IsDeleted = true;
                        context.InstitutionAnnouncements.Update(institutionNewsobj);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }
    }
}
