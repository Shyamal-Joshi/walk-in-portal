using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace walk_in_portal_Backend.Models;

public partial class DbWalkInPortalContext : DbContext
{
    public DbWalkInPortalContext()
    {
    }

    public DbWalkInPortalContext(DbContextOptions<DbWalkInPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEducationQualification> TblEducationQualifications { get; set; }

    public virtual DbSet<TblExperienceExpertiseTechnology> TblExperienceExpertiseTechnologies { get; set; }

    public virtual DbSet<TblExperienceFamiliarTechnology> TblExperienceFamiliarTechnologies { get; set; }

    public virtual DbSet<TblFresherTechnology> TblFresherTechnologies { get; set; }

    public virtual DbSet<TblJobRole> TblJobRoles { get; set; }

    public virtual DbSet<TblJobRoleDetail> TblJobRoleDetails { get; set; }

    public virtual DbSet<TblProfessionalQualificationExperienced> TblProfessionalQualificationExperienceds { get; set; }

    public virtual DbSet<TblProfessionalQualificationFresher> TblProfessionalQualificationFreshers { get; set; }

    public virtual DbSet<TblQualification> TblQualifications { get; set; }

    public virtual DbSet<TblQualificationsCollege> TblQualificationsColleges { get; set; }

    public virtual DbSet<TblStream> TblStreams { get; set; }

    public virtual DbSet<TblTechnology> TblTechnologies { get; set; }

    public virtual DbSet<TblTimeSlot> TblTimeSlots { get; set; }

    public virtual DbSet<TblUserAppliedJob> TblUserAppliedJobs { get; set; }

    public virtual DbSet<TblUserAppliedJobRoleName> TblUserAppliedJobRoleNames { get; set; }

    public virtual DbSet<TblUserInformation> TblUserInformations { get; set; }

    public virtual DbSet<TblUserPreferenceJobeRole> TblUserPreferenceJobeRoles { get; set; }

    public virtual DbSet<TblWalkInApplication> TblWalkInApplications { get; set; }

    public virtual DbSet<TblWalkInApplicationTimeSlot> TblWalkInApplicationTimeSlots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEducationQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_education_qualifications");

            entity.HasIndex(e => e.CollegeId, "fk_college_id_idx");

            entity.HasIndex(e => e.QualificationId, "fk_qualifications_id_idx");

            entity.HasIndex(e => e.StreamId, "fk_stream_id_idx");

            entity.HasIndex(e => e.UserId, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AggregatedPercentage).HasColumnName("aggregated_percentage");
            entity.Property(e => e.CollegeId).HasColumnName("college_id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modified");
            entity.Property(e => e.Experience)
                .HasColumnType("enum('fresher','experienced')")
                .HasColumnName("experience");
            entity.Property(e => e.QualificationId).HasColumnName("qualification_id");
            entity.Property(e => e.StreamId).HasColumnName("stream_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.YearOfPassing)
                .HasColumnType("year")
                .HasColumnName("year_of_passing");

            entity.HasOne(d => d.College).WithMany(p => p.TblEducationQualifications)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_college_id");

            entity.HasOne(d => d.Qualification).WithMany(p => p.TblEducationQualifications)
                .HasForeignKey(d => d.QualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_qualifications_id");

            entity.HasOne(d => d.Stream).WithMany(p => p.TblEducationQualifications)
                .HasForeignKey(d => d.StreamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stream_id");

            entity.HasOne(d => d.User).WithOne(p => p.TblEducationQualification)
                .HasForeignKey<TblEducationQualification>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_1");
        });

        modelBuilder.Entity<TblExperienceExpertiseTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_experience_expertise_technology");

            entity.HasIndex(e => e.ExperiencedUserId, "fk_experienced_user_id_idx");

            entity.HasIndex(e => e.ExpertiseTechnologyId, "fk_expertise_technology_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.ExperiencedUserId).HasColumnName("experienced_user_id");
            entity.Property(e => e.ExpertiseTechnologyId).HasColumnName("expertise_technology_id");

            entity.HasOne(d => d.ExperiencedUser).WithMany(p => p.TblExperienceExpertiseTechnologies)
                .HasForeignKey(d => d.ExperiencedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_experienced_user_id_2");

            entity.HasOne(d => d.ExpertiseTechnology).WithMany(p => p.TblExperienceExpertiseTechnologies)
                .HasForeignKey(d => d.ExpertiseTechnologyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_expertise_technology_id");
        });

        modelBuilder.Entity<TblExperienceFamiliarTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_experience_familiar_technology");

            entity.HasIndex(e => e.ExperiencedUserId, "fk_experienced_user_id_idx");

            entity.HasIndex(e => e.FamiliarTechnologyId, "fk_familiar_technology_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.ExperiencedUserId).HasColumnName("experienced_user_id");
            entity.Property(e => e.FamiliarTechnologyId).HasColumnName("familiar_technology_id");

            entity.HasOne(d => d.ExperiencedUser).WithMany(p => p.TblExperienceFamiliarTechnologies)
                .HasForeignKey(d => d.ExperiencedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_experienced_user_id");

            entity.HasOne(d => d.FamiliarTechnology).WithMany(p => p.TblExperienceFamiliarTechnologies)
                .HasForeignKey(d => d.FamiliarTechnologyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_familiar_technology_id");
        });

        modelBuilder.Entity<TblFresherTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_fresher_technology");

            entity.HasIndex(e => e.FresherId, "fk_fresher_id_idx");

            entity.HasIndex(e => e.TechnologyId, "fk_technology_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.FresherId).HasColumnName("fresher_id");
            entity.Property(e => e.TechnologyId).HasColumnName("technology_id");

            entity.HasOne(d => d.Fresher).WithMany(p => p.TblFresherTechnologies)
                .HasForeignKey(d => d.FresherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fresher_id");

            entity.HasOne(d => d.Technology).WithMany(p => p.TblFresherTechnologies)
                .HasForeignKey(d => d.TechnologyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_technology_id");
        });

        modelBuilder.Entity<TblJobRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_job_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.JobName)
                .HasMaxLength(255)
                .HasColumnName("job_name");
        });

        modelBuilder.Entity<TblJobRoleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_job_role_details");

            entity.HasIndex(e => e.JobRoleId, "fk_job_role_id_2_idx");

            entity.HasIndex(e => e.WalkInApplicationId, "fk_walk_in_application_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.GrossCompensationPackage)
                .HasColumnType("text")
                .HasColumnName("gross_compensation_package");
            entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");
            entity.Property(e => e.RoleDescription)
                .HasColumnType("text")
                .HasColumnName("role_description");
            entity.Property(e => e.RoleRequirements)
                .HasColumnType("text")
                .HasColumnName("role_requirements");
            entity.Property(e => e.WalkInApplicationId).HasColumnName("walk_in_application_id");

            entity.HasOne(d => d.JobRole).WithMany(p => p.TblJobRoleDetails)
                .HasForeignKey(d => d.JobRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_job_role_id_3");

            entity.HasOne(d => d.WalkInApplication).WithMany(p => p.TblJobRoleDetails)
                .HasForeignKey(d => d.WalkInApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_walk_in_application_id_10");
        });

        modelBuilder.Entity<TblProfessionalQualificationExperienced>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_professional_qualification_experienced");

            entity.HasIndex(e => e.UserId, "fk_user_id_2_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttemptedZeusTest).HasColumnName("attempted_zeus_test");
            entity.Property(e => e.CurrentCtc).HasColumnName("current_ctc");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.EndDateNoticePeriod)
                .HasColumnType("date")
                .HasColumnName("end_date_notice_period");
            entity.Property(e => e.ExpectedCtc).HasColumnName("expected_ctc");
            entity.Property(e => e.NoticePeriod).HasColumnName("notice_period");
            entity.Property(e => e.NoticePeriodLength).HasColumnName("notice_period_length");
            entity.Property(e => e.RoleAttemptedZeusTest)
                .HasMaxLength(115)
                .HasColumnName("role_attempted_zeus_test");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");

            entity.HasOne(d => d.User).WithMany(p => p.TblProfessionalQualificationExperienceds)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_2");
        });

        modelBuilder.Entity<TblProfessionalQualificationFresher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_professional_qualification_fresher");

            entity.HasIndex(e => e.UserId, "fk_user_id_3_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttemptedZeusTest).HasColumnName("attempted_zeus_test");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.RoleAttemptedZeusTest)
                .HasMaxLength(115)
                .HasColumnName("role_attempted_zeus_test");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblProfessionalQualificationFreshers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_3");
        });

