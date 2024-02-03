using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class EmailTemplate
{
    public int EmailTemplateId { get; set; }

    public int MasterEmailTemplateId { get; set; }

    public string Subject { get; set; } = null!;

    public string? Body { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }
}
