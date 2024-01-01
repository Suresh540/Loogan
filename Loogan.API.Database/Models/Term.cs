using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Term
{
    public int TermId { get; set; }

    public int? CampusGroupId { get; set; }

    public int? ShiftId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? TermCategoryId { get; set; }

    public int? TermSeasonId { get; set; }

    public bool? MajorTermInd { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<ClassSection> ClassSections { get; set; } = new List<ClassSection>();

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();

    public virtual CourseRelatedLookUp TermNavigation { get; set; } = null!;
}
