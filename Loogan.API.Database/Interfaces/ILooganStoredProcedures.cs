using Loogan.API.Models.Models;
namespace Loogan.API.Database.Interfaces;

public interface ILooganStoredProcedures
{
    public Task<UserLoginModel?> GetUserLoginDetails(string userName, string password);
    public Task<UserModel?> GetUser(int userId);
}

