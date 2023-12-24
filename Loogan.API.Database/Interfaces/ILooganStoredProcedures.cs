using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
namespace Loogan.API.Database.Interfaces;

public interface ILooganStoredProcedures
{
    public Task<UserLoginModel?> GetUserLoginDetails(string userName, string password);
    public Task<List<PagingUserModel>?> GetAllUser();
    public Task<UserModel?> GetUser(int userId);
    public Task<ForgotPswdModel> GetUserEmailByUserName(string userName);
    public Task<int?> CreateUser(User userObj);
    public Task<int?> UpdateUser(User userObj);
}

