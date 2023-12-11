using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Services
{
    public class LooganCommonService(string? connectionString) : ILooganCommon
    {
        public async Task<List<DropDownListModel>?> GetMaserLookUpValues(string lookUpType)
        {
            var masterLookUpValues = new List<DropDownListModel>();
            using (var context = new LooganContext(connectionString))
            {
                var query = context.Database.SqlQuery<DropDownListModel>($"Get_MasterLookUpValues {lookUpType}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    masterLookUpValues.Add(item);
                }
            }
            return masterLookUpValues;
        }
    }
}
