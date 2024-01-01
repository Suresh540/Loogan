using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class ProgramAreaOfStudyMapping
{
    public int ProgramAreaOfStudyMappingId { get; set; }

    public int? MajorConcentrationId { get; set; }

    public int? ProgramId { get; set; }

    public int? AreaOfStudyId { get; set; }

    public int? CatalogId { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual AreaOfStudy? AreaOfStudy { get; set; }

    public virtual CourseRelatedLookUp? Catalog { get; set; }

    public virtual Program? Program { get; set; }
}
