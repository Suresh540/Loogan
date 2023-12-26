using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public int? CampusGroupId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual CampusGroup? CampusGroup { get; set; }

    public virtual ICollection<ClassSection> ClassSections { get; set; } = new List<ClassSection>();
}
