using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int? ClassPeriodScheduleId { get; set; }

    public int? ClassSectionId { get; set; }

    public int? EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? StudentCourseMappingId { get; set; }

    public DateTime? AttendanceDate { get; set; }

    public int? MinutesAttended { get; set; }

    public int? MinutesAbsent { get; set; }

    public bool? AttendedInd { get; set; }

    public bool? AbsentInd { get; set; }

    public bool? ExcuseInd { get; set; }

    public bool? MakeupInd { get; set; }

    public bool? ExternshipInd { get; set; }

    public bool? OnlineInd { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ClassPeriodSchedule? ClassPeriodSchedule { get; set; }

    public virtual ClassSection? ClassSection { get; set; }

    public virtual Enrollment? Enrollment { get; set; }

    public virtual Student? Student { get; set; }

    public virtual StudentCourseMapping? StudentCourseMapping { get; set; }
}
