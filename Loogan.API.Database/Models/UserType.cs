﻿using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string UserType1 { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}