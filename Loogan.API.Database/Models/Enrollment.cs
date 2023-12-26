using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? AdvisorStaffId { get; set; }

    public int? CampusId { get; set; }

    public int? ProgramId { get; set; }

    public int? SchoolId { get; set; }

    public int? ShiftId { get; set; }

    public int? StudentId { get; set; }

    public string? Description { get; set; }

    public string? EnrollmentNumber { get; set; }

    public string? Catalog { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public DateTime? DropDate { get; set; }

    public DateTime? ExceptedStartDate { get; set; }

    public DateTime? ActualStartDate { get; set; }

    public DateTime? ExceptedGraduationDate { get; set; }

    public DateTime? GraducationDate { get; set; }

    public int? EnrollmentStatusId { get; set; }

    public int? GradeLevelId { get; set; }

    public int? GradeScaleId { get; set; }

    public double? CreditsRequired { get; set; }

    public double? HoursRequired { get; set; }

    public double? TotalCreditsAttempt { get; set; }

    public double? TotalCreditsEarned { get; set; }

    public double? TotalHoursAttempt { get; set; }

    public double? TotalHoursEarned { get; set; }

    public bool? DefaultEnrollmentInd { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<EnrollmentAreasOfStudyMapping> EnrollmentAreasOfStudyMappings { get; set; } = new List<EnrollmentAreasOfStudyMapping>();

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();

    public virtual ICollection<TestScore> TestScores { get; set; } = new List<TestScore>();
}
