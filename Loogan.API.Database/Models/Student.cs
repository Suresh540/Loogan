using System;
using System.Collections.Generic;

namespace Loogan.API.Database.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? AdminssionRepresentativeId { get; set; }

    public int? CampusId { get; set; }

    public int? ProgramId { get; set; }

    public int? SchoolId { get; set; }

    public string? StudentNumber { get; set; }

    public string? FullName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public string? Suffix { get; set; }

    public string? MaidenName { get; set; }

    public string? NickName { get; set; }

    public string? MiddleInitial { get; set; }

    public int? CitizenShipStatusId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public string? PostalCode { get; set; }

    public int? EducationalLevelId { get; set; }

    public int? EthnicGroupId { get; set; }

    public int? GenderId { get; set; }

    public bool? MaritalStatus { get; set; }

    public int? NationalityId { get; set; }

    public int? ProgramGroupId { get; set; }

    public int? ProspectId { get; set; }

    public int? ProspectCategoryId { get; set; }

    public int? ProspectTypeId { get; set; }

    public DateTime? OriginalExceptedStartDate { get; set; }

    public DateTime? OriginalStartDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public int? HispanicInd { get; set; }

    public int? VeteranInd { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifyBy { get; set; }

    public DateTime? ModifyDate { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Campus? Campus { get; set; }

    public virtual MasterLookUp? CitizenShipStatus { get; set; }

    public virtual Country? Country { get; set; }

    public virtual CourseRelatedLookUp? EducationalLevel { get; set; }

    public virtual MasterLookUp? EthnicGroup { get; set; }

    public virtual ICollection<PreviousEducation> PreviousEducations { get; set; } = new List<PreviousEducation>();

    public virtual Program? Program { get; set; }

    public virtual CourseRelatedLookUp? ProgramGroup { get; set; }

    public virtual CourseRelatedLookUp? Prospect { get; set; }

    public virtual CourseRelatedLookUp? ProspectCategory { get; set; }

    public virtual CourseRelatedLookUp? ProspectType { get; set; }

    public virtual School? School { get; set; }

    public virtual State? State { get; set; }

    public virtual ICollection<StudentCourseMapping> StudentCourseMappings { get; set; } = new List<StudentCourseMapping>();

    public virtual MasterLookUp StudentNavigation { get; set; } = null!;

    public virtual ICollection<TestScore> TestScores { get; set; } = new List<TestScore>();
}
