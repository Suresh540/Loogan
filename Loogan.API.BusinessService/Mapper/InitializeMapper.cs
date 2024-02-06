using AutoMapper;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Loogan.API.BusinessService.Mapper;

public class InitializeMapper : Profile
{
    public InitializeMapper()
    {
        var map = CreateMap<UserModel, User>();
        map.ForMember(dest => dest.AdditionalName, opt => opt.MapFrom(src => src.AdditionalName))
            .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
            .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Gender, opt => opt.Ignore())
            .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Suffix))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
            .ForMember(dest => dest.EducationLevel, opt => opt.MapFrom(src => src.EducationLevel))
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.Fax))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.PreFix, opt => opt.MapFrom(src => src.PreFix))
            .ForMember(dest => dest.ProfilePicPath, opt => opt.MapFrom(src => src.ProfilePicPath))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.LanguageId))
            .ForMember(dest => dest.UserTypeId, opt => opt.MapFrom(src => src.UserTypeId))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate)).ReverseMap();

        var staffMap = CreateMap<Staff, StaffModel>();
        staffMap.ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.StaffName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate))
            .ReverseMap();

        var studentMap = CreateMap<Student, StudentModel>();
        studentMap.ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.AdminssionRepresentativeId, opt => opt.MapFrom(src => src.AdminssionRepresentativeId))
            .ForMember(dest => dest.CampusId, opt => opt.MapFrom(src => src.CampusId))
            .ForMember(dest => dest.ProgramId, opt => opt.MapFrom(src => src.ProgramId))
            .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.StudentNumber))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Suffix, opt => opt.MapFrom(src => src.Suffix))
            .ForMember(dest => dest.MaidenName, opt => opt.MapFrom(src => src.MaidenName))
            .ForMember(dest => dest.NickName, opt => opt.MapFrom(src => src.NickName))
            .ForMember(dest => dest.MiddleInitial, opt => opt.MapFrom(src => src.MiddleInitial))
            .ForMember(dest => dest.CitizenShipStatusId, opt => opt.MapFrom(src => src.CitizenShipStatusId))
            .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
            .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.StateId))
            .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.StateId))
            .ForMember(dest => dest.EducationalLevelId, opt => opt.MapFrom(src => src.EducationalLevelId))
            .ForMember(dest => dest.EthnicGroupId, opt => opt.MapFrom(src => src.EthnicGroupId))
            .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
            .ForMember(dest => dest.NationalityId, opt => opt.MapFrom(src => src.NationalityId))
            .ForMember(dest => dest.ProgramGroupId, opt => opt.MapFrom(src => src.EducationalLevelId))
            .ForMember(dest => dest.ProspectId, opt => opt.MapFrom(src => src.ProspectId))
            .ForMember(dest => dest.ProspectCategoryId, opt => opt.MapFrom(src => src.ProspectCategoryId))
            .ForMember(dest => dest.ProspectTypeId, opt => opt.MapFrom(src => src.ProspectTypeId))
            .ForMember(dest => dest.OriginalExceptedStartDate, opt => opt.MapFrom(src => src.OriginalExceptedStartDate))
            .ForMember(dest => dest.OriginalStartDate, opt => opt.MapFrom(src => src.OriginalStartDate))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.LastActivityDate, opt => opt.MapFrom(src => src.LastActivityDate))
            .ForMember(dest => dest.HispanicInd, opt => opt.MapFrom(src => src.HispanicInd))
            .ForMember(dest => dest.VeteranInd, opt => opt.MapFrom(src => src.VeteranInd))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate))
            .ReverseMap();

        var courseMap = CreateMap<Course, CourseModel>();
        courseMap.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
            .ForMember(dest => dest.CourseGroupId, opt => opt.MapFrom(src => src.CourseTypeSourceId))
            .ForMember(dest => dest.CourseDesc, opt => opt.MapFrom(src => src.CourseDesc))
            .ForMember(dest => dest.CreditHours, opt => opt.MapFrom(src => src.CreditHours))
            .ForMember(dest => dest.Credits, opt => opt.MapFrom(src => src.Credits)).ReverseMap();

        var StudentCourseMappingMap = CreateMap<StudentCourseMapping, StudentCourseMappingModel>();
        StudentCourseMappingMap.ForMember(dest => dest.StudentCourseMappingId, opt => opt.MapFrom(src => src.StudentCourseMappingId))
            .ForMember(dest => dest.CampusId, opt => opt.MapFrom(src => src.CampusId))
            .ForMember(dest => dest.ClassSectionId, opt => opt.MapFrom(src => src.ClassSectionId))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.EnrollmentId, opt => opt.MapFrom(src => src.EnrollmentId))
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
            .ForMember(dest => dest.TermId, opt => opt.MapFrom(src => src.TermId))
            .ForMember(dest => dest.StudentCourseStatusId, opt => opt.MapFrom(src => src.StudentCourseStatusId))
            .ForMember(dest => dest.CourseCreditHours, opt => opt.MapFrom(src => src.CourseCreditHours))
            .ForMember(dest => dest.CourseCredit, opt => opt.MapFrom(src => src.CourseCredit))
            .ForMember(dest => dest.MinusAbsent, opt => opt.MapFrom(src => src.MinusAbsent))
            .ForMember(dest => dest.MinusAttended, opt => opt.MapFrom(src => src.MinusAttended))
            .ForMember(dest => dest.NumericGradeObtained, opt => opt.MapFrom(src => src.NumericGradeObtained))
            .ForMember(dest => dest.TotalGradeAttempted, opt => opt.MapFrom(src => src.TotalGradeAttempted))
            .ForMember(dest => dest.TotalCreditsEarned, opt => opt.MapFrom(src => src.TotalCreditsEarned))
            .ForMember(dest => dest.TotalHoursAttempted, opt => opt.MapFrom(src => src.TotalHoursAttempted))
            .ForMember(dest => dest.TotalHoursEarned, opt => opt.MapFrom(src => src.TotalHoursEarned))
            .ForMember(dest => dest.GradeLetterCodeObtained, opt => opt.MapFrom(src => src.GradeLetterCodeObtained))
            .ForMember(dest => dest.GradeNote, opt => opt.MapFrom(src => src.GradeNote))
            .ForMember(dest => dest.CourseCompletedDate, opt => opt.MapFrom(src => src.CourseCompletedDate))
            .ForMember(dest => dest.CourseDropDate, opt => opt.MapFrom(src => src.CourseDropDate))
            .ForMember(dest => dest.CourseLastAttendedDate, opt => opt.MapFrom(src => src.CourseLastAttendedDate))
            .ForMember(dest => dest.CourseRegisteredDate, opt => opt.MapFrom(src => src.CourseRegisteredDate))
            .ForMember(dest => dest.CourseStartDate, opt => opt.MapFrom(src => src.CourseStartDate))
            .ForMember(dest => dest.ExpectedCourseEndDate, opt => opt.MapFrom(src => src.ExpectedCourseEndDate))
            .ForMember(dest => dest.GradePostedDate, opt => opt.MapFrom(src => src.GradePostedDate))
            .ForMember(dest => dest.CourseCompletedStatusInd, opt => opt.MapFrom(src => src.CourseCompletedStatusInd))
            .ForMember(dest => dest.CourseCurrentStatusInd, opt => opt.MapFrom(src => src.CourseCurrentStatusInd))
            .ForMember(dest => dest.CourseDroppedStatusInd, opt => opt.MapFrom(src => src.CourseDroppedStatusInd))
            .ForMember(dest => dest.CourseFutureStatusInd, opt => opt.MapFrom(src => src.CourseFutureStatusInd))
            .ForMember(dest => dest.CourseLeaveOfAbsenceStatusInd, opt => opt.MapFrom(src => src.CourseLeaveOfAbsenceStatusInd))
            .ForMember(dest => dest.CourseScheduledStatusInd, opt => opt.MapFrom(src => src.CourseScheduledStatusInd))
            .ForMember(dest => dest.CourseRetakeInd, opt => opt.MapFrom(src => src.CourseRetakeInd))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate))
            .ReverseMap();


        var emailTemplateMap = CreateMap<EmailTemplate, EmailTemplatesModel>();
        emailTemplateMap.ForMember(dest => dest.EmailTemplateId, opt => opt.MapFrom(src => src.EmailTemplateId))
            .ForMember(dest => dest.MasterEmailTemplateId, opt => opt.MapFrom(src => src.MasterEmailTemplateId))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate)).ReverseMap();

        var institutionMap = CreateMap<Institution, InstitutionModel>();
        institutionMap.ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.InstitutionId))
            .ForMember(dest => dest.InstitutionName, opt => opt.MapFrom(src => src.InstitutionName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
            .ForMember(dest => dest.AdditionalComments, opt => opt.MapFrom(src => src.AdditionalComments))
            .ForMember(dest => dest.Mission, opt => opt.MapFrom(src => src.Mission))
            .ForMember(dest => dest.Vision, opt => opt.MapFrom(src => src.Vision))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Website, opt => opt.MapFrom(src => src.Website))
            .ForMember(dest => dest.InstitutionImageUrl, opt => opt.MapFrom(src => src.InstitutionImageUrl))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate)).ReverseMap();

        var institutionNewsMap = CreateMap<InstitutionNews, InstitutionNewsModel>();
        institutionNewsMap.ForMember(dest => dest.InstitutionNewsId, opt => opt.MapFrom(src => src.InstitutionNewsId))
            .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.InstitutionId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.News, opt => opt.MapFrom(src => src.News))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate)).ReverseMap();

        var institutionAnnouncementMap = CreateMap<InstitutionAnnouncement, InstitutionAnnouncementModel>();
        institutionAnnouncementMap.ForMember(dest => dest.InstitutionAnnouncementId, opt => opt.MapFrom(src => src.InstitutionAnnouncementId))
            .ForMember(dest => dest.InstitutionId, opt => opt.MapFrom(src => src.InstitutionId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Announcement, opt => opt.MapFrom(src => src.Announcement))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.ModifyBy, opt => opt.MapFrom(src => src.ModifyBy))
            .ForMember(dest => dest.ModifyDate, opt => opt.MapFrom(src => src.ModifyDate)).ReverseMap();
    }
}

