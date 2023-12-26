using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class School
{
    public int SchoolId { get; set; }

    public int? CampusGroupId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public int? SchoolStatusId { get; set; }

    public int? SchoolCategoryId { get; set; }

    public int? StatusHierarchy { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime ModifyDate { get; set; }

    public virtual StatusLookUp School1 { get; set; } = null!;

    public virtual CourseRelatedLookUp SchoolNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
