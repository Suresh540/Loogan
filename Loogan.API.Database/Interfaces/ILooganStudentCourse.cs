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
    public interface ILooganStudentCourse
    {
        public Task<List<StudentCourseModel>> GetStudentCourseDetails(int studentId);

        public Task<List<StudentCourseMappingModel>> GetStudentCourseMappingDetails();

        public Task<int?> CreateStudentCourseMapping(StudentCourseMapping studentCourseMapping);
        public Task<int?> UpdateStudentCourseMapping(StudentCourseMapping studentCourseMapping);

        public Task<int?> DeleteStudentCourseMapping(int StudentCourseMappingId);
    }
}
