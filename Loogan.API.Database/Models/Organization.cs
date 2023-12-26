using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string? Type { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public string? FaxNumber { get; set; }

    public string? Phone { get; set; }

    public string? AcademicYearEnd { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<PreviousEducation> PreviousEducations { get; set; } = new List<PreviousEducation>();

    public virtual State? State { get; set; }
}
