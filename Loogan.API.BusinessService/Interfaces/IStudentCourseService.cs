using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Interfaces
{
    public interface IStudentCourseService
    {
        public Task<List<StudentCourseModel>> GetStudentCourseDetails(int studentId);

        public Task<List<StudentCourseMappingModel>> GetStudentCourseMappingDetails();

        public Task<int?> CreateStudentCourseMapping(StudentCourseMappingModel studentCourseMappingModel);

        public Task<int?> UpdateStudentCourseMapping(StudentCourseMappingModel studentCourseMappingModel);

        public Task<int?> DeleteStudentCourseMapping(int StudentCourseMappingId);
    }
}
