﻿using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Services
{
    public class LooganCommonService : ILooganCommon
    {
        string? _connectionString = string.Empty;
        public LooganCommonService(IConfiguration configuration)
        {
            _connectionString = configuration?["ConnectionStrings:looganConnectionString"];
        }

        public async Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType, int languageId)
        {
            var masterLookUpValues = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<DropDownListModel>($"Get_MasterLookUpValues {lookUpType},{languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    masterLookUpValues.Add(item);
                }
            }
            return masterLookUpValues;
        }

        public async Task<List<DropDownListModel>?> GetCoursRelatedLookUp(string lookUpType, int languageId)
        {
            var masterLookUpValues = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<DropDownListModel>($"Get_CourseRelatedLookUpValues {lookUpType},{languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    masterLookUpValues.Add(item);
                }
            }
            return masterLookUpValues;
        }

        public async Task<List<UserTypeModel>?> GetUserRoles(int languageId)
        {
            var list = new List<UserTypeModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var userType = context.UserTypes.ToList();
                if (userType.Any())
                {
                    foreach (var item in userType)
                    {
                        list.Add(new UserTypeModel() { UserTypeId = item.UserTypeId, UserType = item.UserType1, Description = item.Description });
                    }

                }
            }
            return list;
        }

        public async Task<List<DropDownListModel>?> GetCountryList(int languageId)
        {
            var list = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var country = context.Countries.Where(x => x.IsDeleted == false && x.LanguageId == languageId ).ToList();
                if (country.Any())
                {
                    foreach (var item in country)
                    {
                        list.Add(new DropDownListModel() { Id = item.CountryId, Name = item.CountryName });
                    }

                }
            }
            return list;
        }

        public async Task<List<DropDownListModel>?> GetStatesByCountryId(int languageId, int countryId)
        {
            var list = new List<DropDownListModel>();
            var states = new List<State>();
            using (var context = new LooganContext(_connectionString))
            {
                if(countryId > 0)
                    states = context.States.Where(x => x.IsDeleted == false && x.LanguageId == languageId && x.CountryId == countryId).ToList();
                else
                    states = context.States.Where(x => x.IsDeleted == false && x.LanguageId == languageId).ToList();

                if (states.Any())
                {
                    foreach (var item in states)
                    {
                        list.Add(new DropDownListModel() { Id = item.StateId, Name = item.StateName });
                    }

                }
            }
            return list;
        }

        public async Task<List<DropDownListModel>?> GetMasterEmailTemplates(int languageId)
        {
            var list = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var country = context.MasterEmailTemplates.Where(x => x.IsDeleted == false && x.LanguageId == languageId).ToList();
                if (country.Any())
                {
                    foreach (var item in country)
                    {
                        list.Add(new DropDownListModel() { Id = item.MasterEmailTemplateId, Name = item.Name });
                    }

                }
            }
            return list;
        }

        public async Task<List<EmailTemplatesModel>?> GetAllEmailTemplates()
        {
            List<EmailTemplatesModel>? emailTemplateList = new List<EmailTemplatesModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<EmailTemplatesModel>($"Get_AllEmailTemplates").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    emailTemplateList.Add(item);
                }
            }
            return emailTemplateList;
        }

        public async Task<int?> CreateEmailTemplates(EmailTemplate emailObj)
        {
            var isCreated = 0;

            if (emailObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.EmailTemplates.Add(emailObj);
                    isCreated = await context.SaveChangesAsync();
                }
            }

            return isCreated;
        }

        public async Task<int?> UpdateEmailTemplates(EmailTemplate emailObj)
        {
            var isUpdated = 0;

            if (emailObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.EmailTemplates.Update(emailObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteEmailTemplates(int emailTemplateId)
        {
            var isDeleted = 0;

            if (emailTemplateId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var emailTemplate = context.EmailTemplates.FirstOrDefault(x => x.EmailTemplateId == emailTemplateId);

                    if (emailTemplate != null)
                    {
                        emailTemplate.IsDeleted = true;
                        context.EmailTemplates.Update(emailTemplate);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }


        public async Task<List<EmailTemplatesModel>?> GetEmailTemplateByMasterId(int masterEmailTemplateId)
        {
            List<EmailTemplatesModel>? emailTemplateList = new List<EmailTemplatesModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<EmailTemplatesModel>($"Get_EmailTemplatesByMasterTemplateId {masterEmailTemplateId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    emailTemplateList.Add(item);
                }
            }
            return emailTemplateList;
        }

        public async Task<List<DropDownListModel>?> GetStatusLookUpValues(string lookUpType, int languageId)
        {
            var masterLookUpValues = new List<DropDownListModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<DropDownListModel>($"Get_StatusLookUpValues {lookUpType},{languageId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    masterLookUpValues.Add(item);
                }
            }
            return masterLookUpValues;
        }


    }
}
