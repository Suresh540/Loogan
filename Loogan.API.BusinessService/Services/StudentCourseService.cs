using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
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
    }
}
