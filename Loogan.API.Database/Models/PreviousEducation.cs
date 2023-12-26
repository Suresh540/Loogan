using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class PreviousEducation
{
    public int PreviousEducationId { get; set; }

    public int? OrganizationId { get; set; }

    public int? StudentId { get; set; }

    public string? Major { get; set; }

    public string? StudentRank { get; set; }

    public double? Gpa { get; set; }

    public int? DegreeId { get; set; }

    public int? EducationLevelId { get; set; }

    public int? GradeLevelId { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public DateTime? LastAttendedDate { get; set; }

    public DateTime? GraduationDate { get; set; }

    public bool? GraduationCompletedInd { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual CourseRelatedLookUp? EducationLevel { get; set; }

    public virtual CourseRelatedLookUp? GradeLevel { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual Student? Student { get; set; }
}
