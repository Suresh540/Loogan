using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class ClassPeriodSchedule
{
    public int ClassPeriodScheduleId { get; set; }

    public int? ClassSectionId { get; set; }

    public string? Name { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? ScheduleDate { get; set; }

    public int? ClassScheduleStatusId { get; set; }

    public int? ClassDurationMinutes { get; set; }

    public int? StaffId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual StatusLookUp? ClassScheduleStatus { get; set; }

    public virtual ClassSection? ClassSection { get; set; }

    public virtual Staff? Staff { get; set; }
}
