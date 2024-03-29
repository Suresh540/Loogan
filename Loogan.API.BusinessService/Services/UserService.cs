﻿using AutoMapper;
using Loogan.API.BusinessService.Interfaces;
using Loogan.API.Database.Interfaces;
using Loogan.API.Database.Models;
using Loogan.API.Database.Services;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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

    public async Task<List<PagingUserModel>?> GetAllUserDetailsService()
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

    public async Task<int?> DeleteUser(int userId)
    {
        var result = await _storedProcedures.DeleteUser(userId);
        return result;
    }

    /// <summary>
    /// Written by Suresh Kalaga
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async Task<UserModel> GetUserDetailsUsingEmailAddress(string email)
    {
        var user = await _storedProcedures.GetUserDetailsUsingEmailAddress(email);
        UserModel userModel = _mapper.Map<User, UserModel>(user);
        return userModel;
    }

    public async Task<bool> IsUserNameExist(string userName,int userId)
    {
        var isUserNameExist = await _storedProcedures.IsUserNameExist(userName,userId);
        return isUserNameExist;
    }

    public async Task<bool> IsUserEmailExist(string userEmail, int userId)
    {
        var isUserNameExist = await _storedProcedures.IsUserEmailExist(userEmail, userId);
        return isUserNameExist;
    }

    public async Task<List<UserModel>> GetUsersByUserType(int userTypeId)
    {
        var getUsers = await _storedProcedures.GetUsersByUserType(userTypeId);
        var userObj = _mapper.Map<List<UserModel>>(getUsers);
        return userObj;
    }

    public async Task<List<InstitutionUserModel>> GetInstitutionUserList(int institutionId, int userTypeId)
    {
        var institutionUserList = await _storedProcedures.GetInstitutionUserList(institutionId, userTypeId);
        return institutionUserList;
    }

    public async Task<int> SaveInstitutionUsers(List<SaveInstitutionUserRequest> request)
    {
        var listUsers = await _storedProcedures.SaveInstitutionUsers(request);
        return listUsers;
    }
}

