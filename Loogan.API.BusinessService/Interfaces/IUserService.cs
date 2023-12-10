using Loogan.API.Database.Models;
using Loogan.API.Models.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Loogan.API.BusinessService.Interfaces;

public interface IUserService
{
    public Task<UserLoginModel?> GetUserLoginDetailsService(UserQuery query);

    public Task<ForgotPswdModel> GetUserEmailByUserName(string userName);
    public Task<List<UserModel>?> GetAllUserDetailsService();
    public Task<UserModel?> GetUserDetailsService(int userId);
    public Task<int?> CreateUser(UserModel userModelObj);
    public Task<int?> UpdateUser(UserModel userModelObj);
    


}

