﻿using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
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

    public async Task<List<UserModel>?> GetAllUserDetailsService()
    {
        var userModel = await _storedProcedures.GetAllUser();
        return userModel;
    }

    public async Task<ForgotPswdModel> GetUserEmailByUserName(string userName)
    {
        var forgotPswdModel = await _storedProcedures.GetUserEmailByUserName(userName);
        return forgotPswdModel;
    }
    public async Task<UserModel?> GetUserDetailsService(int userId)
    {
        var userModel = await _storedProcedures.GetUser(userId);
        return userModel;
    }

    public async Task<int?> CreateUser(UserModel userModelObj)
    {
        var userObj = _mapper.Map<User>(userModelObj);
        var result = await _storedProcedures.CreateUser(userObj);
        return result;
    }

    public async Task<int?> UpdateUser(UserModel userModelObj)
    {
        var userObj = _mapper.Map<User>(userModelObj);
        var result = await _storedProcedures.UpdateUser(userObj);
        return result;
    }
}

