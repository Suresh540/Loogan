using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.BusinessService.Interfaces
{
    public interface ICommonService
    {
        public Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType, int languageId);

        public Task<List<DropDownListModel>?> GetCoursRelatedLookUp(string lookUpType, int languageId);

        public Task<List<DropDownListModel>?> GetCountryList(int languageId);

        public Task<List<DropDownListModel>?> GetStatesByCountryId(int languageId,int countryId);

        public Task<List<DropDownListModel>?> GetMasterEmailTemplates(int languageId);

        public Task<int?> CreateEmailTemplates(EmailTemplatesModel emailObj);

        public Task<int?> UpdateEmailTemplates(EmailTemplatesModel emailObj);

        public Task<int?> DeleteEmailTemplates(int emailTemplateId);
    }
}
