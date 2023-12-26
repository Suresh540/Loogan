using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Test
{
    public int TestId { get; set; }

    public int? TestParentId { get; set; }

    public int CampusGroupId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime ModifyDate { get; set; }

    public virtual CampusGroup TestNavigation { get; set; } = null!;

    public virtual ICollection<TestScore> TestScores { get; set; } = new List<TestScore>();
}