        modelBuilder.Entity<TblQualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_qualifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblQualificationsCollege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_qualifications_colleges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblStream>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_streams");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_technology");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblTimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_time_slot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasColumnName("end_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasColumnName("start_time");
        });

        modelBuilder.Entity<TblUserAppliedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_user_applied_jobs");

            entity.HasIndex(e => e.TimeSlotId, "fk_time_slot_id_2_idx");

            entity.HasIndex(e => e.UserId, "fk_user_id_5_idx");

            entity.HasIndex(e => e.WalkInApplicationId, "fk_walk_in_application_id_3_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.Resume)
                .HasMaxLength(255)
                .HasColumnName("resume");
            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WalkInApplicationId).HasColumnName("walk_in_application_id");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.TblUserAppliedJobs)
                .HasForeignKey(d => d.TimeSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_time_slot_id_2");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserAppliedJobs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_5");

            entity.HasOne(d => d.WalkInApplication).WithMany(p => p.TblUserAppliedJobs)
                .HasForeignKey(d => d.WalkInApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_walk_in_application_id_3");
        });

        modelBuilder.Entity<TblUserAppliedJobRoleName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_user_applied_job_role_names");

            entity.HasIndex(e => e.JobRoleId, "fk_job_role_id_idx");

            entity.HasIndex(e => e.UserAppliedJobId, "fk_user_applied_job_id_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");
            entity.Property(e => e.UserAppliedJobId).HasColumnName("user_applied_job_id");

            entity.HasOne(d => d.JobRole).WithMany(p => p.TblUserAppliedJobRoleNames)
                .HasForeignKey(d => d.JobRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_job_role_id_5");

            entity.HasOne(d => d.UserAppliedJob).WithMany(p => p.TblUserAppliedJobRoleNames)
                .HasForeignKey(d => d.UserAppliedJobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_applied_job_id");
        });

        modelBuilder.Entity<TblUserInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_user_information");

            entity.HasIndex(e => e.EmailId, "email_id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phone_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PortfolioUrl, "portfolio_url_UNIQUE").IsUnique();

            entity.HasIndex(e => e.ProfilePhoto, "profile_photo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Resume, "resume_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modified");
            entity.Property(e => e.EmailId).HasColumnName("email_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.NewsLetter).HasColumnName("news_letter");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.PortfolioUrl).HasColumnName("portfolio_url");
            entity.Property(e => e.ProfilePhoto).HasColumnName("profile_photo");
            entity.Property(e => e.Referrer)
                .HasMaxLength(45)
                .HasColumnName("referrer");
            entity.Property(e => e.Resume).HasColumnName("resume");
            entity.Property(e => e.UserRole)
                .HasColumnType("enum('admin','job_poster','fresher')")
                .HasColumnName("user_role");
        });

        modelBuilder.Entity<TblUserPreferenceJobeRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_user_preference_jobe_roles");

            entity.HasIndex(e => e.JobRoleId, "fk_jobe_role_id_idx");

            entity.HasIndex(e => e.UserId, "fk_user_id_4_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.JobRoleId).HasColumnName("job_role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JobRole).WithMany(p => p.TblUserPreferenceJobeRoles)
                .HasForeignKey(d => d.JobRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_jobe_role_id");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserPreferenceJobeRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_4");
        });

        modelBuilder.Entity<TblWalkInApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_walk_in_application");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalInformation)
                .HasMaxLength(255)
                .HasColumnName("additional_information");
            entity.Property(e => e.ApplicationProcess)
                .HasColumnType("text")
                .HasColumnName("application_process");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.ExamInstruction)
                .HasColumnType("text")
                .HasColumnName("exam_instruction");
            entity.Property(e => e.GeneralInstruction)
                .HasColumnType("text")
                .HasColumnName("general_instruction");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.SystemRequirements)
                .HasColumnType("text")
                .HasColumnName("system_requirements");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TblWalkInApplicationTimeSlot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_walk_in_application_time_slot");

            entity.HasIndex(e => e.TimeSlotId, "fk_time_slot_id_idx");

            entity.HasIndex(e => e.WalkInApplicationId, "fk_walk_in_application_id_2_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_created");
            entity.Property(e => e.DtModifed)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_modifed");
            entity.Property(e => e.TimeSlotId).HasColumnName("time_slot_id");
            entity.Property(e => e.WalkInApplicationId).HasColumnName("walk_in_application_id");

            entity.HasOne(d => d.TimeSlot).WithMany(p => p.TblWalkInApplicationTimeSlots)
                .HasForeignKey(d => d.TimeSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_time_slot_id");

            entity.HasOne(d => d.WalkInApplication).WithMany(p => p.TblWalkInApplicationTimeSlots)
                .HasForeignKey(d => d.WalkInApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_walk_in_application_id_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
