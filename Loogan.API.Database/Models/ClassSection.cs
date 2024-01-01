using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class ClassSection
{
    public int ClassSectionId { get; set; }

    public int? CampusId { get; set; }

    public int? CourseId { get; set; }

    public int? PrimaryInstructionId { get; set; }

    public int? TermId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? AttendanceTypeId { get; set; }

    public int? DeliveryMethodId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? CanceledInt { get; set; }

    public int? StudentAllowedMax { get; set; }

    public int? StudentWalListMax { get; set; }

    public int? StudentRegisteredCnt { get; set; }

    public bool? PassFailCourseInd { get; set; }

    public int? ShiftId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual CourseRelatedLookUp? AttendanceType { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Campus? Campus { get; set; }

    public virtual ICollection<ClassPeriodSchedule> ClassPeriodSchedules { get; set; } = new List<ClassPeriodSchedule>();

    public virtual Course? Course { get; set; }

    public virtual CourseRelatedLookUp? DeliveryMethod { get; set; }

    public virtual Staff? PrimaryInstruction { get; set; }

    public virtual Shift? Shift { get; set; }

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();

    public virtual Term? Term { get; set; }
}
