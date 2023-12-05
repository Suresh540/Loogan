﻿using Loogan.API.Database.Interfaces;
using Loogan.API.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Loogan.API.Database.Models
{
    public class LooganStoredProcedures(string? connectionString) : ILooganStoredProcedures
    {
        public async Task<UserLoginModel?> GetUserLoginDetails(string userName, string password)
        {
            UserLoginModel? user = null;
            using (var context = new LooganContext(connectionString))
            {
                var query = context.Database.SqlQuery<UserLoginModel>($"Get_UserLoginDetails {userName}, {password}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user = item;
                }
            }
            return user;
        }
        public async Task<UserModel?> GetUser(int userId)
        {
            UserModel? user = null;
            using (var context = new LooganContext(connectionString))
            {
                var query = context.Database.SqlQuery<UserModel>($"Get_UserDetails {userId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user = item;
                }
            }
            return user;
        }
    }
}