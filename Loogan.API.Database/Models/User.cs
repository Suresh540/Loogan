using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class User
{
    public int UserId { get; set; }

    public int UserTypeId { get; set; }

    public string? ProfilePicPath { get; set; }

    public string? PreFix { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Suffix { get; set; }

    public string? AdditionalName { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int? GenderId { get; set; }

    public string Password { get; set; } = null!;

    public string? EducationLevel { get; set; }

    public string? WebSite { get; set; }

    public string? Fax { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Company { get; set; }

    public string? JobTitle { get; set; }

    public string? Department { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public string UserName { get; set; } = null!;

    public int? LanguageId { get; set; }

    public string? MiddleName { get; set; }

    public virtual MasterLookUp? Gender { get; set; }

    public virtual ICollection<InstitutionUserMapping> InstitutionUserMappings { get; set; } = new List<InstitutionUserMapping>();

    public virtual MasterLookUp? Language { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
