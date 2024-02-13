using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class StudentGradeMappingModel
    {
        public int StudentCourseMappingId { get; set; }

        public int CourseId { get; set; }

        public int CourseTypeSourceId { get; set; }

        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? CourseType { get; set; }

        public int StudentId { get; set; }
        public string? studentName { get; set; }
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public int? StudentCourseStatusId { get; set; }
        public string? StudentCourseStatus { get; set; }

        public int? GradeStudentMappingId { get; set; }
        public int? MasterGradeId { get; set; }

        public string? GradeCode { get; set; }

        public string? GradeName { get; set; }

        public string? StudentGradeRemarks { get; set; }

        public int TotalRecords { get; set; }
    }
}
