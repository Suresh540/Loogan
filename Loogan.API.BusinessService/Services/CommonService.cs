using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Database.Services;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Services
{
    public class CommonService : ICommonService
    {
        private readonly ILooganCommon _LooganCommon;
        private readonly IMapper _mapper;

        public CommonService(ILooganCommon LooganCommon, IMapper mapper)
        {
            _LooganCommon = LooganCommon;
            _mapper = mapper;
        }
        public async Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType,int languageId)
        {
            var masterLookUpValues = await _LooganCommon.GetMaserLookUpValues(lookUpType, languageId);
            return masterLookUpValues;
        }

        public async Task<List<DropDownListModel>?> GetCoursRelatedLookUp(string lookUpType, int languageId)
        {
            var masterLookUpValues = await _LooganCommon.GetCoursRelatedLookUp(lookUpType, languageId);
            return masterLookUpValues;
        }

        public async Task<List<DropDownListModel>?> GetCountryList(int languageId)
        {
            var countryList = await _LooganCommon.GetCountryList(languageId);
            return countryList;
        }

        public async Task<List<DropDownListModel>?> GetStatesByCountryId(int languageId, int countryId)
        {
            var stateList = await _LooganCommon.GetStatesByCountryId(languageId,countryId);
            return stateList;
        }

        public async Task<List<EmailTemplatesModel>?> GetAllEmailTemplates()
        {
            var emaiTemplateList = await _LooganCommon.GetAllEmailTemplates();
            return emaiTemplateList;
        }

        public async Task<List<DropDownListModel>?> GetMasterEmailTemplates(int languageId)
        {
            var masterEmailTemplatesList = await _LooganCommon.GetMasterEmailTemplates(languageId);
            return masterEmailTemplatesList;
        }

        public async Task<int?> CreateEmailTemplates(EmailTemplatesModel emailObj)
        {
            var emailTemplateObj = _mapper.Map<EmailTemplate>(emailObj);
            var result = await _LooganCommon.CreateEmailTemplates(emailTemplateObj);
            return result;
        }

        public async Task<int?> UpdateEmailTemplates(EmailTemplatesModel emailObj)
        {
            var emailTemplateObj = _mapper.Map<EmailTemplate>(emailObj);
            var result = await _LooganCommon.UpdateEmailTemplates(emailTemplateObj);
            return result;
        }

        public async Task<int?> DeleteEmailTemplates(int emailTemplateId)
        {
            var result = await _LooganCommon.DeleteEmailTemplates(emailTemplateId);
            return result;
        }

        public async Task<List<EmailTemplatesModel>?> GetEmailTemplateByMasterId(int masterEmailTemplateId)
        {
            var emaiTemplateList = await _LooganCommon.GetEmailTemplateByMasterId(masterEmailTemplateId);
            return emaiTemplateList;
        }

        
    }
}
