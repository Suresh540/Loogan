using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class StudentGradeMapping
{
    public int GradeStudentMappingId { get; set; }

    public int StudentCourseMappingId { get; set; }

    public int MasterGradeId { get; set; }

    public string? Remarks { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual MasterGrade MasterGrade { get; set; } = null!;

    public virtual StudentCourseMapping StudentCourseMapping { get; set; } = null!;
}
