using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class InstitutionUserMapping
{
    public int InstitutionUserMappingId { get; set; }

    public int InstitutionId { get; set; }

    public int UserId { get; set; }

    public int UserTypeId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Institution Institution { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserType UserType { get; set; } = null!;
}
