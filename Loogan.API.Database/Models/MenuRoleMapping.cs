using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MenuRoleMapping
{
    public int MenuRoleMappingId { get; set; }

    public int PrimaryMenuId { get; set; }

    public int RoleId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual MenuPrimary PrimaryMenu { get; set; } = null!;

    public virtual UserType Role { get; set; } = null!;
}
