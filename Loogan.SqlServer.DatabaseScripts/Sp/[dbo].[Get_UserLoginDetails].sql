GO

CREATE OR ALTER PROC [dbo].[Get_UserLoginDetails]   
(@UserName VARCHAR(50),@Password VARCHAR(50))  
AS  
SELECT U.UserId,  
    U.UserName,  
    UT.UserTypeId,  
    UT.UserType UserTypeName,
	U.LastName+','+U.FirstName AS FullName
FROM [DBO].[Users] U  
JOIN [DBO].UserType UT ON U.UserTypeId = UT.UserTypeId  
WHERE UserName = @UserName   
 AND [Password] = @Password  
 AND U.IsDeleted = 0