using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Language
{
    public int LanguageId { get; set; }

    public string LanguageName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual ICollection<MenuSecondary> MenuSecondaries { get; set; } = new List<MenuSecondary>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
