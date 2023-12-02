using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Loogan.API.BusinessService.Services;

public class UserService : IUserService
{
    private readonly ILooganStoredProcedures _storedProcedures;
    private readonly IMapper _mapper;

    public UserService(ILooganStoredProcedures storedProcedures, IMapper mapper)
    {
        _storedProcedures = storedProcedures;
        _mapper = mapper;
    }
    public async Task<UserModel?> GetUserDetailsService(UserQuery query)
    {
        var userModel = await _storedProcedures.GetUser(query.UserName, query.Password);
        return userModel;
    }
}

