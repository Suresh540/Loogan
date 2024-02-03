USE [loogan]
GO
/****** Object:  Table [dbo].[Email_Templates]    Script Date: 03-02-2024 15:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email_Templates](
	[EmailTemplateId] [int] IDENTITY(1,1) NOT NULL,
	[MasterEmailTemplateId] [int] NOT NULL,
	[Subject] [varchar](500) NOT NULL,
	[Body] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Email_Templates] PRIMARY KEY CLUSTERED 
(
	[EmailTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Master_EmailTemplate]    Script Date: 03-02-2024 15:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master_EmailTemplate](
	[MasterEmailTemplateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Master_EmailTemplate] PRIMARY KEY CLUSTERED 
(
	[MasterEmailTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Email_Templates] ON 
GO
INSERT [dbo].[Email_Templates] ([EmailTemplateId], [MasterEmailTemplateId], [Subject], [Body], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, 1, N'Welcome to {USER}', N'Dear {User}<div><br></div><div>welcome to loogan Project</div>', 1, 1, CAST(N'2024-02-03T14:36:37.687' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Email_Templates] OFF
GO
SET IDENTITY_INSERT [dbo].[Master_EmailTemplate] ON 
GO
INSERT [dbo].[Master_EmailTemplate] ([MasterEmailTemplateId], [Name], [LanguageId], [IsDeleted]) VALUES (1, N'Register User', 1, 0)
GO
INSERT [dbo].[Master_EmailTemplate] ([MasterEmailTemplateId], [Name], [LanguageId], [IsDeleted]) VALUES (2, N'Forgot Password', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Master_EmailTemplate] OFF
GO
ALTER TABLE [dbo].[Email_Templates] ADD  CONSTRAINT [DF_Email_Templates_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Master_EmailTemplate] ADD  CONSTRAINT [DF_Master_EmailTemplate_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Email_Templates]  WITH CHECK ADD  CONSTRAINT [FK_Email_Templates_Email_Templates] FOREIGN KEY([EmailTemplateId])
REFERENCES [dbo].[Email_Templates] ([EmailTemplateId])
GO
ALTER TABLE [dbo].[Email_Templates] CHECK CONSTRAINT [FK_Email_Templates_Email_Templates]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllEmailTemplates]    Script Date: 03-02-2024 15:45:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_AllEmailTemplates]   
AS  
	SELECT ET.EmailTemplateId,
	ET.MasterEmailTemplateId,
	MET.Name As EmailTemplateName,
	ET.Subject,
	ET.Body,
	ET.IsDeleted,
	ET.CreatedBy,
	ET.CreatedDate,
	ET.ModifyBy,
	ET.ModifyDate,
	Count(*) OVER(Partition BY ET.IsDeleted) AS TotalRecords
FROM Email_Templates ET
inner join Master_EmailTemplate MET on MET.MasterEmailTemplateId = ET.EmailTemplateId and MET.IsDeleted = 0
where ET.IsDeleted = 0
GO
