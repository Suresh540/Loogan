using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public bool? IsDeleted { get; set; }

    public virtual ICollection<MenuSecondary> MenuSecondaries { get; set; } = new List<MenuSecondary>();
}
