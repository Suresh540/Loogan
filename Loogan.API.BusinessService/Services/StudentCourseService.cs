using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Database.Services;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly ILooganStudentCourse _looganStudentCourse;
        private readonly IMapper _mapper;

        public StudentCourseService(ILooganStudentCourse looganStudentCourse, IMapper mapper)
        {
            _looganStudentCourse = looganStudentCourse;
            _mapper = mapper;
        }

        public async Task<List<StudentCourseModel>> GetStudentCourseDetails(int studentId)
        {
            var studentCourseModelList = await _looganStudentCourse.GetStudentCourseDetails(studentId);
            return studentCourseModelList;
        }

        public async Task<List<StudentCourseMappingModel>> GetStudentCourseMappingDetails()
        {
            var studentCourseMappingModelList = await _looganStudentCourse.GetStudentCourseMappingDetails();
            return studentCourseMappingModelList;
        }

        public async Task<int?> CreateStudentCourseMapping(StudentCourseMappingModel studentCourseMappingModel)
        {
            var studentCourseMapping = _mapper.Map<StudentCourseMapping>(studentCourseMappingModel);
            var result = await _looganStudentCourse.CreateStudentCourseMapping(studentCourseMapping);
            return result;
        }

        public async Task<int?> UpdateStudentCourseMapping(StudentCourseMappingModel studentCourseMappingModel)
        {
            var studentCourseMapping = _mapper.Map<StudentCourseMapping>(studentCourseMappingModel);
            var result = await _looganStudentCourse.UpdateStudentCourseMapping(studentCourseMapping);
            return result;
        }

        public async Task<int?> DeleteStudentCourseMapping(int StudentCourseMappingId)
        {
            var result = await _looganStudentCourse.DeleteStudentCourseMapping(StudentCourseMappingId);
            return result;
        }

    }
}
