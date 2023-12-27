using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
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

        public async Task<List<RoleMenuModel>> GetRoleMenus(int languageId)
        {
            var list = new List<RoleMenuModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<RoleMenuModel>($"Get_RoleMenus {languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
