USE [loogan]
GO

/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 05-12-2023 12:50:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROC [dbo].[Get_UserDetails] 
(@userId INT)
AS
SELECT U.*, 
	GN.LookUpValue As Gender,
	LG.LookUpValue As UserLanguage
FROM [DBO].[Users] U
LEFT JOIN [DBO].master_Lookup GN on GN.LookUpId = u.GenderId and GN.IsDeleted = 0 and GN.LookUpType = 'gender'
LEFT JOIN [DBO].master_Lookup LG on LG.LookUpId = u.languageId and LG.IsDeleted = 0 and LG.LookUpType = 'language'
WHERE U.UserId = @userId
GO


