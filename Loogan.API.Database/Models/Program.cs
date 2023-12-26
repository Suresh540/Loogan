using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Program
{
    public int ProgramId { get; set; }

    public int? CampusGroupId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? VersionId { get; set; }

    public int? DegreeId { get; set; }

    public int? Cipcode2010 { get; set; }

    public int? Cipcode2020 { get; set; }

    public string? VersionCreditSystem { get; set; }

    public bool? DegreeProgramInd { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime ModifyDate { get; set; }

    public virtual CourseRelatedLookUp? Cipcode2010Navigation { get; set; }

    public virtual CourseRelatedLookUp? Cipcode2020Navigation { get; set; }

    public virtual CourseRelatedLookUp? Degree { get; set; }

    public virtual ICollection<ProgramAreaOfStudyMapping> ProgramAreaOfStudyMappings { get; set; } = new List<ProgramAreaOfStudyMapping>();

    public virtual ICollection<ProgramCourseMapping> ProgramCourseMappings { get; set; } = new List<ProgramCourseMapping>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual CourseRelatedLookUp? Version { get; set; }
}
