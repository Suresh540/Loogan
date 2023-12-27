using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
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
    }
}
