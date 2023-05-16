using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models.OracleHRModel;

public partial class OracleHrContext : DbContext
{
    public OracleHrContext()
    {
    }

    public OracleHrContext(DbContextOptions<OracleHrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobHistory> JobHistories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Data Source=devsql01;Initial Catalog=OracleHR;User Id=sa;Password=!Sa@dmin;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__COUNTRIE__31027163705E0412");

            entity.Property(e => e.CountryId).IsFixedLength();

            entity.HasOne(d => d.Region).WithMany(p => p.Countries).HasConstraintName("FK__COUNTRIES__REGIO__2A4B4B5E");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__DEPARTME__63E613628BAB9AB3");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments).HasConstraintName("FK__DEPARTMEN__LOCAT__300424B4");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__EMPLOYEE__CBA14F4895C71192");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasConstraintName("FK__EMPLOYEES__DEPAR__45F365D3");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EJOBID_Employee_JOBS");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager).HasConstraintName("FK_EMGR_Employee_Employee");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__JOBS__2AC9D60A91AD6558");
        });

        modelBuilder.Entity<JobHistory>(entity =>
        {
            entity.HasOne(d => d.Department).WithMany().HasConstraintName("FK__JOB_HISTO__DEPAR__4D94879B");

            entity.HasOne(d => d.Employee).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JOB_HISTO__EMPLO__4BAC3F29");

            entity.HasOne(d => d.Job).WithMany().HasConstraintName("FK__JOB_HISTO__JOB_I__4CA06362");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__LOCATION__D2263B8E8EC94A7A");

            entity.Property(e => e.CountryId).IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.Locations).HasConstraintName("FK__LOCATIONS__COUNT__2D27B809");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__REGIONS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
