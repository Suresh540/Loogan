using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class ProgramCourseMapping
{
    public int ProgramCourseMappingId { get; set; }

    public int CourseId { get; set; }

    public int ProgramId { get; set; }

    public int? CourseCatalogId { get; set; }

    public int? CourseCategoryId { get; set; }

    public int? CoursePoolId { get; set; }

    public string? CoursePoolType { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual CourseRelatedLookUp? CourseCatalog { get; set; }

    public virtual CourseRelatedLookUp? CourseCategory { get; set; }

    public virtual CourseRelatedLookUp? CoursePool { get; set; }

    public virtual Program Program { get; set; } = null!;
}
