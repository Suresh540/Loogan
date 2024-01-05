/****** Object:  StoredProcedure [dbo].[Get_UserLoginDetails]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_UserLoginDetails]
GO
/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_UserDetails]
GO
/****** Object:  StoredProcedure [dbo].[Get_StudentCourseDetails]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_StudentCourseDetails]
GO
/****** Object:  StoredProcedure [dbo].[Get_RoleMenus]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_RoleMenus]
GO
/****** Object:  StoredProcedure [dbo].[Get_MasterLookUpValues]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_MasterLookUpValues]
GO
/****** Object:  StoredProcedure [dbo].[Get_CourseRelatedLookUpValues]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_CourseRelatedLookUpValues]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllUserDetails]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_AllUserDetails]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllStudents]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_AllStudents]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllStaff]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_AllStaff]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllMenus]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_AllMenus]
GO
/****** Object:  StoredProcedure [dbo].[Get_AllCourses]    Script Date: 05-01-2024 23:43:20 ******/
DROP PROCEDURE IF EXISTS [dbo].[Get_AllCourses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [FK_Users_LanguageId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [FK_User_GenderId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Score]') AND type in (N'U'))
ALTER TABLE [dbo].[Test_Score] DROP CONSTRAINT IF EXISTS [FK_Test_Score_Test_TestId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Score]') AND type in (N'U'))
ALTER TABLE [dbo].[Test_Score] DROP CONSTRAINT IF EXISTS [FK_Test_Score_Student_StudentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Score]') AND type in (N'U'))
ALTER TABLE [dbo].[Test_Score] DROP CONSTRAINT IF EXISTS [FK_Test_Score_Same_TestScoreParentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Score]') AND type in (N'U'))
ALTER TABLE [dbo].[Test_Score] DROP CONSTRAINT IF EXISTS [FK_Test_Score_Enrollment_EnrollmentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test]') AND type in (N'U'))
ALTER TABLE [dbo].[Test] DROP CONSTRAINT IF EXISTS [FK_Test_CampusGroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Term]') AND type in (N'U'))
ALTER TABLE [dbo].[Term] DROP CONSTRAINT IF EXISTS [FK_Term_CourseRelated_TermSeasonId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Term]') AND type in (N'U'))
ALTER TABLE [dbo].[Term] DROP CONSTRAINT IF EXISTS [FK_Term_CourseRelated_TermCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Term]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Student]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_StatusLookUp_CourseStatusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Enrollment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Courses]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Class_Section]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Student_Course_Mapping_Campus_CampusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_StatusLookup_CitizenShipStatId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_State_StateId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_School_SchoolId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_Program_ProgramId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_MasterLookUp_NationalityId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_MasterLookup_GenderId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseReleated_ProspectTypeId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseReleated_ProspectId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseRelated_ProspectCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseRelated_ProgramGroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseRelated_EtnicGroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_CourseRelated_EducationLevelId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_Country_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK_Student_Campus_CampusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [FK__Student__UserId__22FF2F51]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
ALTER TABLE [dbo].[State] DROP CONSTRAINT IF EXISTS [FK_State_LanguageId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
ALTER TABLE [dbo].[State] DROP CONSTRAINT IF EXISTS [FK_State_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [FK__Staff__UserId__2022C2A6]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift]') AND type in (N'U'))
ALTER TABLE [dbo].[Shift] DROP CONSTRAINT IF EXISTS [FK_Shift_GroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[School]') AND type in (N'U'))
ALTER TABLE [dbo].[School] DROP CONSTRAINT IF EXISTS [FK_School_StatusLookUp_StatusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[School]') AND type in (N'U'))
ALTER TABLE [dbo].[School] DROP CONSTRAINT IF EXISTS [FK_School_CourseRelated_CategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_Course_Mapping_Program_ProgramId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_Course_Mapping_CourseRelated_CoursePoolId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_Course_Mapping_CourseRelated_CourseCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_Course_Mapping_CourseRelated_CoursecatalogId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_Course_Mapping_Course_CourseId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_AreaOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_AreaOfStudy_Mapping_ProgramId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_AreaOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_AreaOfStudy_Mapping_CourseRelated_CatalogId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_AreaOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [FK_Program_AreaOfStudy_Mapping_AreaOfStudyId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
ALTER TABLE [dbo].[Program] DROP CONSTRAINT IF EXISTS [FK_Program_CourseRelated_VersionId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
ALTER TABLE [dbo].[Program] DROP CONSTRAINT IF EXISTS [FK_Program_CourseRelated_DegreeId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
ALTER TABLE [dbo].[Program] DROP CONSTRAINT IF EXISTS [FK_Program_CourseRelated_CIPCode2020]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
ALTER TABLE [dbo].[Program] DROP CONSTRAINT IF EXISTS [FK_Program_CourseRelated_CIPCode2010]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PreviousEducation]') AND type in (N'U'))
ALTER TABLE [dbo].[PreviousEducation] DROP CONSTRAINT IF EXISTS [FK_PreviousEducation_Student_StudentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PreviousEducation]') AND type in (N'U'))
ALTER TABLE [dbo].[PreviousEducation] DROP CONSTRAINT IF EXISTS [FK_PreviousEducation_Organization_OrganizationId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PreviousEducation]') AND type in (N'U'))
ALTER TABLE [dbo].[PreviousEducation] DROP CONSTRAINT IF EXISTS [FK_PreviousEducation_CourseRelation_EducationLevelId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PreviousEducation]') AND type in (N'U'))
ALTER TABLE [dbo].[PreviousEducation] DROP CONSTRAINT IF EXISTS [FK_PreviousEducation_CourseRelated_GradeLevelId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organization]') AND type in (N'U'))
ALTER TABLE [dbo].[Organization] DROP CONSTRAINT IF EXISTS [FK_Organization_State_StateId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organization]') AND type in (N'U'))
ALTER TABLE [dbo].[Organization] DROP CONSTRAINT IF EXISTS [FK_Organization_Country_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Secondary]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Secondary] DROP CONSTRAINT IF EXISTS [FK_Menu_Secondary_Menu_PrimaryMenuId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Secondary]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Secondary] DROP CONSTRAINT IF EXISTS [FK_Menu_Secondary_Language_LanguageId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Role_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Role_Mapping] DROP CONSTRAINT IF EXISTS [FK_Menu_Role_Mapping_UserType_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Role_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Role_Mapping] DROP CONSTRAINT IF EXISTS [FK_Menu_Role_Mapping_Primary_PrimaryMenuId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment_AreasOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [FK_EnrollmentAreasOfStudyMapping_AreaofStudyId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment_AreasOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [FK_EnrollmentAreaMapping_Enrollment_EnrollmentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courses]') AND type in (N'U'))
ALTER TABLE [dbo].[Courses] DROP CONSTRAINT IF EXISTS [FK_Courses_CourseRelated_TypeSourceId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courses]') AND type in (N'U'))
ALTER TABLE [dbo].[Courses] DROP CONSTRAINT IF EXISTS [FK_Courses_CourseRelated_LevelSourceId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
ALTER TABLE [dbo].[Country] DROP CONSTRAINT IF EXISTS [FK_Conuntry_LanguageId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_Term_TermId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_Staff_PrimaryInstructionId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_Shift_ShiftId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_CoursReleated_AttendanceTypeId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_CourseLookup_DeliveryMethodId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_Course_courseId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [FK_Class_Campus_CampusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Period_Schedule]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Period_Schedule] DROP CONSTRAINT IF EXISTS [FK_Period_Schedule_StatusLookUp_ScheduleStatusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Period_Schedule]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Period_Schedule] DROP CONSTRAINT IF EXISTS [FK_Period_Schedule_Staff_Staffid]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Period_Schedule]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Period_Schedule] DROP CONSTRAINT IF EXISTS [FK_Period_Schedule_ClassSection_ClassSectionId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus_Group_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus_Group_Mapping] DROP CONSTRAINT IF EXISTS [FK_Campus_Group_Mapping_CampusId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus_Group_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus_Group_Mapping] DROP CONSTRAINT IF EXISTS [FK_Campus_Group_Mapping_Campus_Group]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus] DROP CONSTRAINT IF EXISTS [FK_Campus_StateId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus] DROP CONSTRAINT IF EXISTS [FK_Campus_CountryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_ClassPeriodScheduleId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_StudentCourseMappingId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_Student_StudentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_EnrollmentId_EnrollmentId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [FK_Attendance_ClassSection_ClassSectionId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Area_Of_Study_Course_Mapping_CRelated_CoursePoolId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCatalogId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Area_Of_Study_Course_Mapping_Course_CourseId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [FK_Area_Of_Study_Course_Mapping_AoS_AreaofStudyId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study] DROP CONSTRAINT IF EXISTS [FK_AreaOfStudy_CourseRelated_StudyTypeId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study] DROP CONSTRAINT IF EXISTS [FK_AreaofStudy_CourseRelated_CIPCode2020]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study] DROP CONSTRAINT IF EXISTS [FK_AreaofStudy_CourseRelated_CIPCode2010]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study] DROP CONSTRAINT IF EXISTS [FK_AreaOfStudy_CourseRealated_CampusGroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserType]') AND type in (N'U'))
ALTER TABLE [dbo].[UserType] DROP CONSTRAINT IF EXISTS [DF_UserType_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT IF EXISTS [DF_Users_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Score]') AND type in (N'U'))
ALTER TABLE [dbo].[Test_Score] DROP CONSTRAINT IF EXISTS [DF_Test_Score_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test]') AND type in (N'U'))
ALTER TABLE [dbo].[Test] DROP CONSTRAINT IF EXISTS [DF_Test_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Term]') AND type in (N'U'))
ALTER TABLE [dbo].[Term] DROP CONSTRAINT IF EXISTS [DF_Term_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Student_Course_Mapping] DROP CONSTRAINT IF EXISTS [DF_Student_Course_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
ALTER TABLE [dbo].[Student] DROP CONSTRAINT IF EXISTS [DF_Student_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Status_LookUp]') AND type in (N'U'))
ALTER TABLE [dbo].[Status_LookUp] DROP CONSTRAINT IF EXISTS [DF_StatusLookUp_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
ALTER TABLE [dbo].[State] DROP CONSTRAINT IF EXISTS [DF_State_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
ALTER TABLE [dbo].[Staff] DROP CONSTRAINT IF EXISTS [DF_Staff_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift]') AND type in (N'U'))
ALTER TABLE [dbo].[Shift] DROP CONSTRAINT IF EXISTS [DF_Shift_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[School]') AND type in (N'U'))
ALTER TABLE [dbo].[School] DROP CONSTRAINT IF EXISTS [DF_School_Status_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_Course_Mapping] DROP CONSTRAINT IF EXISTS [DF_Program_Course_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program_AreaOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [DF_Program_AreaOfStudy_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Program]') AND type in (N'U'))
ALTER TABLE [dbo].[Program] DROP CONSTRAINT IF EXISTS [DF_Program_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PreviousEducation]') AND type in (N'U'))
ALTER TABLE [dbo].[PreviousEducation] DROP CONSTRAINT IF EXISTS [DF_PreviousEducation_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organization]') AND type in (N'U'))
ALTER TABLE [dbo].[Organization] DROP CONSTRAINT IF EXISTS [DF_Organization_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Secondary]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Secondary] DROP CONSTRAINT IF EXISTS [DF_SecondaryMenu_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Role_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Role_Mapping] DROP CONSTRAINT IF EXISTS [DF_Menu_Role_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Primary]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Primary] DROP CONSTRAINT IF EXISTS [DF_PrimaryMenu_MenuCode]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Master_LookUp]') AND type in (N'U'))
ALTER TABLE [dbo].[Master_LookUp] DROP CONSTRAINT IF EXISTS [DF_MasterLookUp_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Language]') AND type in (N'U'))
ALTER TABLE [dbo].[Language] DROP CONSTRAINT IF EXISTS [DF_Language_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment_AreasOfStudy_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] DROP CONSTRAINT IF EXISTS [DF_Enrollment_AreasOfStudy_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enrollment]') AND type in (N'U'))
ALTER TABLE [dbo].[Enrollment] DROP CONSTRAINT IF EXISTS [DF_Enrollment_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Courses]') AND type in (N'U'))
ALTER TABLE [dbo].[Courses] DROP CONSTRAINT IF EXISTS [DF_Courses_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course_Related_LookUp]') AND type in (N'U'))
ALTER TABLE [dbo].[Course_Related_LookUp] DROP CONSTRAINT IF EXISTS [DF_Course_LookUp_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
ALTER TABLE [dbo].[Country] DROP CONSTRAINT IF EXISTS [DF_Country_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Section]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Section] DROP CONSTRAINT IF EXISTS [DF_Class_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Class_Period_Schedule]') AND type in (N'U'))
ALTER TABLE [dbo].[Class_Period_Schedule] DROP CONSTRAINT IF EXISTS [DF_Period_Schedule_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus_Group_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus_Group_Mapping] DROP CONSTRAINT IF EXISTS [DF_Campus_Group_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus_Group]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus_Group] DROP CONSTRAINT IF EXISTS [DF_Campus_Group_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Campus]') AND type in (N'U'))
ALTER TABLE [dbo].[Campus] DROP CONSTRAINT IF EXISTS [DF_Campus_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attendance]') AND type in (N'U'))
ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT IF EXISTS [DF_Attendance_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study_Course_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] DROP CONSTRAINT IF EXISTS [DF_Area_Of_Study_Course_Mapping_IsDeleted]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Of_Study]') AND type in (N'U'))
ALTER TABLE [dbo].[Area_Of_Study] DROP CONSTRAINT IF EXISTS [DF_Area_Of_Study_IsDeleted]
GO
/****** Object:  Index [unique_menurole]    Script Date: 05-01-2024 23:43:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Menu_Role_Mapping]') AND type in (N'U'))
ALTER TABLE [dbo].[Menu_Role_Mapping] DROP CONSTRAINT IF EXISTS [unique_menurole]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[UserType]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Users]
GO
/****** Object:  Table [dbo].[Test_Score]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Test_Score]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Test]
GO
/****** Object:  Table [dbo].[Term]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Term]
GO
/****** Object:  Table [dbo].[Student_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Student_Course_Mapping]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Student]
GO
/****** Object:  Table [dbo].[Status_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Status_LookUp]
GO
/****** Object:  Table [dbo].[State]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[State]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Staff]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Shift]
GO
/****** Object:  Table [dbo].[School]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[School]
GO
/****** Object:  Table [dbo].[Program_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Program_Course_Mapping]
GO
/****** Object:  Table [dbo].[Program_AreaOfStudy_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Program_AreaOfStudy_Mapping]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Program]
GO
/****** Object:  Table [dbo].[PreviousEducation]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[PreviousEducation]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Organization]
GO
/****** Object:  Table [dbo].[Menu_Secondary]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Menu_Secondary]
GO
/****** Object:  Table [dbo].[Menu_Role_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Menu_Role_Mapping]
GO
/****** Object:  Table [dbo].[Menu_Primary]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Menu_Primary]
GO
/****** Object:  Table [dbo].[Master_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Master_LookUp]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Language]
GO
/****** Object:  Table [dbo].[Enrollment_AreasOfStudy_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Enrollment_AreasOfStudy_Mapping]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Enrollment]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Courses]
GO
/****** Object:  Table [dbo].[Course_Related_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Course_Related_LookUp]
GO
/****** Object:  Table [dbo].[Course_Message]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Course_Message]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Country]
GO
/****** Object:  Table [dbo].[Class_Section]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Class_Section]
GO
/****** Object:  Table [dbo].[Class_Period_Schedule]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Class_Period_Schedule]
GO
/****** Object:  Table [dbo].[Campus_Group_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Campus_Group_Mapping]
GO
/****** Object:  Table [dbo].[Campus_Group]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Campus_Group]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Campus]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Attendance]
GO
/****** Object:  Table [dbo].[Area_Of_Study_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Area_Of_Study_Course_Mapping]
GO
/****** Object:  Table [dbo].[Area_Of_Study]    Script Date: 05-01-2024 23:43:20 ******/
DROP TABLE IF EXISTS [dbo].[Area_Of_Study]
GO
/****** Object:  Table [dbo].[Area_Of_Study]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area_Of_Study](
	[AreaStudyId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[AreaStudyTypeId] [int] NULL,
	[CIPCode2010Id] [int] NULL,
	[CIPCode2020Id] [int] NULL,
	[MinimumCumulativeGPA] [float] NULL,
	[AreaOfStudyCreditsRequired] [float] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Area_Of_Study] PRIMARY KEY CLUSTERED 
(
	[AreaStudyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area_Of_Study_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area_Of_Study_Course_Mapping](
	[AreaOfStudyCourseMappingId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[AreaOfStudyId] [int] NOT NULL,
	[CoursePoolType] [varchar](100) NULL,
	[CourseCatalogId] [int] NULL,
	[CourseCategoryId] [int] NULL,
	[CoursePoolId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Area_Of_Study_Course_Mapping] PRIMARY KEY CLUSTERED 
(
	[AreaOfStudyCourseMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[ClassPeriodScheduleId] [int] NULL,
	[ClassSectionId] [int] NULL,
	[EnrollmentId] [int] NULL,
	[StudentId] [int] NULL,
	[StudentCourseMappingId] [int] NULL,
	[AttendanceDate] [datetime] NULL,
	[MinutesAttended] [int] NULL,
	[MinutesAbsent] [int] NULL,
	[AttendedInd] [bit] NULL,
	[AbsentInd] [bit] NULL,
	[ExcuseInd] [bit] NULL,
	[MakeupInd] [bit] NULL,
	[ExternshipInd] [bit] NULL,
	[OnlineInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus](
	[CampusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[City] [varchar](100) NULL,
	[PostalCode] [varchar](100) NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL,
	[Email] [varchar](100) NULL,
	[FaxNumber] [varchar](100) NULL,
	[Phone] [varchar](100) NULL,
	[url] [varchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Campus] PRIMARY KEY CLUSTERED 
(
	[CampusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus_Group]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus_Group](
	[CampusGroupId] [int] IDENTITY(1,1) NOT NULL,
	[CampusName] [varchar](100) NOT NULL,
	[CampusDescription] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Campus_Group] PRIMARY KEY CLUSTERED 
(
	[CampusGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus_Group_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus_Group_Mapping](
	[CampusGroupMappingId] [int] NOT NULL,
	[CampusGroupId] [int] NULL,
	[CampusId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Campus_Group_Mapping] PRIMARY KEY CLUSTERED 
(
	[CampusGroupMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Period_Schedule]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Period_Schedule](
	[ClassPeriodScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[ClassSectionId] [int] NULL,
	[Name] [varchar](100) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[ScheduleDate] [datetime] NULL,
	[ClassScheduleStatusId] [int] NULL,
	[ClassDurationMinutes] [int] NULL,
	[StaffId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Period_Schedule] PRIMARY KEY CLUSTERED 
(
	[ClassPeriodScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Section]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Section](
	[ClassSectionId] [int] IDENTITY(1,1) NOT NULL,
	[CampusId] [int] NULL,
	[CourseId] [int] NULL,
	[PrimaryInstructionId] [int] NULL,
	[TermId] [int] NULL,
	[Code] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[AttendanceTypeId] [int] NULL,
	[DeliveryMethodId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CanceledInt] [bit] NULL,
	[StudentAllowedMax] [int] NULL,
	[StudentWalListMax] [int] NULL,
	[StudentRegisteredCnt] [int] NULL,
	[PassFailCourseInd] [bit] NULL,
	[ShiftId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassSectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[languageId] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Message]    Script Date: 05-01-2024 23:43:20 ******/
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
/****** Object:  Table [dbo].[Course_Related_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Related_LookUp](
	[CourseRelatedLookUpId] [int] IDENTITY(1,1) NOT NULL,
	[CourseRelatedLookUpType] [varchar](100) NULL,
	[CourseRelatedLookUpValue] [varchar](200) NULL,
	[LanguageId] [int] NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Course_LookUp] PRIMARY KEY CLUSTERED 
(
	[CourseRelatedLookUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[CourseCode] [varchar](200) NULL,
	[CourseName] [varchar](200) NOT NULL,
	[CourseDesc] [varchar](500) NULL,
	[CourseLevelSourceId] [int] NULL,
	[CourseTypeSourceId] [int] NOT NULL,
	[Credits] [float] NULL,
	[CreditHours] [float] NULL,
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
/****** Object:  Table [dbo].[Enrollment]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentId] [int] NOT NULL,
	[AdvisorStaffId] [int] NULL,
	[CampusId] [int] NULL,
	[ProgramId] [int] NULL,
	[SchoolId] [int] NULL,
	[ShiftId] [int] NULL,
	[StudentId] [int] NULL,
	[Description] [varchar](100) NULL,
	[EnrollmentNumber] [varchar](100) NULL,
	[Catalog] [varchar](100) NULL,
	[EnrollmentDate] [datetime] NULL,
	[DropDate] [datetime] NULL,
	[ExceptedStartDate] [datetime] NULL,
	[ActualStartDate] [datetime] NULL,
	[ExceptedGraduationDate] [datetime] NULL,
	[GraducationDate] [datetime] NULL,
	[EnrollmentStatusId] [int] NULL,
	[GradeLevelId] [int] NULL,
	[GradeScaleId] [int] NULL,
	[CreditsRequired] [float] NULL,
	[HoursRequired] [float] NULL,
	[TotalCreditsAttempt] [float] NULL,
	[TotalCreditsEarned] [float] NULL,
	[TotalHoursAttempt] [float] NULL,
	[TotalHoursEarned] [float] NULL,
	[DefaultEnrollmentInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment_AreasOfStudy_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment_AreasOfStudy_Mapping](
	[EnrollmentAreasOfStudyMappingId] [int] IDENTITY(1,1) NOT NULL,
	[EnrollmentId] [int] NULL,
	[AreaOfStudyId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Enrollment_AreasOfStudy_Mapping] PRIMARY KEY CLUSTERED 
(
	[EnrollmentAreasOfStudyMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Master_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Master_LookUp](
	[LookUpId] [int] IDENTITY(1,1) NOT NULL,
	[LookUpType] [varchar](100) NOT NULL,
	[LookUpValue] [varchar](100) NOT NULL,
	[LanguageId] [int] NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_MasterLookUp] PRIMARY KEY CLUSTERED 
(
	[LookUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Primary]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Primary](
	[PrimaryMenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuCode] [varchar](100) NOT NULL,
	[MenuUrl] [varchar](500) NULL,
	[MenuIcon] [varchar](200) NULL,
	[SequenceOrder] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PrimaryMenu] PRIMARY KEY CLUSTERED 
(
	[PrimaryMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Role_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Role_Mapping](
	[MenuRoleMappingId] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryMenuId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Menu_Role_Mapping] PRIMARY KEY CLUSTERED 
(
	[MenuRoleMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_Secondary]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_Secondary](
	[SecondaryMenuId] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryMenuId] [int] NOT NULL,
	[MenuName] [varchar](200) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SecondaryMenu] PRIMARY KEY CLUSTERED 
(
	[SecondaryMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](100) NULL,
	[Name] [varchar](1000) NOT NULL,
	[Code] [varchar](100) NULL,
	[Address] [varchar](200) NULL,
	[City] [varchar](100) NULL,
	[PostalCode] [varchar](100) NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL,
	[FaxNumber] [varchar](100) NULL,
	[Phone] [varchar](100) NULL,
	[AcademicYearEnd] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreviousEducation]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreviousEducation](
	[PreviousEducationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NULL,
	[StudentId] [int] NULL,
	[Major] [varchar](100) NULL,
	[StudentRank] [varchar](100) NULL,
	[GPA] [float] NULL,
	[DegreeId] [int] NULL,
	[EducationLevelId] [int] NULL,
	[GradeLevelId] [int] NULL,
	[EnrollmentDate] [datetime] NULL,
	[LastAttendedDate] [datetime] NULL,
	[GraduationDate] [datetime] NULL,
	[GraduationCompletedInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_PreviousEducation] PRIMARY KEY CLUSTERED 
(
	[PreviousEducationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program](
	[ProgramId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[Code] [varchar](100) NULL,
	[Name] [varchar](200) NULL,
	[VersionId] [int] NULL,
	[DegreeId] [int] NULL,
	[CIPCode2010] [int] NULL,
	[CIPCode2020] [int] NULL,
	[VersionCreditSystem] [varchar](100) NULL,
	[DegreeProgramInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED 
(
	[ProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program_AreaOfStudy_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program_AreaOfStudy_Mapping](
	[ProgramAreaOfStudyMappingId] [int] IDENTITY(1,1) NOT NULL,
	[MajorConcentrationId] [int] NULL,
	[ProgramId] [int] NULL,
	[AreaOfStudyId] [int] NULL,
	[CatalogId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Program_AreaOfStudy_Mapping] PRIMARY KEY CLUSTERED 
(
	[ProgramAreaOfStudyMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Program_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Program_Course_Mapping](
	[ProgramCourseMappingId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[ProgramId] [int] NOT NULL,
	[CourseCatalogId] [int] NULL,
	[CourseCategoryId] [int] NULL,
	[CoursePoolId] [int] NULL,
	[CoursePoolType] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Program_Course_Mapping] PRIMARY KEY CLUSTERED 
(
	[ProgramCourseMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[Code] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[SchoolStatusId] [int] NULL,
	[SchoolCategoryId] [int] NULL,
	[StatusHierarchy] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_School_Status] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[Code] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffId] [int] IDENTITY(1,1) NOT NULL,
	[CampusGroupId] [int] NULL,
	[Code] [varchar](200) NULL,
	[StaffName] [varchar](200) NULL,
	[FirstName] [varchar](200) NOT NULL,
	[LastName] [varchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[StateName] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[languageId] [int] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status_LookUp]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status_LookUp](
	[StatusLookUpId] [int] IDENTITY(1,1) NOT NULL,
	[StatusLookUpType] [varchar](100) NOT NULL,
	[StatusLookUpValue] [varchar](100) NOT NULL,
	[LanguageId] [int] NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_StatusLookUp] PRIMARY KEY CLUSTERED 
(
	[StatusLookUpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[AdminssionRepresentativeId] [int] NULL,
	[CampusId] [int] NULL,
	[ProgramId] [int] NULL,
	[SchoolId] [int] NULL,
	[StudentNumber] [varchar](100) NULL,
	[FullName] [varchar](200) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Title] [varchar](200) NULL,
	[Suffix] [varchar](100) NULL,
	[MaidenName] [varchar](100) NULL,
	[NickName] [varchar](100) NULL,
	[MiddleInitial] [varchar](100) NULL,
	[CitizenShipStatusId] [int] NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[PostalCode] [varchar](100) NULL,
	[EducationalLevelId] [int] NULL,
	[EthnicGroupId] [int] NULL,
	[GenderId] [int] NULL,
	[MaritalStatus] [bit] NULL,
	[NationalityId] [int] NULL,
	[ProgramGroupId] [int] NULL,
	[ProspectId] [int] NULL,
	[ProspectCategoryId] [int] NULL,
	[ProspectTypeId] [int] NULL,
	[OriginalExceptedStartDate] [datetime] NULL,
	[OriginalStartDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[HispanicInd] [int] NULL,
	[VeteranInd] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course_Mapping]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course_Mapping](
	[StudentCourseMappingId] [int] IDENTITY(1,1) NOT NULL,
	[CampusId] [int] NULL,
	[ClassSectionId] [int] NULL,
	[CourseId] [int] NOT NULL,
	[EnrollmentId] [int] NULL,
	[StudentId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[TermId] [int] NULL,
	[StudentCourseStatusId] [int] NULL,
	[CourseCreditHours] [float] NULL,
	[CourseCredit] [float] NULL,
	[MinusAbsent] [float] NULL,
	[MinusAttended] [float] NULL,
	[NumericGradeObtained] [float] NULL,
	[TotalGradeAttempted] [float] NULL,
	[TotalCreditsEarned] [float] NULL,
	[TotalHoursAttempted] [float] NULL,
	[TotalHoursEarned] [float] NULL,
	[GradeLetterCodeObtained] [varchar](100) NULL,
	[GradeNote] [varchar](100) NULL,
	[CourseCompletedDate] [datetime] NULL,
	[CourseDropDate] [datetime] NULL,
	[CourseLastAttendedDate] [datetime] NULL,
	[CourseRegisteredDate] [datetime] NULL,
	[CourseStartDate] [datetime] NULL,
	[ExpectedCourseEndDate] [datetime] NULL,
	[GradePostedDate] [datetime] NULL,
	[CourseCompletedStatusInd] [bit] NULL,
	[CourseCurrentStatusInd] [bit] NULL,
	[CourseDroppedStatusInd] [bit] NULL,
	[CourseFutureStatusInd] [bit] NULL,
	[CourseLeaveOfAbsenceStatusInd] [bit] NULL,
	[CourseScheduledStatusInd] [bit] NULL,
	[CourseRetakeInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Student_Course_Mapping] PRIMARY KEY CLUSTERED 
(
	[StudentCourseMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Term]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Term](
	[TermId] [int] NOT NULL,
	[CampusGroupId] [int] NULL,
	[ShiftId] [int] NULL,
	[Code] [varchar](100) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[TermCategoryId] [int] NULL,
	[TermSeasonId] [int] NULL,
	[MajorTermInd] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Term] PRIMARY KEY CLUSTERED 
(
	[TermId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] IDENTITY(1,1) NOT NULL,
	[TestParentId] [int] NULL,
	[CampusGroupId] [int] NOT NULL,
	[Code] [varchar](200) NULL,
	[Description] [varchar](500) NULL,
	[Type] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Score]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Score](
	[TestScoreId] [int] IDENTITY(1,1) NOT NULL,
	[EnrollmentId] [int] NOT NULL,
	[StudentId] [int] NULL,
	[TestId] [int] NULL,
	[TestScoreParentId] [int] NULL,
	[ScheduleExamDate] [datetime] NULL,
	[ExamTakeDate] [datetime] NULL,
	[TestScore] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Test_Score] PRIMARY KEY CLUSTERED 
(
	[TestScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[ProfilePicPath] [varchar](500) NULL,
	[PreFix] [varchar](50) NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Suffix] [varchar](50) NULL,
	[AdditionalName] [varchar](200) NULL,
	[PhoneNumber] [varchar](100) NOT NULL,
	[EmailAddress] [varchar](100) NOT NULL,
	[GenderId] [int] NULL,
	[Password] [varchar](100) NOT NULL,
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
	[UserName] [varchar](100) NOT NULL,
	[languageId] [int] NULL,
	[MiddleName] [varchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 05-01-2024 23:43:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](100) NOT NULL,
	[Description] [varchar](500) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([CountryId], [CountryName], [IsDeleted], [languageId]) VALUES (1, N'India', 0, 1)
GO
INSERT [dbo].[Country] ([CountryId], [CountryName], [IsDeleted], [languageId]) VALUES (2, N'USA', 0, 1)
GO
INSERT [dbo].[Country] ([CountryId], [CountryName], [IsDeleted], [languageId]) VALUES (3, N'China', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Course_Related_LookUp] ON 
GO
INSERT [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId], [CourseRelatedLookUpType], [CourseRelatedLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (1, N'CourseCategory', N'2023 Fall', 1, N'', 0)
GO
INSERT [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId], [CourseRelatedLookUpType], [CourseRelatedLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (2, N'CourseCategory', N'2023 Summer', 1, N'', 0)
GO
INSERT [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId], [CourseRelatedLookUpType], [CourseRelatedLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (3, N'CourseCategory', N'2022 Fall', 1, N'', 0)
GO
INSERT [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId], [CourseRelatedLookUpType], [CourseRelatedLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (4, N'CourseCategory', N'Upcoming Courses', 1, N'', 0)
GO
INSERT [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId], [CourseRelatedLookUpType], [CourseRelatedLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (5, N'CourseCategory', N'Current Courses', 1, N'', 0)
GO
SET IDENTITY_INSERT [dbo].[Course_Related_LookUp] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, 0, N'23FAH-4367', N'ACCT-509-T-6:00-8:50', N'Essentials of Accounting - 101H', NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (2, 0, N'23FAW-9953', N'ECON-520-M-6:00-8:50', N'Economics of High Performance - 103W', NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (3, 0, N'23FAW-9949', N'FIN-509-M-6:00-8:50', N'Essentials of Finance - 101W', NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (6, 0, N'23FAH-4453', N'MGT-548-M-6:00-8:50', N'Leading People &Organizations - 103H', NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (7, 0, N'23U2W-9435', N'DSIM-535-T-6:00-8:50', N'Quant Approach Dcsn-Making - 102W', NULL, 2, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (8, 0, N'23U2W-9436', N'DSIM-577-R-6:00-8:50', N'Managing Prod and Srvc Oper - 102W', NULL, 2, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Courses] ([CourseId], [CampusGroupId], [CourseCode], [CourseName], [CourseDesc], [CourseLevelSourceId], [CourseTypeSourceId], [Credits], [CreditHours], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (9, 0, N'Restore_4397', N'DoNotUseDSIM-307-W-6:00-8:50', N'Intro to Business Analytics - 101H', NULL, 3, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Language] ON 
GO
INSERT [dbo].[Language] ([LanguageId], [LanguageName], [IsDeleted]) VALUES (1, N'English', 0)
GO
INSERT [dbo].[Language] ([LanguageId], [LanguageName], [IsDeleted]) VALUES (2, N'French', 0)
GO
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
SET IDENTITY_INSERT [dbo].[Master_LookUp] ON 
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (1, N'language', N'English', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (2, N'language', N'Telugu', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (3, N'language', N'Hindi', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (4, N'gender', N'Male', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (5, N'gender', N'Female', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (6, N'gender', N'Transgender', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (7, N'educationlevel', N'Not disclosed', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (8, N'educationlevel', N'K-8', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (9, N'educationlevel', N'High School', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (10, N'educationlevel', N'Freshman', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (11, N'educationlevel', N'Sophomore', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (12, N'educationlevel', N'Junior', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (13, N'educationlevel', N'Senior', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (14, N'educationlevel', N'Graduate School', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (15, N'educationlevel', N'Post-Graduate School', 1, NULL, 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (16, N'nationality', N'Afghan', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (17, N'nationality', N'Belgian', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (18, N'nationality', N'Chinese', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (19, N'nationality', N'Indian', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (20, N'nationality', N'American', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (21, N'ethnicgroup', N'American Indian', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (22, N'ethnicgroup', N'Asian', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (23, N'ethnicgroup', N'Black or African American', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (24, N'ethnicgroup', N'White and European Americans', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (25, N'citizenshipstatus', N'U.S. Citizen', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (26, N'citizenshipstatus', N'Indian Citizen', 1, N'', 0)
GO
INSERT [dbo].[Master_LookUp] ([LookUpId], [LookUpType], [LookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (27, N'citizenshipstatus', N'China Citizen', 1, N'', 0)
GO
SET IDENTITY_INSERT [dbo].[Master_LookUp] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu_Primary] ON 
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (1, N'InstitutionPage', N'/dashboard/dashboard', N'/images/institution.png', 1, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (2, N'ProfilePage', N'/Profile/Profile', N'/images/profile.png', 2, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (3, N'ActivityStream', NULL, N'/images/activitystream.gif', 3, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (4, N'Courses', N'/Courses/courses', N'/images/course.png', 4, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (5, N'Orgnizations', NULL, N'/images/organization.png', 5, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (6, N'Calendar', NULL, N'/images/calendar.png', 6, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (7, N'Messages', NULL, N'/images/messages.png', 7, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (8, N'Grades', NULL, N'/images/grades.png', 8, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (9, N'Tools', NULL, N'/images/tools.png', 9, 0)
GO
INSERT [dbo].[Menu_Primary] ([PrimaryMenuId], [MenuCode], [MenuUrl], [MenuIcon], [SequenceOrder], [IsDeleted]) VALUES (10, N'Sign Out', N'/Logout', N'/images/signout.png', 10, 0)
GO
SET IDENTITY_INSERT [dbo].[Menu_Primary] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu_Role_Mapping] ON 
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (1, 1, 3, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (2, 3, 3, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (4, 4, 3, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (16, 3, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (17, 4, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (18, 5, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (19, 6, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (20, 7, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (21, 8, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (22, 9, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (23, 10, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (24, 1, 2, 0)
GO
INSERT [dbo].[Menu_Role_Mapping] ([MenuRoleMappingId], [PrimaryMenuId], [RoleId], [IsDeleted]) VALUES (25, 2, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Menu_Role_Mapping] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu_Secondary] ON 
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (1, 1, N'Institution Page', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (2, 2, N'Profile', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (3, 3, N'Activity Stream', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (4, 4, N'Courses', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (5, 5, N'Orgnizations', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (6, 6, N'Calendar', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (7, 7, N'Messages', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (8, 8, N'Grades', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (9, 9, N'Tools', 1, 0)
GO
INSERT [dbo].[Menu_Secondary] ([SecondaryMenuId], [PrimaryMenuId], [MenuName], [LanguageId], [IsDeleted]) VALUES (10, 10, N'Sign Out', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Menu_Secondary] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (1, NULL, N'Staff_001', N'Prasad', N'R', N'Prasad', 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (2, NULL, N'Staff_002', N'Ashok Nallamalli', N'Ashok', N'Nallamalli', 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (3, NULL, N'Staff_003', N'Anil Kella', N'Anil', N'Kella', 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (4, NULL, N'Staff_004', N'Sruthi P', N'Sruthi', N'p', 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (5, NULL, N'Staff_005', N'Raghu P', N'Raghu', N'p', 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Staff] ([StaffId], [CampusGroupId], [Code], [StaffName], [FirstName], [LastName], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (6, NULL, N'Staff_6', N'RRakesh', N'Rakesh', N'R', 0, NULL, NULL, NULL, NULL, 7)
GO
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([StateId], [CountryId], [StateName], [IsDeleted], [languageId]) VALUES (1, 1, N'hyderabad', 0, 1)
GO
INSERT [dbo].[State] ([StateId], [CountryId], [StateName], [IsDeleted], [languageId]) VALUES (2, 1, N'Bangalore', 0, 1)
GO
INSERT [dbo].[State] ([StateId], [CountryId], [StateName], [IsDeleted], [languageId]) VALUES (3, 2, N'NewYork', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Status_LookUp] ON 
GO
INSERT [dbo].[Status_LookUp] ([StatusLookUpId], [StatusLookUpType], [StatusLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (1, N'CourseStatus', N'Open', 1, N'', 0)
GO
INSERT [dbo].[Status_LookUp] ([StatusLookUpId], [StatusLookUpType], [StatusLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (2, N'CourseStatus', N'Private', 1, N'', 0)
GO
INSERT [dbo].[Status_LookUp] ([StatusLookUpId], [StatusLookUpType], [StatusLookUpValue], [LanguageId], [Description], [IsDeleted]) VALUES (3, N'CourseStatus', N'Completed', 1, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Status_LookUp] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([StudentId], [AdminssionRepresentativeId], [CampusId], [ProgramId], [SchoolId], [StudentNumber], [FullName], [FirstName], [MiddleName], [LastName], [Title], [Suffix], [MaidenName], [NickName], [MiddleInitial], [CitizenShipStatusId], [CountryId], [StateId], [PostalCode], [EducationalLevelId], [EthnicGroupId], [GenderId], [MaritalStatus], [NationalityId], [ProgramGroupId], [ProspectId], [ProspectCategoryId], [ProspectTypeId], [OriginalExceptedStartDate], [OriginalStartDate], [StartDate], [LastActivityDate], [HispanicInd], [VeteranInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (1, 2, NULL, NULL, NULL, N'Student_001', N'Ashriya Mutyala', N'Ashriya', NULL, N'Mutyala', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, N'500018', NULL, NULL, 5, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [AdminssionRepresentativeId], [CampusId], [ProgramId], [SchoolId], [StudentNumber], [FullName], [FirstName], [MiddleName], [LastName], [Title], [Suffix], [MaidenName], [NickName], [MiddleInitial], [CitizenShipStatusId], [CountryId], [StateId], [PostalCode], [EducationalLevelId], [EthnicGroupId], [GenderId], [MaritalStatus], [NationalityId], [ProgramGroupId], [ProspectId], [ProspectCategoryId], [ProspectTypeId], [OriginalExceptedStartDate], [OriginalStartDate], [StartDate], [LastActivityDate], [HispanicInd], [VeteranInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (2, 2, NULL, NULL, NULL, N'Student_002', N'Koushal Kalaga', N'Koushal', NULL, N'Kalaga', NULL, NULL, NULL, NULL, NULL, NULL, 1, 2, N'530068', NULL, NULL, 4, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student] ([StudentId], [AdminssionRepresentativeId], [CampusId], [ProgramId], [SchoolId], [StudentNumber], [FullName], [FirstName], [MiddleName], [LastName], [Title], [Suffix], [MaidenName], [NickName], [MiddleInitial], [CitizenShipStatusId], [CountryId], [StateId], [PostalCode], [EducationalLevelId], [EthnicGroupId], [GenderId], [MaritalStatus], [NationalityId], [ProgramGroupId], [ProspectId], [ProspectCategoryId], [ProspectTypeId], [OriginalExceptedStartDate], [OriginalStartDate], [StartDate], [LastActivityDate], [HispanicInd], [VeteranInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserId]) VALUES (3, NULL, NULL, NULL, NULL, N'student_3', NULL, N'Rajesh', NULL, N'M', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, CAST(N'2024-01-04T23:14:23.850' AS DateTime), NULL, NULL, 8)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_Course_Mapping] ON 
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, NULL, NULL, 1, NULL, 1, 2, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (3, NULL, NULL, 2, NULL, 1, 3, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (4, NULL, NULL, 3, NULL, 1, 4, NULL, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (5, NULL, NULL, 6, NULL, 1, 4, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (6, NULL, NULL, 7, NULL, 1, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (7, NULL, NULL, 8, NULL, 1, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Student_Course_Mapping] ([StudentCourseMappingId], [CampusId], [ClassSectionId], [CourseId], [EnrollmentId], [StudentId], [StaffId], [TermId], [StudentCourseStatusId], [CourseCreditHours], [CourseCredit], [MinusAbsent], [MinusAttended], [NumericGradeObtained], [TotalGradeAttempted], [TotalCreditsEarned], [TotalHoursAttempted], [TotalHoursEarned], [GradeLetterCodeObtained], [GradeNote], [CourseCompletedDate], [CourseDropDate], [CourseLastAttendedDate], [CourseRegisteredDate], [CourseStartDate], [ExpectedCourseEndDate], [GradePostedDate], [CourseCompletedStatusInd], [CourseCurrentStatusInd], [CourseDroppedStatusInd], [CourseFutureStatusInd], [CourseLeaveOfAbsenceStatusInd], [CourseScheduledStatusInd], [CourseRetakeInd], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (8, NULL, NULL, 9, NULL, 1, 5, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Student_Course_Mapping] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (1, 1, NULL, NULL, N'Suresh', N'Kalage', NULL, N'Suresh Kalage', N'9742544910', N'suresh.kalaga@outlook.com', 4, N'12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'suresh', 2, NULL)
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (2, 3, NULL, N'Mr', N'Vivek ', N'Mutyala', NULL, N'Vivek Mutyala123', N'9949121113', N'vivekchowdarymutyala@gmail.com', 4, N'12345', N'B-Tech', N'www.mysite.com', NULL, N'Lingampally', N'RailVihar', N'500018', N'Hyderabad', N'Telegana', N'India', N'MyCompany', N'Senior Leader', N'Information', 0, NULL, NULL, NULL, NULL, N'vivek', 1, N'mutyala')
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (3, 1, N'', N'Mr', N'anil1', N'kella', N'Mr', N'anil kella', N'9866537676', N'anil@gmail.com', 4, N'12345', N'', N'', N'', N'lingampally', N'', N'', N'', N'', N'', N'', N'Lead', N'IT', 0, 1, CAST(N'2023-12-06T00:00:00.000' AS DateTime), 1, CAST(N'2023-12-06T00:00:00.000' AS DateTime), N'anil', 2, NULL)
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (4, 3, NULL, NULL, N'kumar', N'l', N's', N'kumar m', N'12345', N'kumar@gmail.com', 4, N'12345', NULL, NULL, NULL, NULL, NULL, NULL, N'hyderabad', N'tg', N'india', N'sr', N'lead', N'it', 1, NULL, NULL, NULL, NULL, N'kumar', NULL, N'm')
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (5, 3, NULL, NULL, N'pushpa', N'Name', NULL, NULL, N'123', N'test@gmail.com', 4, N'12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, N'pushpa', NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (7, 2, NULL, NULL, N'Rakesh', N'R', NULL, NULL, N'9742544910', N'rakesh.r@gmail.com', 4, N'12345', N'Please select', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, CAST(N'2024-01-04T23:01:57.813' AS DateTime), NULL, NULL, N'rakesh', NULL, NULL)
GO
INSERT [dbo].[Users] ([UserId], [UserTypeId], [ProfilePicPath], [PreFix], [FirstName], [LastName], [Suffix], [AdditionalName], [PhoneNumber], [EmailAddress], [GenderId], [Password], [EducationLevel], [WebSite], [Fax], [Address1], [Address2], [PostalCode], [City], [State], [Country], [Company], [JobTitle], [Department], [IsDeleted], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [UserName], [languageId], [MiddleName]) VALUES (8, 3, NULL, NULL, N'Rajesh', N'M', NULL, NULL, N'9742544910', N'Rajesh.M@gmail.com', 4, N'12345', N'Please select', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, CAST(N'2024-01-04T23:14:23.850' AS DateTime), NULL, NULL, N'rajesh', NULL, NULL)
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
/****** Object:  Index [unique_menurole]    Script Date: 05-01-2024 23:43:21 ******/
ALTER TABLE [dbo].[Menu_Role_Mapping] ADD  CONSTRAINT [unique_menurole] UNIQUE NONCLUSTERED 
(
	[PrimaryMenuId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Area_Of_Study] ADD  CONSTRAINT [DF_Area_Of_Study_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] ADD  CONSTRAINT [DF_Area_Of_Study_Course_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Campus] ADD  CONSTRAINT [DF_Campus_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Campus_Group] ADD  CONSTRAINT [DF_Campus_Group_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Campus_Group_Mapping] ADD  CONSTRAINT [DF_Campus_Group_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Class_Period_Schedule] ADD  CONSTRAINT [DF_Period_Schedule_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Class_Section] ADD  CONSTRAINT [DF_Class_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Course_Related_LookUp] ADD  CONSTRAINT [DF_Course_LookUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [DF_Courses_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Enrollment] ADD  CONSTRAINT [DF_Enrollment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] ADD  CONSTRAINT [DF_Enrollment_AreasOfStudy_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Language] ADD  CONSTRAINT [DF_Language_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Master_LookUp] ADD  CONSTRAINT [DF_MasterLookUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Menu_Primary] ADD  CONSTRAINT [DF_PrimaryMenu_MenuCode]  DEFAULT ((0)) FOR [MenuCode]
GO
ALTER TABLE [dbo].[Menu_Role_Mapping] ADD  CONSTRAINT [DF_Menu_Role_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Menu_Secondary] ADD  CONSTRAINT [DF_SecondaryMenu_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF_Organization_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PreviousEducation] ADD  CONSTRAINT [DF_PreviousEducation_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Program] ADD  CONSTRAINT [DF_Program_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] ADD  CONSTRAINT [DF_Program_AreaOfStudy_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Program_Course_Mapping] ADD  CONSTRAINT [DF_Program_Course_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[School] ADD  CONSTRAINT [DF_School_Status_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Shift] ADD  CONSTRAINT [DF_Shift_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Staff] ADD  CONSTRAINT [DF_Staff_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Status_LookUp] ADD  CONSTRAINT [DF_StatusLookUp_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Student_Course_Mapping] ADD  CONSTRAINT [DF_Student_Course_Mapping_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Term] ADD  CONSTRAINT [DF_Term_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Test] ADD  CONSTRAINT [DF_Test_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Test_Score] ADD  CONSTRAINT [DF_Test_Score_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserType] ADD  CONSTRAINT [DF_UserType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Area_Of_Study]  WITH CHECK ADD  CONSTRAINT [FK_AreaOfStudy_CourseRealated_CampusGroupId] FOREIGN KEY([AreaStudyId])
REFERENCES [dbo].[Campus_Group] ([CampusGroupId])
GO
ALTER TABLE [dbo].[Area_Of_Study] CHECK CONSTRAINT [FK_AreaOfStudy_CourseRealated_CampusGroupId]
GO
ALTER TABLE [dbo].[Area_Of_Study]  WITH CHECK ADD  CONSTRAINT [FK_AreaofStudy_CourseRelated_CIPCode2010] FOREIGN KEY([CIPCode2010Id])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study] CHECK CONSTRAINT [FK_AreaofStudy_CourseRelated_CIPCode2010]
GO
ALTER TABLE [dbo].[Area_Of_Study]  WITH CHECK ADD  CONSTRAINT [FK_AreaofStudy_CourseRelated_CIPCode2020] FOREIGN KEY([CIPCode2020Id])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study] CHECK CONSTRAINT [FK_AreaofStudy_CourseRelated_CIPCode2020]
GO
ALTER TABLE [dbo].[Area_Of_Study]  WITH CHECK ADD  CONSTRAINT [FK_AreaOfStudy_CourseRelated_StudyTypeId] FOREIGN KEY([AreaStudyTypeId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study] CHECK CONSTRAINT [FK_AreaOfStudy_CourseRelated_StudyTypeId]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Area_Of_Study_Course_Mapping_AoS_AreaofStudyId] FOREIGN KEY([AreaOfStudyId])
REFERENCES [dbo].[Area_Of_Study] ([AreaStudyId])
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] CHECK CONSTRAINT [FK_Area_Of_Study_Course_Mapping_AoS_AreaofStudyId]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Area_Of_Study_Course_Mapping_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] CHECK CONSTRAINT [FK_Area_Of_Study_Course_Mapping_Course_CourseId]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCatalogId] FOREIGN KEY([CourseCatalogId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] CHECK CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCatalogId]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCategoryId] FOREIGN KEY([CourseCategoryId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] CHECK CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CourseCategoryId]
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CoursePoolId] FOREIGN KEY([CoursePoolId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Area_Of_Study_Course_Mapping] CHECK CONSTRAINT [FK_Area_Of_Study_Course_Mapping_CRelated_CoursePoolId]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_ClassSection_ClassSectionId] FOREIGN KEY([ClassSectionId])
REFERENCES [dbo].[Class_Section] ([ClassSectionId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_ClassSection_ClassSectionId]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_EnrollmentId_EnrollmentId] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollment] ([EnrollmentId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_EnrollmentId_EnrollmentId]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Student_StudentId]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_StudentCourseMappingId] FOREIGN KEY([StudentCourseMappingId])
REFERENCES [dbo].[Student_Course_Mapping] ([StudentCourseMappingId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_StudentCourseMappingId]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_ClassPeriodScheduleId] FOREIGN KEY([ClassPeriodScheduleId])
REFERENCES [dbo].[Class_Period_Schedule] ([ClassPeriodScheduleId])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_ClassPeriodScheduleId]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_CountryId]
GO
ALTER TABLE [dbo].[Campus]  WITH CHECK ADD  CONSTRAINT [FK_Campus_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Campus] CHECK CONSTRAINT [FK_Campus_StateId]
GO
ALTER TABLE [dbo].[Campus_Group_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Campus_Group_Mapping_Campus_Group] FOREIGN KEY([CampusGroupId])
REFERENCES [dbo].[Campus_Group] ([CampusGroupId])
GO
ALTER TABLE [dbo].[Campus_Group_Mapping] CHECK CONSTRAINT [FK_Campus_Group_Mapping_Campus_Group]
GO
ALTER TABLE [dbo].[Campus_Group_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Campus_Group_Mapping_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Campus_Group_Mapping] CHECK CONSTRAINT [FK_Campus_Group_Mapping_CampusId]
GO
ALTER TABLE [dbo].[Class_Period_Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Period_Schedule_ClassSection_ClassSectionId] FOREIGN KEY([ClassSectionId])
REFERENCES [dbo].[Class_Section] ([ClassSectionId])
GO
ALTER TABLE [dbo].[Class_Period_Schedule] CHECK CONSTRAINT [FK_Period_Schedule_ClassSection_ClassSectionId]
GO
ALTER TABLE [dbo].[Class_Period_Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Period_Schedule_Staff_Staffid] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[Class_Period_Schedule] CHECK CONSTRAINT [FK_Period_Schedule_Staff_Staffid]
GO
ALTER TABLE [dbo].[Class_Period_Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Period_Schedule_StatusLookUp_ScheduleStatusId] FOREIGN KEY([ClassScheduleStatusId])
REFERENCES [dbo].[Status_LookUp] ([StatusLookUpId])
GO
ALTER TABLE [dbo].[Class_Period_Schedule] CHECK CONSTRAINT [FK_Period_Schedule_StatusLookUp_ScheduleStatusId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_Campus_CampusId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_Course_courseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_Course_courseId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_CourseLookup_DeliveryMethodId] FOREIGN KEY([DeliveryMethodId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_CourseLookup_DeliveryMethodId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_CoursReleated_AttendanceTypeId] FOREIGN KEY([AttendanceTypeId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_CoursReleated_AttendanceTypeId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_Shift_ShiftId] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([ShiftId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_Shift_ShiftId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_Staff_PrimaryInstructionId] FOREIGN KEY([PrimaryInstructionId])
REFERENCES [dbo].[Staff] ([StaffId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_Staff_PrimaryInstructionId]
GO
ALTER TABLE [dbo].[Class_Section]  WITH CHECK ADD  CONSTRAINT [FK_Class_Term_TermId] FOREIGN KEY([TermId])
REFERENCES [dbo].[Term] ([TermId])
GO
ALTER TABLE [dbo].[Class_Section] CHECK CONSTRAINT [FK_Class_Term_TermId]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Conuntry_LanguageId] FOREIGN KEY([languageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Conuntry_LanguageId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CourseRelated_LevelSourceId] FOREIGN KEY([CourseLevelSourceId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CourseRelated_LevelSourceId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_CourseRelated_TypeSourceId] FOREIGN KEY([CourseTypeSourceId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_CourseRelated_TypeSourceId]
GO
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_EnrollmentAreaMapping_Enrollment_EnrollmentId] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollment] ([EnrollmentId])
GO
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] CHECK CONSTRAINT [FK_EnrollmentAreaMapping_Enrollment_EnrollmentId]
GO
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_EnrollmentAreasOfStudyMapping_AreaofStudyId] FOREIGN KEY([AreaOfStudyId])
REFERENCES [dbo].[Area_Of_Study] ([AreaStudyId])
GO
ALTER TABLE [dbo].[Enrollment_AreasOfStudy_Mapping] CHECK CONSTRAINT [FK_EnrollmentAreasOfStudyMapping_AreaofStudyId]
GO
ALTER TABLE [dbo].[Menu_Role_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Role_Mapping_Primary_PrimaryMenuId] FOREIGN KEY([PrimaryMenuId])
REFERENCES [dbo].[Menu_Primary] ([PrimaryMenuId])
GO
ALTER TABLE [dbo].[Menu_Role_Mapping] CHECK CONSTRAINT [FK_Menu_Role_Mapping_Primary_PrimaryMenuId]
GO
ALTER TABLE [dbo].[Menu_Role_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Role_Mapping_UserType_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[Menu_Role_Mapping] CHECK CONSTRAINT [FK_Menu_Role_Mapping_UserType_RoleId]
GO
ALTER TABLE [dbo].[Menu_Secondary]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Secondary_Language_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[Menu_Secondary] CHECK CONSTRAINT [FK_Menu_Secondary_Language_LanguageId]
GO
ALTER TABLE [dbo].[Menu_Secondary]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Secondary_Menu_PrimaryMenuId] FOREIGN KEY([PrimaryMenuId])
REFERENCES [dbo].[Menu_Primary] ([PrimaryMenuId])
GO
ALTER TABLE [dbo].[Menu_Secondary] CHECK CONSTRAINT [FK_Menu_Secondary_Menu_PrimaryMenuId]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_Country_CountryId]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK_Organization_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK_Organization_State_StateId]
GO
ALTER TABLE [dbo].[PreviousEducation]  WITH CHECK ADD  CONSTRAINT [FK_PreviousEducation_CourseRelated_GradeLevelId] FOREIGN KEY([GradeLevelId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[PreviousEducation] CHECK CONSTRAINT [FK_PreviousEducation_CourseRelated_GradeLevelId]
GO
ALTER TABLE [dbo].[PreviousEducation]  WITH CHECK ADD  CONSTRAINT [FK_PreviousEducation_CourseRelation_EducationLevelId] FOREIGN KEY([EducationLevelId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[PreviousEducation] CHECK CONSTRAINT [FK_PreviousEducation_CourseRelation_EducationLevelId]
GO
ALTER TABLE [dbo].[PreviousEducation]  WITH CHECK ADD  CONSTRAINT [FK_PreviousEducation_Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([OrganizationId])
GO
ALTER TABLE [dbo].[PreviousEducation] CHECK CONSTRAINT [FK_PreviousEducation_Organization_OrganizationId]
GO
ALTER TABLE [dbo].[PreviousEducation]  WITH CHECK ADD  CONSTRAINT [FK_PreviousEducation_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[PreviousEducation] CHECK CONSTRAINT [FK_PreviousEducation_Student_StudentId]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_CourseRelated_CIPCode2010] FOREIGN KEY([CIPCode2010])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_CourseRelated_CIPCode2010]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_CourseRelated_CIPCode2020] FOREIGN KEY([CIPCode2020])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_CourseRelated_CIPCode2020]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_CourseRelated_DegreeId] FOREIGN KEY([DegreeId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_CourseRelated_DegreeId]
GO
ALTER TABLE [dbo].[Program]  WITH CHECK ADD  CONSTRAINT [FK_Program_CourseRelated_VersionId] FOREIGN KEY([VersionId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program] CHECK CONSTRAINT [FK_Program_CourseRelated_VersionId]
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_AreaOfStudy_Mapping_AreaOfStudyId] FOREIGN KEY([AreaOfStudyId])
REFERENCES [dbo].[Area_Of_Study] ([AreaStudyId])
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] CHECK CONSTRAINT [FK_Program_AreaOfStudy_Mapping_AreaOfStudyId]
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_AreaOfStudy_Mapping_CourseRelated_CatalogId] FOREIGN KEY([CatalogId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] CHECK CONSTRAINT [FK_Program_AreaOfStudy_Mapping_CourseRelated_CatalogId]
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_AreaOfStudy_Mapping_ProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Program_AreaOfStudy_Mapping] CHECK CONSTRAINT [FK_Program_AreaOfStudy_Mapping_ProgramId]
GO
ALTER TABLE [dbo].[Program_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_Course_Mapping_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Program_Course_Mapping] CHECK CONSTRAINT [FK_Program_Course_Mapping_Course_CourseId]
GO
ALTER TABLE [dbo].[Program_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CoursecatalogId] FOREIGN KEY([CourseCatalogId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program_Course_Mapping] CHECK CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CoursecatalogId]
GO
ALTER TABLE [dbo].[Program_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CourseCategoryId] FOREIGN KEY([CourseCategoryId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program_Course_Mapping] CHECK CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CourseCategoryId]
GO
ALTER TABLE [dbo].[Program_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CoursePoolId] FOREIGN KEY([CoursePoolId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Program_Course_Mapping] CHECK CONSTRAINT [FK_Program_Course_Mapping_CourseRelated_CoursePoolId]
GO
ALTER TABLE [dbo].[Program_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Program_Course_Mapping_Program_ProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Program_Course_Mapping] CHECK CONSTRAINT [FK_Program_Course_Mapping_Program_ProgramId]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_CourseRelated_CategoryId] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_CourseRelated_CategoryId]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD  CONSTRAINT [FK_School_StatusLookUp_StatusId] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[Status_LookUp] ([StatusLookUpId])
GO
ALTER TABLE [dbo].[School] CHECK CONSTRAINT [FK_School_StatusLookUp_StatusId]
GO
ALTER TABLE [dbo].[Shift]  WITH CHECK ADD  CONSTRAINT [FK_Shift_GroupId] FOREIGN KEY([CampusGroupId])
REFERENCES [dbo].[Campus_Group] ([CampusGroupId])
GO
ALTER TABLE [dbo].[Shift] CHECK CONSTRAINT [FK_Shift_GroupId]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_CountryId] FOREIGN KEY([StateId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_CountryId]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_LanguageId] FOREIGN KEY([languageId])
REFERENCES [dbo].[Language] ([LanguageId])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_LanguageId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Campus_CampusId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Country_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Country_CountryId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseRelated_EducationLevelId] FOREIGN KEY([EducationalLevelId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseRelated_EducationLevelId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseRelated_EtnicGroupId] FOREIGN KEY([EthnicGroupId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseRelated_EtnicGroupId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseRelated_ProgramGroupId] FOREIGN KEY([ProgramGroupId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseRelated_ProgramGroupId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseRelated_ProspectCategoryId] FOREIGN KEY([ProspectCategoryId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseRelated_ProspectCategoryId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseReleated_ProspectId] FOREIGN KEY([ProspectId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseReleated_ProspectId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_CourseReleated_ProspectTypeId] FOREIGN KEY([ProspectTypeId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_CourseReleated_ProspectTypeId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_MasterLookup_GenderId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_MasterLookup_GenderId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_MasterLookUp_NationalityId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_MasterLookUp_NationalityId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Program_ProgramId] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([ProgramId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Program_ProgramId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_School_SchoolId] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([SchoolId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_School_SchoolId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_State_StateId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_State_StateId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_StatusLookup_CitizenShipStatId] FOREIGN KEY([CitizenShipStatusId])
REFERENCES [dbo].[Master_LookUp] ([LookUpId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_StatusLookup_CitizenShipStatId]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Campus_CampusId] FOREIGN KEY([CampusId])
REFERENCES [dbo].[Campus] ([CampusId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Campus_CampusId]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Class_Section] FOREIGN KEY([ClassSectionId])
REFERENCES [dbo].[Class_Section] ([ClassSectionId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Class_Section]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Courses]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Enrollment] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollment] ([EnrollmentId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Enrollment]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_StatusLookUp_CourseStatusId] FOREIGN KEY([StudentCourseStatusId])
REFERENCES [dbo].[Status_LookUp] ([StatusLookUpId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_StatusLookUp_CourseStatusId]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Student]
GO
ALTER TABLE [dbo].[Student_Course_Mapping]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_Mapping_Term] FOREIGN KEY([TermId])
REFERENCES [dbo].[Term] ([TermId])
GO
ALTER TABLE [dbo].[Student_Course_Mapping] CHECK CONSTRAINT [FK_Student_Course_Mapping_Term]
GO
ALTER TABLE [dbo].[Term]  WITH CHECK ADD  CONSTRAINT [FK_Term_CourseRelated_TermCategoryId] FOREIGN KEY([TermId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Term] CHECK CONSTRAINT [FK_Term_CourseRelated_TermCategoryId]
GO
ALTER TABLE [dbo].[Term]  WITH CHECK ADD  CONSTRAINT [FK_Term_CourseRelated_TermSeasonId] FOREIGN KEY([TermId])
REFERENCES [dbo].[Course_Related_LookUp] ([CourseRelatedLookUpId])
GO
ALTER TABLE [dbo].[Term] CHECK CONSTRAINT [FK_Term_CourseRelated_TermSeasonId]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_CampusGroupId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Campus_Group] ([CampusGroupId])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_CampusGroupId]
GO
ALTER TABLE [dbo].[Test_Score]  WITH CHECK ADD  CONSTRAINT [FK_Test_Score_Enrollment_EnrollmentId] FOREIGN KEY([EnrollmentId])
REFERENCES [dbo].[Enrollment] ([EnrollmentId])
GO
ALTER TABLE [dbo].[Test_Score] CHECK CONSTRAINT [FK_Test_Score_Enrollment_EnrollmentId]
GO
ALTER TABLE [dbo].[Test_Score]  WITH CHECK ADD  CONSTRAINT [FK_Test_Score_Same_TestScoreParentId] FOREIGN KEY([TestScoreParentId])
REFERENCES [dbo].[Test_Score] ([TestScoreId])
GO
ALTER TABLE [dbo].[Test_Score] CHECK CONSTRAINT [FK_Test_Score_Same_TestScoreParentId]
GO
ALTER TABLE [dbo].[Test_Score]  WITH CHECK ADD  CONSTRAINT [FK_Test_Score_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Test_Score] CHECK CONSTRAINT [FK_Test_Score_Student_StudentId]
GO
ALTER TABLE [dbo].[Test_Score]  WITH CHECK ADD  CONSTRAINT [FK_Test_Score_Test_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[Test] ([TestId])
GO
ALTER TABLE [dbo].[Test_Score] CHECK CONSTRAINT [FK_Test_Score_Test_TestId]
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
/****** Object:  StoredProcedure [dbo].[Get_AllCourses]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROC [dbo].[Get_AllCourses]   
AS  
SELECT cs.CourseId,
cs.CourseTypeSourceId As CourseGroupId,
crl.CourseRelatedLookUpValue As CourseGroupName,
cs.CourseCode,
cs.CourseName,
cs.CourseDesc,
cs.CreditHours,
cs.Credits,
Count(*) OVER(Partition BY cs.IsDeleted) AS TotalRecords
FROM dbo.courses cs
LEFT JOIN dbo.Course_Related_LookUp crl 
	ON crl.CourseRelatedLookUpId = cs.CourseTypeSourceId and crl.IsDeleted = 0
WHERE cs.IsDeleted = 0





GO
/****** Object:  StoredProcedure [dbo].[Get_AllMenus]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_AllMenus]
( @languageId INT )
AS  
SELECT mp.PrimaryMenuId,
	ms.MenuName,
	mp.MenuCode,
	mp.MenuUrl,
	mp.MenuIcon,
	mp.SequenceOrder
FROM [dbo].[Menu_Primary] mp
INNER JOIN [dbo].[Menu_Secondary] ms ON mp.PrimaryMenuId = ms.PrimaryMenuId and mp.IsDeleted = 0
WHERE mp.IsDeleted = 0 and ms.LanguageId = @languageId
ORDER BY SequenceOrder 





GO
/****** Object:  StoredProcedure [dbo].[Get_AllStaff]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[Get_AllStaff]   
AS  
	SELECT s.StaffId,
		s.Code,
		s.StaffName,
		s.FirstName,
		s.LastName,
		s.UserId,
		s.CreatedBy,
		s.CreatedDate,
		s.ModifyBy,
		s.ModifyDate,
		Count(*) OVER(Partition BY S.IsDeleted) AS TotalRecords
	FROM dbo.Staff s
	where s.IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[Get_AllStudents]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROC [dbo].[Get_AllStudents]   
AS  
	SELECT s.StudentId,
		   s.userId,
		CM.CampusId,
		p.programId,
		SH.SchoolId,
		s.StudentNumber,
		s.FirstName,
		s.MiddleName,
		s.LastName,
		s.FullName,
		s.AdminssionRepresentativeId,
		sf.StaffName As AdminssionReprestative,
		S.Title,
		S.Suffix,
		S.MaidenName,
		S.NickName,
		S.MiddleInitial,
		s.CitizenShipStatusId,
		s.CountryId,
		cu.CountryName,
		s.StateId,
		st.StateName,
		s.PostalCode,
		s.EducationalLevelId,
		s.EthnicGroupId,
		s.GenderId,
		ml.LookUpValue As Gender,
		s.MaritalStatus As IsMaritalStatus,
		CASE WHEN s.MaritalStatus = 1 THEN 'Yes' ELSE 'No' END  MaritalStatus,
		s.NationalityId,
        s.ProgramGroupId,
        s.ProspectId,
		s.ProspectCategoryId,
        s.ProspectTypeId,
        s.OriginalExceptedStartDate,
        s.OriginalStartDate,
        s.StartDate,
        s.LastActivityDate,
        s.HispanicInd,
        s.VeteranInd,
		s.CreatedBy,
		s.CreatedDate,
		s.ModifyBy,
		s.ModifyDate,
		Count(*) OVER(Partition BY S.IsDeleted) AS TotalRecords
	FROM dbo.Student S
	LEFT JOIN dbo.Staff SF ON SF.StaffId = s.AdminssionRepresentativeId AND sf.IsDeleted = 0
	LEFT JOIN dbo.Campus CM on CM.CampusId = s.CampusId and cm.IsDeleted = 0
	LEFT JOIN dbo.Program P on P.ProgramId = s.ProgramId and p.IsDeleted = 0
	LEFT JOIN dbo.school SH on SH.schoolId = S.schoolId and SH.IsDeleted = 0
	LEFT JOIN dbo.Country cu on cu.CountryId = s.CountryId and cu.IsDeleted = 0
	LEFT JOIN dbo.State st on st.StateId = s.StateId and cu.IsDeleted = 0
	LEFT JOIN dbo.Master_LookUp ml on ml.LookUpId = s.GenderId and ml.IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[Get_AllUserDetails]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[Get_AllUserDetails]     
AS    
SELECT U.*,     
 GN.LookUpValue As Gender,    
 LG.LookUpValue As UserLanguage,
 UT.UserType,
 Count(*) OVER(Partition BY U.IsDeleted) AS TotalRecords  
FROM [DBO].[Users] U    
LEFT JOIN [DBO].master_Lookup GN on GN.LookUpId = u.GenderId and GN.IsDeleted = 0 and GN.LookUpType = 'gender'    
LEFT JOIN [DBO].master_Lookup LG on LG.LookUpId = u.languageId and LG.IsDeleted = 0 and LG.LookUpType = 'language'
LEFT JOIN [DBO].usertype UT on UT.userTypeId = u.UserTypeId 
WHERE U.IsDeleted = 0 OR U.IsDeleted IS NULL



CREATE UNIQUE INDEX unique_EmailAddress
ON users (EmailAddress); 

CREATE UNIQUE INDEX unique_username
ON users (username); 

ALTER TABLE STAFF ALTER COLUMN FIRSTNAME varchar(200) NOT NULL
ALTER TABLE STAFF ALTER COLUMN LASTNAME varchar(200) NOT NULL
ALTER TABLE STAFF ALTER COLUMN USERID INT NOT NULL

ALTER TABLE student ALTER COLUMN FIRSTNAME varchar(200) NOT NULL
ALTER TABLE student ALTER COLUMN LASTNAME varchar(200) NOT NULL
ALTER TABLE student ALTER COLUMN USERID INT NOT NULL
GO
/****** Object:  StoredProcedure [dbo].[Get_CourseRelatedLookUpValues]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE       PROC [dbo].[Get_CourseRelatedLookUpValues] 
(@lookUpType VARCHAR(50),
 @languageId INT
)
AS
SELECT CRL.CourseRelatedLookUpId As Id,
	   CRL.CourseRelatedLookUpValue As Name
FROM [DBO].Course_Related_LookUp CRL 
WHERE CRL.IsDeleted = 0 
and CRL.CourseRelatedLookUpType = @lookUpType
and crl.LanguageId = @languageId
GO
/****** Object:  StoredProcedure [dbo].[Get_MasterLookUpValues]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROC [dbo].[Get_MasterLookUpValues] 
(@lookUpType VARCHAR(50),
@languageId INT)
AS
SELECT ML.lookUpId As Id,
	   ML.LookUPValue As Name
FROM 
[DBO].master_Lookup ML 
WHERE ML.IsDeleted = 0 
and ML.LookUpType = @lookUpType
AND ML.LanguageId = @languageId
GO
/****** Object:  StoredProcedure [dbo].[Get_RoleMenus]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
CREATE   PROC [dbo].[Get_RoleMenus]    
( @roleId INT,    
@languageId INT )    
AS      
SELECT mp.PrimaryMenuId,    
 mrp.RoleId,    
 ut.UserType As RoleName,    
 ms.MenuName,    
 mp.MenuCode,    
 mp.MenuUrl,    
 mp.MenuIcon,    
 mp.SequenceOrder
FROM [dbo].Menu_Role_Mapping mrp    
inner join [dbo].[Menu_Primary] mp on mp.PrimaryMenuId = mrp.PrimaryMenuId and mp.IsDeleted = 0    
INNER JOIN [dbo].[Menu_Secondary] ms ON mp.PrimaryMenuId = ms.PrimaryMenuId and mp.IsDeleted = 0    
inner join [dbo].[UserType] ut on ut.UserTypeId = mrp.RoleId and ut.IsDeleted = 0    
WHERE mrp.RoleId = @roleId and ms.LanguageId = @languageId and mrp.IsDeleted = 0     
ORDER BY SequenceOrder     
    
    
    
    
GO
/****** Object:  StoredProcedure [dbo].[Get_StudentCourseDetails]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_StudentCourseDetails] 
(@studentId INT)
AS
SELECT 
CR.CourseId,
CR.CourseTypeSourceId,
CRL.CourseRelatedLookUpValue As CourseType,
CR.CourseCode,
CR.CourseName,
CR.CourseDesc,
ST.StudentId,
ST.StudentNumber,
ST.FullName As StudentName,
SF.StaffId,
SF.StaffName,
SL.StatusLookUpValue As StudentCourseStatus
FROM [dbo].[Courses] CR
INNER JOIN [dbo].[Course_Related_LookUp] CRL ON crl.CourseRelatedLookUpId = cr.CourseTypeSourceId and crl.IsDeleted = 0
INNER JOIN [dbo].[Student_Course_Mapping] SCM ON SCM.CourseId = cr.CourseId and crl.IsDeleted = 0
INNER JOIN [dbo].[Student] ST on ST.StudentId = scm.StudentId and crl.IsDeleted = 0
INNER JOIN [dbo].[Staff] SF on SF.StaffId = SCM.StaffId and crl.IsDeleted = 0
INNER JOIN [dbo].[Status_LookUp] SL on SL.StatusLookUpId = SCM.StudentCourseStatusId and crl.IsDeleted = 0
GO
/****** Object:  StoredProcedure [dbo].[Get_UserDetails]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[Get_UserDetails]   
(@userId INT)  
AS  
SELECT U.*,   
 GN.LookUpValue As Gender,  
 LG.LookUpValue As UserLanguage,
 UT.UserType
FROM [DBO].[Users] U
JOIN [DBO].[UserType] UT ON U.UserTypeId = UT.UserTypeId
LEFT JOIN [DBO].master_Lookup GN on GN.LookUpId = u.GenderId and GN.IsDeleted = 0 and GN.LookUpType = 'gender'  
LEFT JOIN [DBO].master_Lookup LG on LG.LookUpId = u.languageId and LG.IsDeleted = 0 and LG.LookUpType = 'language'  
WHERE U.UserId = @userId 
GO
/****** Object:  StoredProcedure [dbo].[Get_UserLoginDetails]    Script Date: 05-01-2024 23:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROC [dbo].[Get_UserLoginDetails]   
(@UserName VARCHAR(50),@Password VARCHAR(50))  
AS  
SELECT U.UserId,  
    U.UserName,  
    UT.UserTypeId,  
    UT.UserType UserTypeName,
	U.FirstName+' '+U.LastName AS FullName
FROM [DBO].[Users] U  
JOIN [DBO].UserType UT ON U.UserTypeId = UT.UserTypeId  
WHERE UserName = @UserName   
 AND [Password] = @Password  
 AND U.IsDeleted = 0
GO
