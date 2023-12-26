using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class StudentCourseMapping
{
    public int StudentCourseMappingId { get; set; }

    public int? CampusId { get; set; }

    public int? ClassSectionId { get; set; }

    public int CourseId { get; set; }

    public int? EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int StaffId { get; set; }

    public int? TermId { get; set; }

    public int? StudentCourseStatusId { get; set; }

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

    public DateTime? CourseCompletedDate { get; set; }

    public DateTime? CourseDropDate { get; set; }

    public DateTime? CourseLastAttendedDate { get; set; }

    public DateTime? CourseRegisteredDate { get; set; }

    public DateTime? CourseStartDate { get; set; }

    public DateTime? ExpectedCourseEndDate { get; set; }

    public DateTime? GradePostedDate { get; set; }

    public bool? CourseCompletedStatusInd { get; set; }

    public bool? CourseCurrentStatusInd { get; set; }

    public bool? CourseDroppedStatusInd { get; set; }

    public bool? CourseFutureStatusInd { get; set; }

    public bool? CourseLeaveOfAbsenceStatusInd { get; set; }

    public bool? CourseScheduledStatusInd { get; set; }

    public bool? CourseRetakeInd { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Campus? Campus { get; set; }

    public virtual ClassSection? ClassSection { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Enrollment? Enrollment { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual StatusLookUp? StudentCourseStatus { get; set; }

    public virtual Term? Term { get; set; }
}
