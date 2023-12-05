USE [loogan]
GO

/****** Object:  StoredProcedure [dbo].[Get_UserLoginDetails]    Script Date: 05-12-2023 12:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER  PROC [dbo].[Get_UserLoginDetails] 
(@UserName VARCHAR(50),@Password VARCHAR(50))
AS
SELECT U.UserId,
	   U.FirstName + ' ' + U.LastName  As UserName,
	   UT.UserTypeId,
	   UT.UserType UserTypeName
FROM [DBO].[Users] U
JOIN [DBO].UserType UT ON U.UserTypeId = UT.UserTypeId
WHERE UserName = @UserName 
	AND [Password] = @Password
	AND U.IsDeleted = 0
GO


