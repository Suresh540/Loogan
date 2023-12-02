
GO
CREATE OR ALTER PROC [DBO].[Get_UserDetails] 
(@UserName VARCHAR(50),@Password VARCHAR(50))
AS
SELECT U.*, UT.UserType UserTypeName, UT.[Description],UT.IsDeleted AS IsDeletedType FROM [DBO].[Users] U
JOIN [DBO].UserType UT ON U.UserTypeId = UT.UserTypeId
WHERE UserName = @UserName AND [Password] = @Password

Go