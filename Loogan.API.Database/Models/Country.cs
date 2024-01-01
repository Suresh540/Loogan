using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int? LanguageId { get; set; }

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();

    public virtual Language? Language { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual State? State { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
