using AutoMapper;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
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
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
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
            .ForMember(dest => dest.UserLanguage, opt => opt.MapFrom(src => src.UserLanguage))
            .ForMember(dest => dest.UserTypeId, opt => opt.MapFrom(src => src.UserTypeId)).ReverseMap();
    }
}

