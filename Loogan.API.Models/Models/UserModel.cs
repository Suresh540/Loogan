namespace Loogan.API.Models.Models;

public class UserModel
{
    public int UserId { get; set; }

    public int UserTypeId { get; set; }

    public string? ProfilePicPath { get; set; }

    public string? PreFix { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Suffix { get; set; }

    public string? AdditionalName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

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

    public string? UserName { get; set; }

    public string? UserTypeName { get; set; }

    public string? Description { get; set; }

    public bool? IsDeletedType { get; set; }
}

