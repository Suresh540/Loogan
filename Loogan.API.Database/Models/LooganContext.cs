using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Loogan.API.Database.Models;

public partial class LooganContext : DbContext
{
    private readonly string? _connectionString;
    public LooganContext(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<AreaOfStudy> AreaOfStudies { get; set; }

    public virtual DbSet<AreaOfStudyCourseMapping> AreaOfStudyCourseMappings { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<CampusGroup> CampusGroups { get; set; }

    public virtual DbSet<CampusGroupMapping> CampusGroupMappings { get; set; }

    public virtual DbSet<ClassPeriodSchedule> ClassPeriodSchedules { get; set; }

    public virtual DbSet<ClassSection> ClassSections { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseMessage> CourseMessages { get; set; }

    public virtual DbSet<CourseRelatedLookUp> CourseRelatedLookUps { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<EnrollmentAreasOfStudyMapping> EnrollmentAreasOfStudyMappings { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<MasterLookUp> MasterLookUps { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<PreviousEducation> PreviousEducations { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramAreaOfStudyMapping> ProgramAreaOfStudyMappings { get; set; }

    public virtual DbSet<ProgramCourseMapping> ProgramCourseMappings { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StatusLookUp> StatusLookUps { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourseMapping> StudentCourseMappings { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestScore> TestScores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlServer(_connectionString);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaOfStudy>(entity =>
        {
            entity.HasKey(e => e.AreaStudyId);

            entity.ToTable("Area_Of_Study");

            entity.Property(e => e.AreaStudyId).ValueGeneratedOnAdd();
            entity.Property(e => e.Cipcode2010Id).HasColumnName("CIPCode2010Id");
            entity.Property(e => e.Cipcode2020Id).HasColumnName("CIPCode2020Id");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.MinimumCumulativeGpa).HasColumnName("MinimumCumulativeGPA");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AreaStudy).WithOne(p => p.AreaOfStudy)
                .HasForeignKey<AreaOfStudy>(d => d.AreaStudyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaOfStudy_CourseRealated_CampusGroupId");

            entity.HasOne(d => d.AreaStudyType).WithMany(p => p.AreaOfStudyAreaStudyTypes)
                .HasForeignKey(d => d.AreaStudyTypeId)
                .HasConstraintName("FK_AreaOfStudy_CourseRelated_StudyTypeId");

            entity.HasOne(d => d.Cipcode2010).WithMany(p => p.AreaOfStudyCipcode2010s)
                .HasForeignKey(d => d.Cipcode2010Id)
                .HasConstraintName("FK_AreaofStudy_CourseRelated_CIPCode2010");

            entity.HasOne(d => d.Cipcode2020).WithMany(p => p.AreaOfStudyCipcode2020s)
                .HasForeignKey(d => d.Cipcode2020Id)
                .HasConstraintName("FK_AreaofStudy_CourseRelated_CIPCode2020");
        });

        modelBuilder.Entity<AreaOfStudyCourseMapping>(entity =>
        {
            entity.ToTable("Area_Of_Study_Course_Mapping");

            entity.Property(e => e.AreaOfStudyCourseMappingId).ValueGeneratedNever();
            entity.Property(e => e.CoursePoolType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.AreaOfStudy).WithMany(p => p.AreaOfStudyCourseMappings)
                .HasForeignKey(d => d.AreaOfStudyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Area_Of_Study_Course_Mapping_AoS_AreaofStudyId");

            entity.HasOne(d => d.CourseCatalog).WithMany(p => p.AreaOfStudyCourseMappingCourseCatalogs)
                .HasForeignKey(d => d.CourseCatalogId)
                .HasConstraintName("FK_Area_Of_Study_Course_Mapping_CRelated_CourseCatalogId");

            entity.HasOne(d => d.CourseCategory).WithMany(p => p.AreaOfStudyCourseMappingCourseCategories)
                .HasForeignKey(d => d.CourseCategoryId)
                .HasConstraintName("FK_Area_Of_Study_Course_Mapping_CRelated_CourseCategoryId");

            entity.HasOne(d => d.Course).WithMany(p => p.AreaOfStudyCourseMappings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Area_Of_Study_Course_Mapping_Course_CourseId");

            entity.HasOne(d => d.CoursePool).WithMany(p => p.AreaOfStudyCourseMappingCoursePools)
                .HasForeignKey(d => d.CoursePoolId)
                .HasConstraintName("FK_Area_Of_Study_Course_Mapping_CRelated_CoursePoolId");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.ClassPeriodSchedule).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.ClassPeriodScheduleId)
                .HasConstraintName("FK_ClassPeriodScheduleId");

            entity.HasOne(d => d.ClassSection).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.ClassSectionId)
                .HasConstraintName("FK_Attendance_ClassSection_ClassSectionId");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Attendance_EnrollmentId_EnrollmentId");

            entity.HasOne(d => d.StudentCourseMapping).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentCourseMappingId)
                .HasConstraintName("FK_Attendance_StudentCourseMappingId");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.ToTable("Campus");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.Country).WithMany(p => p.Campuses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Campus_CountryId");

            entity.HasOne(d => d.State).WithMany(p => p.Campuses)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Campus_StateId");
        });

        modelBuilder.Entity<CampusGroup>(entity =>
        {
            entity.ToTable("Campus_Group");

            entity.Property(e => e.CampusDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CampusName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CampusGroupMapping>(entity =>
        {
            entity.ToTable("Campus_Group_Mapping");

            entity.Property(e => e.CampusGroupMappingId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.CampusGroup).WithMany(p => p.CampusGroupMappings)
                .HasForeignKey(d => d.CampusGroupId)
                .HasConstraintName("FK_Campus_Group_Mapping_Campus_Group");

            entity.HasOne(d => d.Campus).WithMany(p => p.CampusGroupMappings)
                .HasForeignKey(d => d.CampusId)
                .HasConstraintName("FK_Campus_Group_Mapping_CampusId");
        });

        modelBuilder.Entity<ClassPeriodSchedule>(entity =>
        {
            entity.HasKey(e => e.ClassPeriodScheduleId).HasName("PK_Period_Schedule");

            entity.ToTable("Class_Period_Schedule");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.ClassScheduleStatus).WithMany(p => p.ClassPeriodSchedules)
                .HasForeignKey(d => d.ClassScheduleStatusId)
                .HasConstraintName("FK_Period_Schedule_StatusLookUp_ScheduleStatusId");

            entity.HasOne(d => d.ClassSection).WithMany(p => p.ClassPeriodSchedules)
                .HasForeignKey(d => d.ClassSectionId)
                .HasConstraintName("FK_Period_Schedule_ClassSection_ClassSectionId");

            entity.HasOne(d => d.Staff).WithMany(p => p.ClassPeriodSchedules)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_Period_Schedule_Staff_Staffid");
        });

        modelBuilder.Entity<ClassSection>(entity =>
        {
            entity.HasKey(e => e.ClassSectionId).HasName("PK_Class");

            entity.ToTable("Class_Section");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.AttendanceType).WithMany(p => p.ClassSectionAttendanceTypes)
                .HasForeignKey(d => d.AttendanceTypeId)
                .HasConstraintName("FK_Class_CoursReleated_AttendanceTypeId");

            entity.HasOne(d => d.Campus).WithMany(p => p.ClassSections)
                .HasForeignKey(d => d.CampusId)
                .HasConstraintName("FK_Class_Campus_CampusId");

            entity.HasOne(d => d.Course).WithMany(p => p.ClassSections)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Class_Course_courseId");

            entity.HasOne(d => d.DeliveryMethod).WithMany(p => p.ClassSectionDeliveryMethods)
                .HasForeignKey(d => d.DeliveryMethodId)
                .HasConstraintName("FK_Class_CourseLookup_DeliveryMethodId");

            entity.HasOne(d => d.PrimaryInstruction).WithMany(p => p.ClassSections)
                .HasForeignKey(d => d.PrimaryInstructionId)
                .HasConstraintName("FK_Class_Staff_PrimaryInstructionId");

            entity.HasOne(d => d.Shift).WithMany(p => p.ClassSections)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_Class_Shift_ShiftId");

            entity.HasOne(d => d.Term).WithMany(p => p.ClassSections)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK_Class_Term_TermId");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseCode)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CourseDesc)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.CourseLevelSource).WithMany(p => p.CourseCourseLevelSources)
                .HasForeignKey(d => d.CourseLevelSourceId)
                .HasConstraintName("FK_Courses_CourseRelated_LevelSourceId");

            entity.HasOne(d => d.CourseTypeSource).WithMany(p => p.CourseCourseTypeSources)
                .HasForeignKey(d => d.CourseTypeSourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_CourseRelated_TypeSourceId");
        });

        modelBuilder.Entity<CourseMessage>(entity =>
        {
            entity.ToTable("Course_Message");
        });

        modelBuilder.Entity<CourseRelatedLookUp>(entity =>
        {
            entity.HasKey(e => e.CourseRelatedLookUpId).HasName("PK_Course_LookUp");

            entity.ToTable("Course_Related_LookUp");

            entity.Property(e => e.CourseRelatedLookUpType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CourseRelatedLookUpValue)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).ValueGeneratedNever();
            entity.Property(e => e.ActualStartDate).HasColumnType("datetime");
            entity.Property(e => e.Catalog)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DropDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExceptedGraduationDate).HasColumnType("datetime");
            entity.Property(e => e.ExceptedStartDate).HasColumnType("datetime");
            entity.Property(e => e.GraducationDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EnrollmentAreasOfStudyMapping>(entity =>
        {
            entity.ToTable("Enrollment_AreasOfStudy_Mapping");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.AreaOfStudy).WithMany(p => p.EnrollmentAreasOfStudyMappings)
                .HasForeignKey(d => d.AreaOfStudyId)
                .HasConstraintName("FK_EnrollmentAreasOfStudyMapping_AreaofStudyId");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.EnrollmentAreasOfStudyMappings)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_EnrollmentAreaMapping_Enrollment_EnrollmentId");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LanguageName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MasterLookUp>(entity =>
        {
            entity.HasKey(e => e.LookUpId).HasName("PK_MasterLookUp");

            entity.ToTable("Master_LookUp");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LookUpType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LookUpValue)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.ToTable("Organization");

            entity.Property(e => e.AcademicYearEnd)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FaxNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Organizations).HasForeignKey(d => d.CountryId);

            entity.HasOne(d => d.State).WithMany(p => p.Organizations).HasForeignKey(d => d.StateId);
        });

        modelBuilder.Entity<PreviousEducation>(entity =>
        {
            entity.ToTable("PreviousEducation");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.GraduationDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastAttendedDate).HasColumnType("datetime");
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.StudentRank)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.PreviousEducationEducationLevels)
                .HasForeignKey(d => d.EducationLevelId)
                .HasConstraintName("FK_PreviousEducation_CourseRelation_EducationLevelId");

            entity.HasOne(d => d.GradeLevel).WithMany(p => p.PreviousEducationGradeLevels)
                .HasForeignKey(d => d.GradeLevelId)
                .HasConstraintName("FK_PreviousEducation_CourseRelated_GradeLevelId");

            entity.HasOne(d => d.Organization).WithMany(p => p.PreviousEducations).HasForeignKey(d => d.OrganizationId);

            entity.HasOne(d => d.Student).WithMany(p => p.PreviousEducations).HasForeignKey(d => d.StudentId);
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.ToTable("Program");

            entity.Property(e => e.Cipcode2010).HasColumnName("CIPCode2010");
            entity.Property(e => e.Cipcode2020).HasColumnName("CIPCode2020");
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.VersionCreditSystem)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Cipcode2010Navigation).WithMany(p => p.ProgramCipcode2010Navigations)
                .HasForeignKey(d => d.Cipcode2010)
                .HasConstraintName("FK_Program_CourseRelated_CIPCode2010");

            entity.HasOne(d => d.Cipcode2020Navigation).WithMany(p => p.ProgramCipcode2020Navigations)
                .HasForeignKey(d => d.Cipcode2020)
                .HasConstraintName("FK_Program_CourseRelated_CIPCode2020");

            entity.HasOne(d => d.Degree).WithMany(p => p.ProgramDegrees)
                .HasForeignKey(d => d.DegreeId)
                .HasConstraintName("FK_Program_CourseRelated_DegreeId");

            entity.HasOne(d => d.Version).WithMany(p => p.ProgramVersions)
                .HasForeignKey(d => d.VersionId)
                .HasConstraintName("FK_Program_CourseRelated_VersionId");
        });

        modelBuilder.Entity<ProgramAreaOfStudyMapping>(entity =>
        {
            entity.ToTable("Program_AreaOfStudy_Mapping");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.AreaOfStudy).WithMany(p => p.ProgramAreaOfStudyMappings)
                .HasForeignKey(d => d.AreaOfStudyId)
                .HasConstraintName("FK_Program_AreaOfStudy_Mapping_AreaOfStudyId");

            entity.HasOne(d => d.Catalog).WithMany(p => p.ProgramAreaOfStudyMappings)
                .HasForeignKey(d => d.CatalogId)
                .HasConstraintName("FK_Program_AreaOfStudy_Mapping_CourseRelated_CatalogId");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramAreaOfStudyMappings)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK_Program_AreaOfStudy_Mapping_ProgramId");
        });

