

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Category](
	[CourseCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCategory] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Course_Category] PRIMARY KEY CLUSTERED 
(
	[CourseCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Membership]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Membership](
	[CourseMembershipId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Course_Membership] PRIMARY KEY CLUSTERED 
(
	[CourseMembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Message]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Message](
	[CourseMessageId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Course_Message] PRIMARY KEY CLUSTERED 
(
	[CourseMessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Type]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Type](
	[CourseTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CourseType] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Course_Type] PRIMARY KEY CLUSTERED 
(
	[CourseTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](100) NULL,
	[CourseName] [varchar](100) NOT NULL,
	[CourseDesc] [varchar](500) NULL,
	[CourseCategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses_Fully_Online]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Fully_Online](
	[FullyOnlineCourseId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Courses_Fully_Online] PRIMARY KEY CLUSTERED 
(
	[FullyOnlineCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses_Hybrid_Table]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Hybrid_Table](
	[HybirdCourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_Courses_Hybrid_Table] PRIMARY KEY CLUSTERED 
(
	[HybirdCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses_Web_Enhanced]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses_Web_Enhanced](
	[WebEnhancedCourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Courses_Web_Enhanced] PRIMARY KEY CLUSTERED 
(
	[WebEnhancedCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Master_LookUp]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master_LookUp](
	[LookUpId] [int] IDENTITY(1,1) NOT NULL,
	[LookUpType] [varchar](100) NOT NULL,
	[LookUpValue] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_MasterLookUp] PRIMARY KEY CLUSTERED 
(
	[LookUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status_LookUp]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status_LookUp](
	[StatusLookUpId] [int] IDENTITY(1,1) NOT NULL,
	[StatusLookUpType] [varchar](100) NOT NULL,
	[StatusLookUpValue] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_StatusLookUp] PRIMARY KEY CLUSTERED 
(
	[StatusLookUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[ProfilePicPath] [varchar](500) NULL,
	[PreFix] [varchar](50) NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Suffix] [varchar](50) NULL,
	[AdditionalName] [varchar](200) NULL,
	[PhoneNumber] [varchar](100) NULL,
	[EmailAddress] [varchar](100) NULL,
	[GenderId] [int] NULL,
	[Password] [varchar](50) NULL,
	[EducationLevel] [varchar](100) NULL,
	[WebSite] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[Address1] [varchar](200) NULL,
	[Address2] [varchar](200) NULL,
	[PostalCode] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[Company] [varchar](100) NULL,
	[JobTitle] [varchar](100) NULL,
	[Department] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[UserName] [varchar](50) NULL,
	[languageId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course_Category] ON 
GO
INSERT [dbo].[Course_Category] ([CourseCategoryId], [CourseCategory], [IsDeleted]) VALUES (1, N'2023 Fall', 0)
GO
INSERT [dbo].[Course_Category] ([CourseCategoryId], [CourseCategory], [IsDeleted]) VALUES (2, N'2023 Summary', 0)
GO
INSERT [dbo].[Course_Category] ([CourseCategoryId], [CourseCategory], [IsDeleted]) VALUES (3, N'Assored Dates', 0)
GO
SET IDENTITY_INSERT [dbo].[Course_Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Course_Type] ON 
GO
INSERT [dbo].[Course_Type] ([CourseTypeId], [CourseType], [IsDeleted]) VALUES (1, N'Hybrid Courses', NULL)
GO
INSERT [dbo].[Course_Type] ([CourseTypeId], [CourseType], [IsDeleted]) VALUES (2, N'Fully Online Courses', NULL)
GO
INSERT [dbo].[Course_Type] ([CourseTypeId], [CourseType], [IsDeleted]) VALUES (3, N'Web-enhanced Courses', NULL)
GO
SET IDENTITY_INSERT [dbo].[Course_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Master_LookUp] ON 
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (1, N'language', N'English', NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (2, N'language', N'Telugu', NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (3, N'language', N'Hindi', NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (4, N'gender', N'Male', NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (5, N'gender', N'Female', NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [Description], [IsDeleted]) VALUES (6, N'gender', N'Transgender', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Master_LookUp] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId]) VALUES (1, 1, NULL, NULL, N'Suresh', N'Kalage', NULL, N'Suresh Kalage', N'9742544910', N'Sureshkalaga83@gmail.com', 4, N'12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'suresh', 2)
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId]) VALUES (2, 3, NULL, N'Mr', N'Vivek ', N'Mutyala', NULL, N'Vivek Mutyala', N'9949121113', N'vivekchowdarymutyala@gmail.com', 4, N'12345', N'B-Tech', N'www.mysite.com', NULL, N'Lingampally', N'RailVihar', N'500018', N'Hyderabad', N'Telegana', N'India', N'MyCompany', N'Senior Leader', N'Information', 0, NULL, NULL, NULL, NULL, N'vivek', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([UserTypeId], [UserType], [Description], [IsDeleted]) VALUES (1, N'Admin', NULL, 0)
GO
INSERT [dbo].[UserType] ([UserTypeId], [UserType], [Description], [IsDeleted]) VALUES (2, N'Teacher', NULL, 0)
GO
INSERT [dbo].[UserType] ([UserTypeId], [UserType], [Description], [IsDeleted]) VALUES (3, N'Student', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
ALTER TABLE [dbo].[Course_Category] ADD  CONSTRAINT [DF_Course_Category_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Course_Type] ADD  CONSTRAINT [DF_Course_Type_Course_Type]  DEFAULT ((0)) FOR [CourseType]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Master_LookUp] ADD  CONSTRAINT [DF_MasterLookUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Status_LookUp] ADD  CONSTRAINT [DF_StatusLookUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [DF_UserType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CategoryId] FOREIGN KEY([CourseCategoryId])
REFERENCES [dbo].[Course_Category] ([CourseCategoryId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CategoryId]
GO
ALTER TABLE [dbo].[Courses_Hybrid_Table]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Hybrid_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Courses_Hybrid_Table] CHECK CONSTRAINT [FK_Courses_Hybrid_CourseId]
GO
ALTER TABLE [dbo].[Courses_Web_Enhanced]  WITH CHECK ADD  CONSTRAINT [FK_Course_CategoryId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Courses_Web_Enhanced] CHECK CONSTRAINT [FK_Course_CategoryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_GenderId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_LanguageId] FOREIGN KEY([languageId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_LanguageId]
GO
/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 04-12-2023 22:05:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[Get_UserDetails] 
(@UserName VARCHAR(50),@Password VARCHAR(50))
AS
SELECT U.*, 
	UT.UserType UserTypeName, 
	UT.[Description],
	UT.IsDeleted AS IsDeletedType,
	GN.LookUpValue As Gender,
	LG.LookUpValue As UserLanguage
FROM [DBO].[Users] U
JOIN [DBO].UserType UT ON U.UserTypeId = UT.UserTypeId
LEFT JOIN [DBO].master_Lookup GN on GN.LookUpId = u.GenderId and GN.IsDeleted = 0 and GN.LookUpType = 'gender'
LEFT JOIN [DBO].master_Lookup LG on LG.LookUpId = u.languageId and LG.IsDeleted = 0 and LG.LookUpType = 'language'
WHERE UserName = @UserName AND [Password] = @Password
GO
