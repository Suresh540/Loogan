﻿using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MasterLookUp
{
    public int LookUpId { get; set; }

    public string LookUpType { get; set; } = null!;

    public string LookUpValue { get; set; } = null!;

    public int? LanguageId { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Student> StudentCitizenShipStatuses { get; set; } = new List<Student>();

    public virtual ICollection<Student> StudentEthnicGroups { get; set; } = new List<Student>();

    public virtual Student? StudentStudentNavigation { get; set; }

    public virtual ICollection<User> UserGenders { get; set; } = new List<User>();

    public virtual ICollection<User> UserLanguages { get; set; } = new List<User>();
}
