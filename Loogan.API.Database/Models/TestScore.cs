using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class TestScore
{
    public int TestScoreId { get; set; }

    public int EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? TestScoreParentId { get; set; }

    public DateTime? ScheduleExamDate { get; set; }

    public DateTime? ExamTakeDate { get; set; }

    public string? TestScore1 { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual ICollection<TestScore> InverseTestScoreParent { get; set; } = new List<TestScore>();

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }

    public virtual TestScore? TestScoreParent { get; set; }
}
