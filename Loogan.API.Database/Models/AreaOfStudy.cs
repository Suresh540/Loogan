using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class AreaOfStudy
{
    public int AreaStudyId { get; set; }

    public int? CampusGroupId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? AreaStudyTypeId { get; set; }

    public int? Cipcode2010Id { get; set; }

    public int? Cipcode2020Id { get; set; }

    public double? MinimumCumulativeGpa { get; set; }

    public double? AreaOfStudyCreditsRequired { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<AreaOfStudyCourseMapping> AreaOfStudyCourseMappings { get; set; } = new List<AreaOfStudyCourseMapping>();

    public virtual CampusGroup AreaStudy { get; set; } = null!;

    public virtual CourseRelatedLookUp? AreaStudyType { get; set; }

    public virtual CourseRelatedLookUp? Cipcode2010 { get; set; }

    public virtual CourseRelatedLookUp? Cipcode2020 { get; set; }

    public virtual ICollection<EnrollmentAreasOfStudyMapping> EnrollmentAreasOfStudyMappings { get; set; } = new List<EnrollmentAreasOfStudyMapping>();

    public virtual ICollection<ProgramAreaOfStudyMapping> ProgramAreaOfStudyMappings { get; set; } = new List<ProgramAreaOfStudyMapping>();
}
