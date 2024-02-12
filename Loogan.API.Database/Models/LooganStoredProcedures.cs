using Loogan.API.Database.Interfaces;
using Loogan.API.Models.Enums;
using Loogan.API.Models.Models;
using Loogan.API.Models.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Loogan.API.Database.Models
{
    public class LooganStoredProcedures : ILooganStoredProcedures
    {
        string? _connectionString = string.Empty;
        public LooganStoredProcedures(IConfiguration configuration)
        {
            _connectionString = configuration?["ConnectionStrings:looganConnectionString"];
        }
        public async Task<UserLoginModel?> GetUserLoginDetails(string userName, string password)
        {
            UserLoginModel? user = null;
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<UserLoginModel>($"Get_UserLoginDetails {userName}, {password}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user = item;
                }
            }
            return user;
        }

        public async Task<List<PagingUserModel>?> GetAllUser()
        {
            List<PagingUserModel>? user = new List<PagingUserModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<PagingUserModel>($"Get_AllUserDetails").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user.Add(item);
                }
            }
            return user;
        }

        public async Task<UserModel?> GetUser(int userId)
        {
            UserModel? user = null;

            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<UserModel>($"Get_UserDetails {userId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    user = item;
                }
            }
            return user;
        }

        public async Task<ForgotPswdModel> GetUserEmailByUserName(string userName)
        {
            ForgotPswdModel? model = new ForgotPswdModel();
            using (var context = new LooganContext(_connectionString))
            {
                var user = await context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
                if (user != null)
                {
                    model.EmailId = user?.EmailAddress;
                    model.Password = user?.Password;
                }
            }

            return model;
        }

        public async Task<User> GetUserDetailsUsingEmailAddress(string email)
        {
            User? model = new User();
            using (var context = new LooganContext(_connectionString))
            {
                model = await context.Users.Where(x => x.EmailAddress.ToUpper().Trim() == email.ToUpper().Trim()).FirstOrDefaultAsync();
            }
            return model;
        }

        public async Task<int?> CreateUser(User userObj)
        {
            var isCreated = 0;

            if (userObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Users.Add(userObj);
                    isCreated = await context.SaveChangesAsync();

                    if(Convert.ToInt32(UserTypeEnum.teacher) == userObj.UserTypeId)
                    {
                        int? PerviousStaffId = context.Staff.Max(u => (int?)u.StaffId);
                        var code = CodeGenertion("staff", PerviousStaffId);
                        var staffobj = new Staff()
                        {
                            FirstName = userObj.FirstName,
                            LastName = userObj.LastName,
                            StaffName = userObj.AdditionalName,
                            Code = code,
                            UserId = userObj.UserId,
                            CreatedBy = userObj.CreatedBy,
                            CreatedDate = userObj.CreatedDate
                        };
                        context.Staff.Add(staffobj);
                        isCreated = await context.SaveChangesAsync();
                    }
                    else if (Convert.ToInt32(UserTypeEnum.student) == userObj.UserTypeId)
                    {
                        int? PerviousStudentId = context.Students.Max(u => (int?)u.StudentId);
                        var Number = CodeGenertion("student", PerviousStudentId);
                        var studentobj = new Student()
                        {
                            FirstName = userObj.FirstName,
                            MiddleName = userObj.MiddleName,
                            LastName = userObj.LastName,
                            GenderId = userObj.GenderId,
                            FullName = userObj.AdditionalName,
                            Suffix = userObj.Suffix,
                            Title = userObj.JobTitle,
                            PostalCode = userObj.PostalCode,
                            UserId = userObj.UserId,
                            StudentNumber = Number,
                            CreatedBy = userObj.CreatedBy,
                            CreatedDate = userObj.CreatedDate
                        };
                        context.Students.Add(studentobj);
                        isCreated = await context.SaveChangesAsync();


                    }

                }
            }

            return isCreated;
        }

        private string CodeGenertion(string type,int? previousId)
        {
            var code = "";
            if (type == "staff")
            {
                if (previousId > 0)
                    code = "Staff_" + (previousId + 1);
                else
                    code = "Staff_1";
            }
            else if(type == "student")
            {
                if (previousId > 0)
                    code = "student_" + (previousId + 1);
                else
                    code = "Student_1";
            }

            return code;
        }

        public async Task<int?> UpdateUser(User userObj)
        {
            var isUpdated = 0;

            if (userObj != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    context.Users.Update(userObj);
                    isUpdated = await context.SaveChangesAsync();
                }
            }

            return isUpdated;
        }

        public async Task<int?> DeleteUser(int userId)
        {
            var isDeleted = 0;

            if (userId != 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var user = context.Users.FirstOrDefault(x => x.UserId == userId);

                    if (user != null)
                    {
                        user.IsDeleted = true;
                        context.Users.Update(user);
                        isDeleted = await context.SaveChangesAsync();
                    }

                }
            }

            return isDeleted;
        }

        public async Task<bool> IsUserNameExist(string userName,int userId)
        {
            var isUserNameExist = false;

            if (userName != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    if (userId > 0)
                    {
                        var existingUser = await context.Users.Where(x=>x.UserId == userId && !x.IsDeleted).FirstOrDefaultAsync(); 
                        if (existingUser != null && existingUser.UserName != userName)
                        {
                            isUserNameExist = await context.Users.AnyAsync(x => x.UserName.ToUpper() == userName.ToUpper() && !x.IsDeleted);
                        }
                    }
                    else
                    {
                        isUserNameExist = await context.Users.AnyAsync(x => x.UserName.ToUpper() == userName.ToUpper() && !x.IsDeleted);
                    }
                }
            }

            return isUserNameExist;

        }

        public async Task<bool> IsUserEmailExist(string userEmail, int userId)
        {
            var isUserEmailExist = false;

            if (userEmail != null)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    if (userId > 0)
                    {
                        var existingUser = await context.Users.Where(x => x.UserId == userId && !x.IsDeleted).FirstOrDefaultAsync();
                        if (existingUser != null && existingUser.EmailAddress != userEmail)
                        {
                            isUserEmailExist = await context.Users.AnyAsync(x => x.EmailAddress.ToUpper() == userEmail.ToUpper() && !x.IsDeleted);
                        }
                    }
                    else
                    {
                        isUserEmailExist = await context.Users.AnyAsync(x => x.EmailAddress.ToUpper() == userEmail.ToUpper() && !x.IsDeleted);
                    }
                }
            }

            return isUserEmailExist;

        }

        public async Task<List<User>> GetUsersByUserType(int userTypeId)
        {
            var userList = new List<User>();
            using (var context = new LooganContext(_connectionString))
            {
                userList = await context.Users.Where(x => x.UserTypeId == userTypeId).ToListAsync();
            }
            return userList;
        }

        public async Task<List<InstitutionUserModel>> GetInstitutionUserList(int institutionId,int userTypeId)
        {
            List<InstitutionUserModel>? institutionuserList = new List<InstitutionUserModel>();
            using (var context = new LooganContext(_connectionString))
            {
                var query = context.Database.SqlQuery<InstitutionUserModel>($"Get_InstitutionUsers {institutionId} ,{userTypeId}").AsNoTracking().AsAsyncEnumerable();
                await foreach (var item in query)
                {
                    institutionuserList.Add(item);
                }
            }
            return institutionuserList;

        }

        public async Task<int> SaveInstitutionUsers(List<SaveInstitutionUserRequest> request)
        {
            var isSuccess = 0;

            if (request.Count > 0)
            {
                using (var context = new LooganContext(_connectionString))
                {
                    var institutionId = request?.FirstOrDefault()?.InstitutionId;
                    var userTypeId = request?.FirstOrDefault()?.UserTypeId;

                    if (institutionId > 0 && userTypeId > 0)
                    {
                        var institutionUserMapping = context.InstitutionUserMappings.Where(x => x.InstitutionId == institutionId  && x.UserTypeId == userTypeId).ToList();
                        if (institutionUserMapping.Any())
                        {
                            context.InstitutionUserMappings.RemoveRange(institutionUserMapping.ToArray());
                        }

                        foreach (var item in request)
                        {
                            var institutionUserMappings = new InstitutionUserMapping()
                            {
                                InstitutionId = item.InstitutionId,
                                UserTypeId = item.UserTypeId,
                                UserId = item.UserId
                            };
                            context.InstitutionUserMappings.Add(institutionUserMappings);
                        }

                        context.SaveChanges();
                    }
                }
            }

            return isSuccess;

        }
    }
}
