using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class State
{
    public int StateId { get; set; }

    public int CountryId { get; set; }

    public string StateName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int? LanguageId { get; set; }

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();

    public virtual Language? Language { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual Country StateNavigation { get; set; } = null!;

    public virtual Student? Student { get; set; }
}
