using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class MasterGrade
{
    public int MasterGradeId { get; set; }

    public string? GradeCategoryName { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? PercentageRange { get; set; }

    public decimal? Percentage { get; set; }

    public int? LanguageId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual ICollection<StudentGradeMapping> StudentGradeMappings { get; set; } = new List<StudentGradeMapping>();
}
