using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class CourseRelatedLookUp
{
    public int CourseRelatedLookUpId { get; set; }

    public string? CourseRelatedLookUpType { get; set; }

    public string? CourseRelatedLookUpValue { get; set; }

    public int? LanguageId { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AreaOfStudy> AreaOfStudyAreaStudyTypes { get; set; } = new List<AreaOfStudy>();

    public virtual ICollection<AreaOfStudy> AreaOfStudyCipcode2010s { get; set; } = new List<AreaOfStudy>();

    public virtual ICollection<AreaOfStudy> AreaOfStudyCipcode2020s { get; set; } = new List<AreaOfStudy>();

    public virtual ICollection<AreaOfStudyCourseMapping> AreaOfStudyCourseMappingCourseCatalogs { get; set; } = new List<AreaOfStudyCourseMapping>();

    public virtual ICollection<AreaOfStudyCourseMapping> AreaOfStudyCourseMappingCourseCategories { get; set; } = new List<AreaOfStudyCourseMapping>();

    public virtual ICollection<AreaOfStudyCourseMapping> AreaOfStudyCourseMappingCoursePools { get; set; } = new List<AreaOfStudyCourseMapping>();

    public virtual ICollection<ClassSection> ClassSectionAttendanceTypes { get; set; } = new List<ClassSection>();

    public virtual ICollection<ClassSection> ClassSectionDeliveryMethods { get; set; } = new List<ClassSection>();

    public virtual ICollection<Course> CourseCourseLevelSources { get; set; } = new List<Course>();

    public virtual ICollection<Course> CourseCourseTypeSources { get; set; } = new List<Course>();

    public virtual ICollection<PreviousEducation> PreviousEducationEducationLevels { get; set; } = new List<PreviousEducation>();

    public virtual ICollection<PreviousEducation> PreviousEducationGradeLevels { get; set; } = new List<PreviousEducation>();

    public virtual ICollection<ProgramAreaOfStudyMapping> ProgramAreaOfStudyMappings { get; set; } = new List<ProgramAreaOfStudyMapping>();

    public virtual ICollection<Program> ProgramCipcode2010Navigations { get; set; } = new List<Program>();

    public virtual ICollection<Program> ProgramCipcode2020Navigations { get; set; } = new List<Program>();

    public virtual ICollection<ProgramCourseMapping> ProgramCourseMappingCourseCatalogs { get; set; } = new List<ProgramCourseMapping>();

    public virtual ICollection<ProgramCourseMapping> ProgramCourseMappingCourseCategories { get; set; } = new List<ProgramCourseMapping>();

    public virtual ICollection<ProgramCourseMapping> ProgramCourseMappingCoursePools { get; set; } = new List<ProgramCourseMapping>();

    public virtual ICollection<Program> ProgramDegrees { get; set; } = new List<Program>();

    public virtual ICollection<Program> ProgramVersions { get; set; } = new List<Program>();

    public virtual School? School { get; set; }

    public virtual ICollection<Student> StudentEducationalLevels { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentEthnicGroups { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentProgramGroups { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentProspectCategories { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentProspectTypes { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentProspects { get; set; } = new List<Student>();

    public virtual Term? Term { get; set; }
}
