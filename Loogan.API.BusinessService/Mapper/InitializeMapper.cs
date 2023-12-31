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
        var map = CreateMap<User, UserModel>();
        map.ForAllMembers(opt => opt.Ignore());
        map.ForMember(dest => dest.AdditionalName, opt => opt.MapFrom(src => src.AdditionalName))
            .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
            .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
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
            .ForMember(dest => dest.UserTypeId, opt => opt.MapFrom(src => src.UserTypeId)).ReverseMap();

        var mapuser = CreateMap<UserModel, User>();
        map.ForMember(dest => dest.AdditionalName, opt => opt.MapFrom(src => src.AdditionalName))
            .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
            .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
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
            .ForMember(dest => dest.UserTypeId, opt => opt.MapFrom(src => src.UserTypeId)).ReverseMap();

        var staffMap = CreateMap<Staff, StaffModel>();
        staffMap.ForAllMembers(opt => opt.Ignore());
        staffMap.ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.StaffName, opt => opt.MapFrom(src => src.StaffName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code)).ReverseMap();

        var studentMap = CreateMap<Student, StudentModel>();
        studentMap.ForAllMembers(opt => opt.Ignore());
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
            .ForMember(dest => dest.VeteranInd, opt => opt.MapFrom(src => src.VeteranInd)).ReverseMap();

        var courseMap = CreateMap<Course, CourseModel>();
        courseMap.ForAllMembers(opt => opt.Ignore());
        courseMap.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
            .ForMember(dest => dest.CourseGroupId, opt => opt.MapFrom(src => src.CourseTypeSourceId))
            .ForMember(dest => dest.CourseDesc, opt => opt.MapFrom(src => src.CourseDesc))
            .ForMember(dest => dest.CreditHours, opt => opt.MapFrom(src => src.CreditHours))
            .ForMember(dest => dest.Credits, opt => opt.MapFrom(src => src.Credits)).ReverseMap();

       
        
    }
}

