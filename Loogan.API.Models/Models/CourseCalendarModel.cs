using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models
{
    public class CourseCalendarModel
    {
        public DateTime? CourseRegisteredDate { get; set; }

        public DateTime? CourseStartDate { get; set; }

        public DateTime? CourseCompletedDate { get; set; }

        public bool? CourseCurrentStatusInd { get; set; }

        public string? CourseCurrentStatus { get; set; }

        public int CourseId { get; set; }

        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? CourseType { get; set; }

        public int StudentId { get; set; }
        public string? studentName { get; set; }

        public int? StudentCourseStatusId { get; set; }

        public string? StudentCourseStatus { get; set; }

        public int StaffId { get; set; }

        public string? StaffName { get; set; }

        public double? CourseCreditHours { get; set; }

        public double? CourseCredit { get; set; }

        public double? MinusAbsent { get; set; }

        public double? MinusAttended { get; set; }

        public double? TotalHoursAttempted { get; set; }

        public double? TotalHoursEarned { get; set; }

        public bool? CourseCompletedStatusInd { get; set; }
    }
}