        modelBuilder.Entity<ProgramCourseMapping>(entity =>
        {
            entity.ToTable("Program_Course_Mapping");

            entity.Property(e => e.CoursePoolType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.CourseCatalog).WithMany(p => p.ProgramCourseMappingCourseCatalogs)
                .HasForeignKey(d => d.CourseCatalogId)
                .HasConstraintName("FK_Program_Course_Mapping_CourseRelated_CoursecatalogId");

            entity.HasOne(d => d.CourseCategory).WithMany(p => p.ProgramCourseMappingCourseCategories)
                .HasForeignKey(d => d.CourseCategoryId)
                .HasConstraintName("FK_Program_Course_Mapping_CourseRelated_CourseCategoryId");

            entity.HasOne(d => d.Course).WithMany(p => p.ProgramCourseMappings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Program_Course_Mapping_Course_CourseId");

            entity.HasOne(d => d.CoursePool).WithMany(p => p.ProgramCourseMappingCoursePools)
                .HasForeignKey(d => d.CoursePoolId)
                .HasConstraintName("FK_Program_Course_Mapping_CourseRelated_CoursePoolId");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramCourseMappings)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK_School_Status");

            entity.ToTable("School");

            entity.Property(e => e.SchoolId).ValueGeneratedOnAdd();
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.SchoolNavigation).WithOne(p => p.School)
                .HasForeignKey<School>(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_CourseRelated_CategoryId");

            entity.HasOne(d => d.School1).WithOne(p => p.School)
                .HasForeignKey<School>(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_School_StatusLookUp_StatusId");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift");

            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.CampusGroup).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.CampusGroupId)
                .HasConstraintName("FK_Shift_GroupId");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.StaffName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.Property(e => e.StateId).ValueGeneratedOnAdd();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.StateNavigation).WithOne(p => p.State)
                .HasForeignKey<State>(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_State_CountryId");
        });

        modelBuilder.Entity<StatusLookUp>(entity =>
        {
            entity.HasKey(e => e.StatusLookUpId).HasName("PK_StatusLookUp");

            entity.ToTable("Status_LookUp");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.StatusLookUpType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StatusLookUpValue)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaidenName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleInitial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.NickName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OriginalExceptedStartDate).HasColumnType("datetime");
            entity.Property(e => e.OriginalStartDate).HasColumnType("datetime");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StudentNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Suffix)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Campus).WithMany(p => p.Students).HasForeignKey(d => d.CampusId);

            entity.HasOne(d => d.CitizenShipStatus).WithMany(p => p.Students)
                .HasForeignKey(d => d.CitizenShipStatusId)
                .HasConstraintName("FK_Student_StatusLookup_CitizenShipStatId");

            entity.HasOne(d => d.Country).WithMany(p => p.Students).HasForeignKey(d => d.CountryId);

            entity.HasOne(d => d.EducationalLevel).WithMany(p => p.StudentEducationalLevels)
                .HasForeignKey(d => d.EducationalLevelId)
                .HasConstraintName("FK_Student_CourseRelated_EducationLevelId");

            entity.HasOne(d => d.EthnicGroup).WithMany(p => p.StudentEthnicGroups)
                .HasForeignKey(d => d.EthnicGroupId)
                .HasConstraintName("FK_Student_CourseRelated_EtnicGroupId");

            entity.HasOne(d => d.ProgramGroup).WithMany(p => p.StudentProgramGroups)
                .HasForeignKey(d => d.ProgramGroupId)
                .HasConstraintName("FK_Student_CourseRelated_ProgramGroupId");

            entity.HasOne(d => d.Program).WithMany(p => p.Students).HasForeignKey(d => d.ProgramId);

            entity.HasOne(d => d.ProspectCategory).WithMany(p => p.StudentProspectCategories)
                .HasForeignKey(d => d.ProspectCategoryId)
                .HasConstraintName("FK_Student_CourseRelated_ProspectCategoryId");

            entity.HasOne(d => d.Prospect).WithMany(p => p.StudentProspects)
                .HasForeignKey(d => d.ProspectId)
                .HasConstraintName("FK_Student_CourseReleated_ProspectId");

            entity.HasOne(d => d.ProspectType).WithMany(p => p.StudentProspectTypes)
                .HasForeignKey(d => d.ProspectTypeId)
                .HasConstraintName("FK_Student_CourseReleated_ProspectTypeId");

            entity.HasOne(d => d.School).WithMany(p => p.Students).HasForeignKey(d => d.SchoolId);

            entity.HasOne(d => d.StudentNavigation).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_MasterLookup_GenderId");

            entity.HasOne(d => d.Student1).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_State_StateId");
        });

        modelBuilder.Entity<StudentCourseMapping>(entity =>
        {
            entity.ToTable("Student_Course_Mapping");

            entity.Property(e => e.CourseCompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CourseDropDate).HasColumnType("datetime");
            entity.Property(e => e.CourseLastAttendedDate).HasColumnType("datetime");
            entity.Property(e => e.CourseRegisteredDate).HasColumnType("datetime");
            entity.Property(e => e.CourseStartDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedCourseEndDate).HasColumnType("datetime");
            entity.Property(e => e.GradeLetterCodeObtained)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GradeNote)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GradePostedDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.Campus).WithMany(p => p.StudentCourseMappings).HasForeignKey(d => d.CampusId);

            entity.HasOne(d => d.ClassSection).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.ClassSectionId)
                .HasConstraintName("FK_Student_Course_Mapping_Class_Section");

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Mapping_Courses");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_Student_Course_Mapping_Enrollment");

            entity.HasOne(d => d.StudentCourseStatus).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.StudentCourseStatusId)
                .HasConstraintName("FK_Student_Course_Mapping_StatusLookUp_CourseStatusId");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Mapping_Student");

            entity.HasOne(d => d.Term).WithMany(p => p.StudentCourseMappings)
                .HasForeignKey(d => d.TermId)
                .HasConstraintName("FK_Student_Course_Mapping_Term");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.ToTable("Term");

            entity.Property(e => e.TermId).ValueGeneratedNever();
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.TermNavigation).WithOne(p => p.Term)
                .HasForeignKey<Term>(d => d.TermId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Term_CourseRelated_TermCategoryId");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.ToTable("Test");

            entity.Property(e => e.TestId).ValueGeneratedOnAdd();
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TestNavigation).WithOne(p => p.Test)
                .HasForeignKey<Test>(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Test_CampusGroupId");
        });

        modelBuilder.Entity<TestScore>(entity =>
        {
            entity.ToTable("Test_Score");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExamTakeDate).HasColumnType("datetime");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.ScheduleExamDate).HasColumnType("datetime");
            entity.Property(e => e.TestScore1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TestScore");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.TestScores)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Student).WithMany(p => p.TestScores).HasForeignKey(d => d.StudentId);

            entity.HasOne(d => d.Test).WithMany(p => p.TestScores).HasForeignKey(d => d.TestId);

            entity.HasOne(d => d.TestScoreParent).WithMany(p => p.InverseTestScoreParent)
                .HasForeignKey(d => d.TestScoreParentId)
                .HasConstraintName("FK_Test_Score_Same_TestScoreParentId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.AdditionalName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Address1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EducationLevel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LanguageId).HasColumnName("languageId");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PreFix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicPath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Suffix)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebSite)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.UserGenders)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_User_GenderId");

            entity.HasOne(d => d.Language).WithMany(p => p.UserLanguages)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_Users_LanguageId");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.UserType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
