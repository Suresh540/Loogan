using Loogan.API.Database.Interfaces;
using Loogan.API.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Loogan.API.Database.Models
{
    public class LooganStoredProcedures : ILooganStoredProcedures
    {
        private readonly string _connectionString;
        public LooganStoredProcedures(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<UserModel?> GetUser(string userName, string password)
        {
            UserModel? user = null;
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<UserModel>($"Get_UserDetails {userName}, {password}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user = item;
                }
            }
            return user;
        }
    }
}
