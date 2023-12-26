using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class CampusGroup
{
    public int CampusGroupId { get; set; }

    public string CampusName { get; set; } = null!;

    public string? CampusDescription { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual AreaOfStudy? AreaOfStudy { get; set; }

    public virtual ICollection<CampusGroupMapping> CampusGroupMappings { get; set; } = new List<CampusGroupMapping>();

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual Test? Test { get; set; }
}
