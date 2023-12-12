USE [loogan]
GO
/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 10-12-2023 13:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[Get_AllUserDetails] 
AS
SELECT U.*, 
	GN.LookUpValue As Gender,
	LG.LookUpValue As UserLanguage
FROM [DBO].[Users] U
LEFT JOIN [DBO].master_Lookup GN on GN.LookUpId = u.GenderId and GN.IsDeleted = 0 and GN.LookUpType = 'gender'
LEFT JOIN [DBO].master_Lookup LG on LG.LookUpId = u.languageId and LG.IsDeleted = 0 and LG.LookUpType = 'language'
