using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Models.Models;
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

        public CommonService(ILooganCommon LooganCommon)
        {
            _LooganCommon = LooganCommon;
        }
        public async Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType)
        {
            var masterLookUpValues = await _LooganCommon.GetMaserLookUpValues(lookUpType);
            return masterLookUpValues;
        }
    }
}
