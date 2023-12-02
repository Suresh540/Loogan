using Loogan.API.Models.Models;
namespace Loogan.API.Database.Interfaces;

public interface ILooganStoredProcedures
{
    public Task<UserModel?> GetUser(string userName, string password);
}

