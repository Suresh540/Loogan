using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
namespace Loogan.API.Database.Interfaces;

public interface ILooganStoredProcedures
{
    public Task<UserLoginModel?> GetUserLoginDetails(string userName, string password);
    public Task<List<UserModel>?> GetAllUser();
    public Task<UserModel?> GetUser(int userId);
    public Task<int?> CreateUser(User userObj);
    public Task<int?> UpdateUser(User userObj);
}

