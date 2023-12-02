using System;
using System.Collections.Generic;

namespace Loogan.API.Models.Models;

public class UserType
{
    public int UserTypeId { get; set; }

    public string UserType1 { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }
}
