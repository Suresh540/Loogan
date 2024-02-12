using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
namespace Loogan.API.Database.Interfaces;

public interface ILooganStoredProcedures
{
    public Task<UserLoginModel?> GetUserLoginDetails(string userName, string password);
    public Task<List<PagingUserModel>?> GetAllUser();
    public Task<UserModel?> GetUser(int userId);
    public Task<ForgotPswdModel> GetUserEmailByUserName(string userName);

    public Task<int?> CreateUser(User userObj);

    public Task<int?> UpdateUser(User userObj);

    public Task<User> GetUserDetailsUsingEmailAddress(string email);

    public Task<int?> DeleteUser(int userId);

    public Task<bool> IsUserNameExist(string userName, int userId);

    public Task<bool> IsUserEmailExist(string userEmail, int userId);

    public Task<List<User>> GetUsersByUserType(int userTypeId);

    public Task<List<InstitutionUserModel>> GetInstitutionUserList(int institutionId, int userTypeId);

    public Task<int> SaveInstitutionUsers(List<SaveInstitutionUserRequest> request);


}

