using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Services
{
    public class LooganStudentCourse(string? connectionString) : ILooganStudentCourse
    {

        public async Task<List<StudentCourseModel>?> GetStudentCourseDetails(int studentId)
        {
            List<StudentCourseModel>? studentCourseList = new List<StudentCourseModel>();
            using (var context = new LooganContext(connectionString))
            {
                var query = context.Database.SqlQuery<StudentCourseModel>($"Get_StudentCourseDetails {studentId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    studentCourseList.Add(item);
                }
            }
            return studentCourseList;
        }

    }
}
