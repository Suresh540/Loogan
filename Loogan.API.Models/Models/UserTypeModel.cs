using System;
using System.Collections.Generic;

namespace Loogan.API.Models.Models;

public class UserTypeModel
{
    public int UserTypeId { get; set; }

    public string UserType { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsDeleted { get; set; }
}
