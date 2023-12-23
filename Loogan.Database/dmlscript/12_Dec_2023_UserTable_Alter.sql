ALTER TABLE Users
ADD MiddleName varchar(100);

---------------------------------------

USE [loogan]
GO

INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Not disclosed',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','K-8',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','High School',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Freshman',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Sophomore',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Junior',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Senior',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Graduate School',null,0)
INSERT INTO [dbo].[Master_LookUp]([LookUpType],[LookUpValue],[Description],[IsDeleted])
     VALUES ('educationlevel','Post-Graduate School',null,0)
GO

----------------SP need execute [dbo].[Get_UserLoginDetails]
