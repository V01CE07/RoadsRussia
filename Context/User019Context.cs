using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using calendar.Models;

namespace calendar.Context;

public partial class User019Context : DbContext
{
    public User019Context()
    {
    }

    public User019Context(DbContextOptions<User019Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CabinetList> CabinetLists { get; set; }

    public virtual DbSet<CalendarStatus> CalendarStatuses { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<EventList> EventLists { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<HighLevelDepartment> HighLevelDepartments { get; set; }

    public virtual DbSet<JobList> JobLists { get; set; }

    public virtual DbSet<LowLevelDepartment> LowLevelDepartments { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialArea> MaterialAreas { get; set; }

    public virtual DbSet<MaterialStatus> MaterialStatuses { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<MediumLevelDepartment> MediumLevelDepartments { get; set; }

    public virtual DbSet<WorkCalendar> WorkCalendars { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87:5522;Database=user019;Username=user019;Password=16527");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CabinetList>(entity =>
        {
            entity.HasKey(e => e.IdCabinet).HasName("cabinet_list_pk");

            entity.ToTable("cabinet_list");

            entity.Property(e => e.IdCabinet)
                .ValueGeneratedNever()
                .HasColumnName("id_cabinet");
            entity.Property(e => e.NumberCabinet)
                .HasColumnType("character varying")
                .HasColumnName("number_cabinet");
        });

        modelBuilder.Entity<CalendarStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusCalendar).HasName("calendar_status_pk");

            entity.ToTable("calendar_status");

            entity.Property(e => e.IdStatusCalendar)
                .ValueGeneratedNever()
                .HasColumnName("id_status_calendar");
            entity.Property(e => e.NameStatusCalendar)
                .HasColumnType("character varying")
                .HasColumnName("name_status_calendar");
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("candidate_pk");

            entity.ToTable("candidate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateInterview)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_interview");
            entity.Property(e => e.EmailCandidate)
                .HasColumnType("character varying")
                .HasColumnName("email_candidate");
            entity.Property(e => e.HrCandidate).HasColumnName("hr_candidate");
            entity.Property(e => e.NameCandidate)
                .HasColumnType("character varying")
                .HasColumnName("name_candidate");
            entity.Property(e => e.PhonenumberCandidate)
                .HasColumnType("character varying")
                .HasColumnName("phonenumber_candidate");
            entity.Property(e => e.RequiredPosition).HasColumnName("required_position");
            entity.Property(e => e.SummaryCandidate)
                .HasColumnType("character varying")
                .HasColumnName("summary_candidate");

            entity.HasOne(d => d.RequiredPositionNavigation).WithMany(p => p.Candidates)
                .HasForeignKey(d => d.RequiredPosition)
                .HasConstraintName("candidate_job_list_fk");
        });

        modelBuilder.Entity<EventList>(entity =>
        {
            entity.HasKey(e => e.IdEvent).HasName("event_list_pk");

            entity.ToTable("event_list");

            entity.Property(e => e.IdEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_event");
            entity.Property(e => e.DescriptionEvent)
                .HasColumnType("character varying")
                .HasColumnName("description_event");
            entity.Property(e => e.NameEvent)
                .HasColumnType("character varying")
                .HasColumnName("name_event");
            entity.Property(e => e.TypeEvent).HasColumnName("type_event");

            entity.HasOne(d => d.TypeEventNavigation).WithMany(p => p.EventLists)
                .HasForeignKey(d => d.TypeEvent)
                .HasConstraintName("event_list_event_type_fk");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusEvent).HasName("event_status_pk");

            entity.ToTable("event_status");

            entity.Property(e => e.IdStatusEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_status_event");
            entity.Property(e => e.NameStatusEvent)
                .HasColumnType("character varying")
                .HasColumnName("name_status_event");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.IdTypeEvent).HasName("event_type_pk");

            entity.ToTable("event_type");

            entity.Property(e => e.IdTypeEvent)
                .ValueGeneratedNever()
                .HasColumnName("id_type_event");
            entity.Property(e => e.NameTypeName)
                .HasColumnType("character varying")
                .HasColumnName("name_type_name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.IdGender)
                .ValueGeneratedNever()
                .HasColumnName("id_gender");
            entity.Property(e => e.NameGender)
                .HasColumnType("character varying")
                .HasColumnName("name_gender");
        });

        modelBuilder.Entity<HighLevelDepartment>(entity =>
        {
            entity.HasKey(e => e.IdDepartmenthigh).HasName("high_level_department_pk");

            entity.ToTable("high_level_department");

            entity.Property(e => e.IdDepartmenthigh)
                .ValueGeneratedNever()
                .HasColumnName("id_departmenthigh");
            entity.Property(e => e.DescriptionDepartmenthigh)
                .HasColumnType("character varying")
                .HasColumnName("description_departmenthigh");
            entity.Property(e => e.NameDepartmenthigh)
                .HasColumnType("character varying")
                .HasColumnName("name_departmenthigh");
        });

        modelBuilder.Entity<JobList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("joblist_pk");

            entity.ToTable("job_list");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Jobname)
                .HasColumnType("character varying")
                .HasColumnName("jobname");
        });

