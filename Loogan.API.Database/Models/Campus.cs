using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Campus
{
    public int CampusId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public string? Email { get; set; }

    public string? FaxNumber { get; set; }

    public string? Phone { get; set; }

    public string? Url { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<CampusGroupMapping> CampusGroupMappings { get; set; } = new List<CampusGroupMapping>();

    public virtual ICollection<ClassSection> ClassSections { get; set; } = new List<ClassSection>();

    public virtual Country? Country { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
