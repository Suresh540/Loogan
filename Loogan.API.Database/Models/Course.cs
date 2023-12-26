using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public int? CampusGroupId { get; set; }

    public string? CourseCode { get; set; }

    public string CourseName { get; set; } = null!;

    public string? CourseDesc { get; set; }

    public int? CourseLevelSourceId { get; set; }

    public int CourseTypeSourceId { get; set; }

    public double? Credits { get; set; }

    public double? CreditHours { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<AreaOfStudyCourseMapping> AreaOfStudyCourseMappings { get; set; } = new List<AreaOfStudyCourseMapping>();

    public virtual ICollection<ClassSection> ClassSections { get; set; } = new List<ClassSection>();

    public virtual CourseRelatedLookUp? CourseLevelSource { get; set; }

    public virtual CourseRelatedLookUp CourseTypeSource { get; set; } = null!;

    public virtual ICollection<ProgramCourseMapping> ProgramCourseMappings { get; set; } = new List<ProgramCourseMapping>();

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();
}
