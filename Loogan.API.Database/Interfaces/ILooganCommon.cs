using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Interfaces
{
    public interface ILooganCommon
    {
        public Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType, int languageId);

        public Task<List<DropDownListModel>?> GetCoursRelatedLookUp(string lookUpType, int languageId);

        public Task<List<DropDownListModel>?> GetCountryList(int languageId);

        public Task<List<DropDownListModel>?> GetStatesByCountryId(int languageId, int countryId);
    }
}
