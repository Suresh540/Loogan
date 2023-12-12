USE [loogan]
GO

/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 11-12-2023 07:43:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROC [dbo].[Get_MasterLookUpValues] 
(@lookUpType VARCHAR(50))
AS
SELECT ML.lookUpId,
	   ML.LookUPValue
FROM 
[DBO].master_Lookup ML 
WHERE ML.IsDeleted = 0 and ML.LookUpType = @lookUpType
GO


