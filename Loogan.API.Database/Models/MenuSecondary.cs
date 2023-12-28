using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MenuSecondary
{
    public int SecondaryMenuId { get; set; }

    public int PrimaryMenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public int LanguageId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Language Language { get; set; } = null!;

    public virtual MenuPrimary PrimaryMenu { get; set; } = null!;
}
