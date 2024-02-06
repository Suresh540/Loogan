using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class InstitutionAnnouncement
{
    public int InstitutionAnnouncementId { get; set; }

    public int InstitutionId { get; set; }

    public string? Title { get; set; }

    public string Announcement { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Institution Institution { get; set; } = null!;
}
