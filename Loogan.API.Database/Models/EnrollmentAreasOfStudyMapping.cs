using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class EnrollmentAreasOfStudyMapping
{
    public int EnrollmentAreasOfStudyMappingId { get; set; }

    public int? EnrollmentId { get; set; }

    public int? AreaOfStudyId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual AreaOfStudy? AreaOfStudy { get; set; }

    public virtual Enrollment? Enrollment { get; set; }
}
