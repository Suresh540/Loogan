-- ================================
-- Create User-defined Table Type
-- ================================
-- Create the data type
CREATE TYPE UserTableType AS TABLE 
(
	[UserId] [int] NOT NULL,
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
	[languageId] [int] NULL
)
GO
