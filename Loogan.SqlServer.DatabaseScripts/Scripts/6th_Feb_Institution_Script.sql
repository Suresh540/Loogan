USE [loogan]
GO
/****** Object:  Table [dbo].[Institution]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution](
	[InstitutionId] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionName] [varchar](100) NOT NULL,
	[Description] [varchar](200) NULL,
	[Address] [varchar](200) NULL,
	[PhoneNumber] [varchar](100) NULL,
	[EmailAddress] [varchar](100) NULL,
	[Website] [varchar](100) NULL,
	[InstitutionImageUrl] [varchar](200) NULL,
	[Mission] [varchar](500) NULL,
	[Vision] [varchar](500) NULL,
	[AdditionalComments] [varchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Institution] PRIMARY KEY CLUSTERED 
(
	[InstitutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institution_Announcement]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution_Announcement](
	[InstitutionAnnouncementId] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionId] [int] NOT NULL,
	[Title] [varchar](100) NULL,
	[Announcement] [varchar](500) NOT NULL,
	[Description] [varchar](200) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Institution_Announcement] PRIMARY KEY CLUSTERED 
(
	[InstitutionAnnouncementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institution_News]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institution_News](
	[InstitutionNewsId] [int] IDENTITY(1,1) NOT NULL,
	[InstitutionId] [int] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[News] [varchar](500) NOT NULL,
	[Description] [varchar](50) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Institution_News] PRIMARY KEY CLUSTERED 
(
	[InstitutionNewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Institution] ADD  CONSTRAINT [DF_Institution_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Institution_Announcement] ADD  CONSTRAINT [DF_Institution_Announcement_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Institution_News] ADD  CONSTRAINT [DF_Institution_News_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Institution_Announcement]  WITH CHECK ADD  CONSTRAINT [FK_Institution_Announcement_Institution] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institution] ([InstitutionId])
GO
ALTER TABLE [dbo].[Institution_Announcement] CHECK CONSTRAINT [FK_Institution_Announcement_Institution]
GO
ALTER TABLE [dbo].[Institution_News]  WITH CHECK ADD  CONSTRAINT [FK_Institution_News_Institution] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institution] ([InstitutionId])
GO
ALTER TABLE [dbo].[Institution_News] CHECK CONSTRAINT [FK_Institution_News_Institution]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllInstitutions]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE      PROC [dbo].[Get_AllInstitutions]   
AS  
	SELECT [InstitutionId]
      ,[InstitutionName]
      ,[Description]
      ,[Address]
      ,[PhoneNumber]
      ,[EmailAddress]
      ,[Website]
      ,[InstitutionImageUrl]
      ,[Mission]
      ,[Vision]
      ,[AdditionalComments]
      ,[IsDeleted]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[ModifyBy]
      ,[ModifyDate]
	  ,Count(*) OVER(Partition BY Ins.IsDeleted) AS TotalRecords
  FROM [dbo].[Institution] Ins where Ins.IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[Get_AllInstitutionsAnnouncements]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE      PROC [dbo].[Get_AllInstitutionsAnnouncements]   
AS  
	SELECT InsAnn.[InstitutionAnnouncementId]
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
  where InsAnn.IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[Get_AllInstitutionsNews]    Script Date: 06-02-2024 16:04:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE      PROC [dbo].[Get_AllInstitutionsNews]   
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
GO
