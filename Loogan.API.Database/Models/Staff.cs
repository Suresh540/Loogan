using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? CampusGroupId { get; set; }

    public string? Code { get; set; }

    public string? StaffName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ClassPeriodSchedule> ClassPeriodSchedules { get; set; } = new List<ClassPeriodSchedule>();

    public virtual ICollection<ClassSection> ClassSections { get; set; } = new List<ClassSection>();

    public virtual User? User { get; set; }
}
