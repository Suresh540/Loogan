GO
/****** Object:  Table [dbo].[Institution_User_Mapping]    Script Date: 13-02-2024 01:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution_User_Mapping](
	[InstitutionUserMappingId] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Institution_User_Mapping] PRIMARY KEY CLUSTERED 
(
	[InstitutionUserMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Institution_User_Mapping] ADD  CONSTRAINT [DF_Institution_User_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Institution_User_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Institution_User_Mapping_InstitutionId] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institution] ([InstitutionId])
GO
ALTER TABLE [dbo].[Institution_User_Mapping] CHECK CONSTRAINT [FK_Institution_User_Mapping_InstitutionId]
GO
ALTER TABLE [dbo].[Institution_User_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Institution_User_Mapping_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Institution_User_Mapping] CHECK CONSTRAINT [FK_Institution_User_Mapping_UserId]
GO
ALTER TABLE [dbo].[Institution_User_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Institution_User_Mapping_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[Institution_User_Mapping] CHECK CONSTRAINT [FK_Institution_User_Mapping_UserType]
GO
/****** Object:  StoredProcedure [dbo].[Get_InstitutionsAnnouncementsByUserId]    Script Date: 13-02-2024 01:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROC [dbo].[Get_InstitutionsAnnouncementsByUserId]
(
@UserId int
) 
AS  
	SELECT TOP 1 InsAnn.[InstitutionAnnouncementId]
      ,InsAnn.[InstitutionId]
	  ,Ins.InstitutionName
      ,InsAnn.[Title]
      ,InsAnn.[Announcement]
      ,InsAnn.[Description]
	  ,FORMAT (InsAnn.StartDate, 'yyyy-MM-dd') as StartDate
	  ,FORMAT (InsAnn.EndDate, 'yyyy-MM-dd') as EndDate
      ,InsAnn.[IsDeleted]
      ,InsAnn.[CreatedBy]
      ,InsAnn.[CreatedDate]
      ,InsAnn.[ModifyBy]
      ,InsAnn.[ModifyDate]
	   ,Count(*) OVER(Partition BY InsAnn.IsDeleted) AS TotalRecords
  FROM [dbo].[Institution_Announcement] InsAnn
  inner join [dbo].[Institution] Ins on Ins.InstitutionId = InsAnn.InstitutionId and Ins.IsDeleted = 0
  inner join [dbo].[Institution_User_Mapping] INUM on INUM.InstitutionId = InsAnn.InstitutionId
  where InsAnn.IsDeleted = 0 and INUM.UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[Get_InstitutionsNewsByUserId]    Script Date: 13-02-2024 01:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   PROC [dbo].[Get_InstitutionsNewsByUserId]
(
@UserId int
) 
AS  
	SELECT InsNews.[InstitutionNewsId]
      ,InsNews.[InstitutionId]
	  ,Ins.InstitutionName
      ,InsNews.[Title]
      ,InsNews.[News]
      ,InsNews.[Description]
	  ,FORMAT (InsNews.StartDate, 'yyyy-MM-dd') as StartDate
	  ,FORMAT (InsNews.EndDate, 'yyyy-MM-dd') as EndDate
      ,InsNews.[IsDeleted]
      ,InsNews.[CreatedBy]
      ,InsNews.[CreatedDate]
      ,InsNews.[ModifyBy]
      ,InsNews.[ModifyDate]
	   ,Count(*) OVER(Partition BY InsNews.IsDeleted) AS TotalRecords
  FROM [dbo].[Institution_News] InsNews
  inner join [dbo].[Institution] Ins on Ins.InstitutionId = InsNews.InstitutionId and Ins.IsDeleted = 0
  inner join [dbo].[Institution_User_Mapping] INUM on INUM.InstitutionId = InsNews.InstitutionId
  WHERE InsNews.IsDeleted = 0 and INUM.UserId = @UserId
GO
/****** Object:  StoredProcedure [dbo].[Get_InstitutionUsers]    Script Date: 13-02-2024 01:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[Get_InstitutionUsers] 
(
@InstitutionId int,
@UserTypeId int
)    
AS    
SELECT 
INUM.InstitutionUserMappingId,
INUM.UserId,
US.UserName,
INUM.UserTypeId
FROM Institution_User_Mapping INUM
INNER JOIN Users US ON INUM.UserId = US.UserId and US.IsDeleted = 0
WHERE INUM.IsDeleted = 0 and INUM.UserTypeId = @UserTypeId and INUM.InstitutionId = @InstitutionId
GO
