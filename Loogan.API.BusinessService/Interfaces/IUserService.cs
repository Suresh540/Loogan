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
    public Task<UserModel?> GetUserDetailsService(UserQuery query);
}

