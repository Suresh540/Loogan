using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class StudentCourseModel
    {
        public int CourseId { get; set; }

        public int CourseTypeSourceId { get; set;}

        public string? CourseType { get;set; }

        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? CourseDesc { get; set; }

        public int StudentId { get; set; }

        public string? StudentNumber { get;set; }

        public string? StudentName { get;set; }

        public int StaffId { get; set; }

        public string? StaffName { get; set; }

        public string? StudentCourseStatus { get;set; }
    }
}
