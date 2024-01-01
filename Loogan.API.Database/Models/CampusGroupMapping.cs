using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class CampusGroupMapping
{
    public int CampusGroupMappingId { get; set; }

    public int? CampusGroupId { get; set; }

    public int? CampusId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Campus? Campus { get; set; }

    public virtual CampusGroup? CampusGroup { get; set; }
}