        modelBuilder.Entity<LowLevelDepartment>(entity =>
        {
            entity.HasKey(e => e.IdDepartmentlow).HasName("low_level_department_pk");

            entity.ToTable("low_level_department");

            entity.Property(e => e.IdDepartmentlow)
                .ValueGeneratedNever()
                .HasColumnName("id_departmentlow");
            entity.Property(e => e.DescriptionDepartmentlow)
                .HasColumnType("character varying")
                .HasColumnName("description_departmentlow");
            entity.Property(e => e.NameDepartmentlow)
                .HasColumnType("character varying")
                .HasColumnName("name_departmentlow");
            entity.Property(e => e.ParentDepartmentlow).HasColumnName("parent_departmentlow");

            entity.HasOne(d => d.ParentDepartmentlowNavigation).WithMany(p => p.LowLevelDepartments)
                .HasForeignKey(d => d.ParentDepartmentlow)
                .HasConstraintName("low_level_department_medium_level_department_fk");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("material_pk");

            entity.ToTable("material");

            entity.Property(e => e.IdMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_material");
            entity.Property(e => e.AreaMaterial).HasColumnName("area_material");
            entity.Property(e => e.AuthorMaterial).HasColumnName("author_material");
            entity.Property(e => e.CreateDateMaterial)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date_material");
            entity.Property(e => e.EditDateMaterial)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("edit_date_material");
            entity.Property(e => e.EventMaterial).HasColumnName("event_material");
            entity.Property(e => e.NameMaterial)
                .HasColumnType("character varying")
                .HasColumnName("name_material");
            entity.Property(e => e.StatusMaterial).HasColumnName("status_material");
            entity.Property(e => e.TypeMaterial).HasColumnName("type_material");

            entity.HasOne(d => d.AreaMaterialNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.AreaMaterial)
                .HasConstraintName("material_material_area_fk");

            entity.HasOne(d => d.EventMaterialNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.EventMaterial)
                .HasConstraintName("material_event_list_fk");

            entity.HasOne(d => d.StatusMaterialNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.StatusMaterial)
                .HasConstraintName("material_material_status_fk");

            entity.HasOne(d => d.TypeMaterialNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.TypeMaterial)
                .HasConstraintName("material_material_type_fk");
        });

        modelBuilder.Entity<MaterialArea>(entity =>
        {
            entity.HasKey(e => e.IdAreaMaterial).HasName("material_area_pk");

            entity.ToTable("material_area");

            entity.Property(e => e.IdAreaMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_area_material");
            entity.Property(e => e.NameAreaMaterial)
                .HasColumnType("character varying")
                .HasColumnName("name_area_material");
        });

        modelBuilder.Entity<MaterialStatus>(entity =>
        {
            entity.HasKey(e => e.IdStatusMaterial).HasName("material_status_pk");

            entity.ToTable("material_status");

            entity.Property(e => e.IdStatusMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_status_material");
            entity.Property(e => e.NameStatusMaterial)
                .HasColumnType("character varying")
                .HasColumnName("name_status_material");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.IdTypeMaterial).HasName("material_type_pk");

            entity.ToTable("material_type");

            entity.Property(e => e.IdTypeMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_type_material");
            entity.Property(e => e.NameTypeMaterial)
                .HasColumnType("character varying")
                .HasColumnName("name_type_material");
        });

        modelBuilder.Entity<MediumLevelDepartment>(entity =>
        {
            entity.HasKey(e => e.IdDepartmentmedium).HasName("medium_level_department_pk");

            entity.ToTable("medium_level_department");

            entity.Property(e => e.IdDepartmentmedium)
                .ValueGeneratedNever()
                .HasColumnName("id_departmentmedium");
            entity.Property(e => e.DescriptionDepartmentmedium)
                .HasColumnType("character varying")
                .HasColumnName("description_departmentmedium");
            entity.Property(e => e.NameDepartmentmedium)
                .HasColumnType("character varying")
                .HasColumnName("name_departmentmedium");
            entity.Property(e => e.ParentDepartmentmedium).HasColumnName("parent_departmentmedium");

            entity.HasOne(d => d.ParentDepartmentmediumNavigation).WithMany(p => p.MediumLevelDepartments)
                .HasForeignKey(d => d.ParentDepartmentmedium)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medium_level_department_high_level_department_fk");
        });

        modelBuilder.Entity<WorkCalendar>(entity =>
        {
            entity.HasKey(e => e.IdCalendar).HasName("work_calendar_pk");

            entity.ToTable("work_calendar");

            entity.Property(e => e.IdCalendar)
                .ValueGeneratedNever()
                .HasColumnName("id_calendar");
            entity.Property(e => e.ChiefCalendar).HasColumnName("chief_calendar");
            entity.Property(e => e.EndCalendar)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_calendar");
            entity.Property(e => e.EventCalendar).HasColumnName("event_calendar");
            entity.Property(e => e.StartCalendar)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_calendar");
            entity.Property(e => e.StatusCalendar).HasColumnName("status_calendar");
            entity.Property(e => e.WorkerCalendar).HasColumnName("worker_calendar");

            entity.HasOne(d => d.EventCalendarNavigation).WithMany(p => p.WorkCalendars)
                .HasForeignKey(d => d.EventCalendar)
                .HasConstraintName("work_calendar_event_list_fk");

            entity.HasOne(d => d.StatusCalendarNavigation).WithMany(p => p.WorkCalendars)
                .HasForeignKey(d => d.StatusCalendar)
                .HasConstraintName("work_calendar_calendar_status_fk");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.IdWorker).HasName("worker_pk");

            entity.ToTable("worker");

            entity.Property(e => e.IdWorker)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_worker");
            entity.Property(e => e.CabinetWorker).HasColumnName("cabinet_worker");
            entity.Property(e => e.DateOfBirthWorker)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_birth_worker");
            entity.Property(e => e.EmailWorker)
                .HasColumnType("character varying")
                .HasColumnName("email_worker");
            entity.Property(e => e.GenderWorker).HasColumnName("gender_worker");
            entity.Property(e => e.HighDepartmentWorker).HasColumnName("high_department_worker");
            entity.Property(e => e.IsfiredWorker).HasColumnName("isfired_worker");
            entity.Property(e => e.JobPositionWorker).HasColumnName("job_position_worker");
            entity.Property(e => e.LowDepartmentWorker).HasColumnName("low_department_worker");
            entity.Property(e => e.MediumDepartmentWorker).HasColumnName("medium_department_worker");
            entity.Property(e => e.NameWorker)
                .HasColumnType("character varying")
                .HasColumnName("name_worker");
            entity.Property(e => e.PhonenumberWorker)
                .HasColumnType("character varying")
                .HasColumnName("phonenumber_worker");

            entity.HasOne(d => d.CabinetWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.CabinetWorker)
                .HasConstraintName("worker_cabinet_list_fk");

            entity.HasOne(d => d.GenderWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.GenderWorker)
                .HasConstraintName("worker_gender_fk");

            entity.HasOne(d => d.HighDepartmentWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.HighDepartmentWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("worker_high_level_department_fk");

            entity.HasOne(d => d.JobPositionWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.JobPositionWorker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("worker_job_list_fk");

            entity.HasOne(d => d.LowDepartmentWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.LowDepartmentWorker)
                .HasConstraintName("worker_low_level_department_fk");

            entity.HasOne(d => d.MediumDepartmentWorkerNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.MediumDepartmentWorker)
                .HasConstraintName("worker_medium_level_department_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
