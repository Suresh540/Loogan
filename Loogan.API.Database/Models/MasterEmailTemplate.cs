using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MasterEmailTemplate
{
    public int MasterEmailTemplateId { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
