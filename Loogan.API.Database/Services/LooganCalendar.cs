using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogan.API.Database.Services
{
    public class LooganCalendar : ILooganCalendar
    {
        string? _connectionString = string.Empty;
        public LooganCalendar(IConfiguration configuration)
        {
            _connectionString = configuration?["ConnectionStrings:looganConnectionString"];
        }

        public async Task<List<CourseCalendarModel>> GetCourseCalendarDetails()
        {
            List<CourseCalendarModel>? courseCalendarMappingList = new List<CourseCalendarModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<CourseCalendarModel>($"Get_CourseCalendarDetails").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    courseCalendarMappingList.Add(item);
                }
            }
            return courseCalendarMappingList;
        }
    }
}
