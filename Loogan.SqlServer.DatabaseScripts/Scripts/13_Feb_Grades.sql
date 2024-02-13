GO
/****** Object:  Table [dbo].[Master_Grades]    Script Date: 13-02-2024 21:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master_Grades](
	[MasterGradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeCategoryName] [varchar](50) NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](500) NULL,
	[PercentageRange] [varchar](100) NULL,
	[Percentage] [decimal](18, 0) NULL,
	[LanguageId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Master_Grades] PRIMARY KEY CLUSTERED 
(
	[MasterGradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Grade_Mapping]    Script Date: 13-02-2024 21:59:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Grade_Mapping](
	[GradeStudentMappingId] [int] IDENTITY(1,1) NOT NULL,
	[StudentCourseMappingId] [int] NOT NULL,
	[MasterGradeId] [int] NOT NULL,
	[Remarks] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Student_Grade_Mapping] PRIMARY KEY CLUSTERED 
(
	[GradeStudentMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Master_Grades] ON 
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'AlphabetGrades', N'A+', N'A+', N'Test', N'90-100', NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (2, N'AlphabetGrades', N'A', N'A', NULL, N'80-90', NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (3, N'AlphabetGrades', N'B', N'B', NULL, N'60-80', NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (4, N'AlphabetGrades', N'C', N'C', NULL, N'50-60', NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (5, N'AlphabetGrades', N'D', N'D', NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (6, N'AlphabetGrades', N'E', N'E', NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Master_Grades] ([MasterGradeId], [GradeCategoryName], [Code], [Name], [Description], [PercentageRange], [Percentage], [LanguageId], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (8, N'NumericGrades', N'1', N'1', NULL, NULL, NULL, 1, 0, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Master_Grades] OFF
GO
ALTER TABLE [dbo].[Master_Grades] ADD  CONSTRAINT [DF_Master_Grades_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Student_Grade_Mapping] ADD  CONSTRAINT [DF_Student_Grade_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Student_Grade_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Grade_Mapping_Master_Grades] FOREIGN KEY([MasterGradeId])
REFERENCES [dbo].[Master_Grades] ([MasterGradeId])
GO
ALTER TABLE [dbo].[Student_Grade_Mapping] CHECK CONSTRAINT [FK_Student_Grade_Mapping_Master_Grades]
GO
ALTER TABLE [dbo].[Student_Grade_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Grade_Mapping_StudentCourseMappingId] FOREIGN KEY([StudentCourseMappingId])
REFERENCES [dbo].[Student_Course_Mapping] ([StudentCourseMappingId])
GO
ALTER TABLE [dbo].[Student_Grade_Mapping] CHECK CONSTRAINT [FK_Student_Grade_Mapping_StudentCourseMappingId]
GO
