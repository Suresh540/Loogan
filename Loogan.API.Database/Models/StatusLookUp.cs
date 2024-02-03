using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class StatusLookUp
{
    public int StatusLookUpId { get; set; }

    public string StatusLookUpType { get; set; } = null!;

    public string StatusLookUpValue { get; set; } = null!;

    public int? LanguageId { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ClassPeriodSchedule> ClassPeriodSchedules { get; set; } = new List<ClassPeriodSchedule>();

    public virtual School? School { get; set; }

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();
}
