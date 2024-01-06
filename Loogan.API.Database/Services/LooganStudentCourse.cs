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
    public class LooganStudentCourse : ILooganStudentCourse
    {
        string? _connectionString = string.Empty;
        public LooganStudentCourse(IConfiguration configuration)
        {
            _connectionString = configuration?["ConnectionStrings:looganConnectionString"];
        }
        public async Task<List<StudentCourseModel>?> GetStudentCourseDetails(int studentId)
        {
            List<StudentCourseModel>? studentCourseList = new List<StudentCourseModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<StudentCourseModel>($"Get_StudentCourseDetails {studentId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    studentCourseList.Add(item);
                }
            }
            return studentCourseList;
        }

        public async Task<List<StudentCourseMappingModel>> GetStudentCourseMappingDetails()
        {
            List<StudentCourseMappingModel>? studentCourseMappingList = new List<StudentCourseMappingModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<StudentCourseMappingModel>($"Get_AllStudentCourseMappingDetails").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    studentCourseMappingList.Add(item);
                }
            }
            return studentCourseMappingList;
        }

        public async Task<int?> CreateStudentCourseMapping(StudentCourseMapping studentCourseMapping)
        {
            var isCreated = 0;

            if (studentCourseMapping != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.StudentCourseMappings.Add(studentCourseMapping);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateStudentCourseMapping(StudentCourseMapping studentCourseMapping)
        {
            var isUpdated = 0;

            if (studentCourseMapping != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.StudentCourseMappings.Update(studentCourseMapping);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteStudentCourseMapping(int StudentCourseMappingId)
        {
            var isDeleted = 0;

            if (StudentCourseMappingId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var StudentCourseMappings = context.StudentCourseMappings.FirstOrDefault(x => x.StudentCourseMappingId == StudentCourseMappingId);

                    if (StudentCourseMappings != null)
                    {
                        StudentCourseMappings.IsDeleted = true;
                        context.StudentCourseMappings.Update(StudentCourseMappings);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }



    }
}
