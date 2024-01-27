using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Models.Models.Admin
{
    public class StudentCourseMappingModel
    {
        public int StudentCourseMappingId { get; set; }

        public int? CampusId { get; set; }

        public int CourseId { get; set; }

        public int CourseTypeSourceId { get; set; }

        public string? CourseCode { get; set; }

        public string? CourseName { get; set; }

        public string? CourseType { get; set; }
        public int? ClassSectionId { get; set; }
        public int? EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string? studentName { get; set; }
        public int StaffId { get; set; }

        public string? StaffName { get; set; }
        public int? TermId { get; set; }
        public int? StudentCourseStatusId { get; set; }

        public string? StudentCourseStatus { get; set; }

        public double? CourseCreditHours { get; set; }

        public double? CourseCredit { get; set; }

        public double? MinusAbsent { get; set; }

        public double? MinusAttended { get; set; }

        public double? NumericGradeObtained { get; set; }

        public double? TotalGradeAttempted { get; set; }

        public double? TotalCreditsEarned { get; set; }

        public double? TotalHoursAttempted { get; set; }

        public double? TotalHoursEarned { get; set; }

        public string? GradeLetterCodeObtained { get; set; }

        public string? GradeNote { get; set; }

        public string? CourseCompletedDate { get; set; }

        public string? CourseDropDate { get; set; }

        public string? CourseLastAttendedDate { get; set; }

        public string? CourseRegisteredDate { get; set; }

        public string? CourseStartDate { get; set; }

        public string? ExpectedCourseEndDate { get; set; }

        public string? GradePostedDate { get; set; }

        public bool? CourseCompletedStatusInd { get; set; }

        public bool? CourseCurrentStatusInd { get; set; }

        public bool? CourseDroppedStatusInd { get; set; }

        public bool? CourseFutureStatusInd { get; set; }

        public bool? CourseLeaveOfAbsenceStatusInd { get; set; }

        public bool? CourseScheduledStatusInd { get; set; }

        public bool? CourseRetakeInd { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
