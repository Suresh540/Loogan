﻿using AutoMapper;
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

    public async Task<UserLoginModel?> GetUserLoginDetailsService(UserQuery query)
    {
        var userLoginModel = await _storedProcedures.GetUserLoginDetails(query.UserName, query.Password);
        return userLoginModel;
    }
    public async Task<UserModel?> GetUserDetailsService(int userId)
    {
        var userModel = await _storedProcedures.GetUser(userId);
        return userModel;
    }
}
