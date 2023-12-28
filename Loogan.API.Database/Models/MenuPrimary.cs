using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MenuPrimary
{
    public int PrimaryMenuId { get; set; }

    public string MenuCode { get; set; } = null!;

    public string? MenuUrl { get; set; }

    public string? MenuIcon { get; set; }

    public int? SequenceOrder { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<MenuRoleMapping> MenuRoleMappings { get; set; } = new List<MenuRoleMapping>();

    public virtual ICollection<MenuSecondary> MenuSecondaries { get; set; } = new List<MenuSecondary>();
}
