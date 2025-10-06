using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
namespace WebApi.Data.Context;





public partial class DexefdbSampleContext : DbContext
{
    public DexefdbSampleContext()
    {
    }

    public DexefdbSampleContext(DbContextOptions<DexefdbSampleContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<HrAsset> HrAssets { get; set; }

    public virtual DbSet<HrIndex> HrIndices { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<CompanyBranch>(entity =>
        {
            entity.ToTable("Company_Branch", tb => tb.HasComment("this table for Branches information which linked to Organization "));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasComment("Active Branch (yes/no)")
                .HasColumnName("active");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ActivityID");
            entity.Property(e => e.AdditionalNumber).HasMaxLength(50);
            entity.Property(e => e.AppNumber).HasMaxLength(50);
            entity.Property(e => e.BuildingNumber).HasMaxLength(50);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasComment("Address(city)")
                .HasColumnName("city");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.CostId)
                .HasComment("linked Cost center account")
                .HasColumnName("CostID");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CountryId)
                .HasComment("country ID ")
                .HasColumnName("CountryID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("used currency");
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Field)
                .HasMaxLength(250)
                .HasColumnName("field");
            entity.Property(e => e.Governorate).HasMaxLength(50);
            entity.Property(e => e.Landmark).HasMaxLength(250);
            entity.Property(e => e.Logo).HasColumnName("logo");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.Mobile1)
                .HasMaxLength(20)
                .HasComment("Phone 1")
                .HasColumnName("mobile1");
            entity.Property(e => e.Mobile2)
                .HasMaxLength(20)
                .HasComment("Phone 2")
                .HasColumnName("mobile2");
            entity.Property(e => e.Mobile3)
                .HasMaxLength(20)
                .HasColumnName("mobile3");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Branch name ")
                .HasColumnName("name");
            entity.Property(e => e.Num)
                .HasMaxLength(50)
                .HasColumnName("num");
            entity.Property(e => e.PostalNumber).HasMaxLength(50);
            entity.Property(e => e.PrefixId).HasColumnName("PrefixID");
            entity.Property(e => e.PurchaseCycle)
                .HasMaxLength(10)
                .HasDefaultValue("P1")
                .HasComment("link to purchasing cycle (process) code ");
            entity.Property(e => e.PurchaseReview).HasDefaultValue(false);
            entity.Property(e => e.ReportTemplateId).HasColumnName("ReportTemplateID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SaleCycle)
                .HasMaxLength(10)
                .HasDefaultValue("S1")
                .HasComment("link to sales cycle (process) code ");
            entity.Property(e => e.SaleReview).HasDefaultValue(false);
            entity.Property(e => e.Street)
                .HasMaxLength(450)
                .HasComment("Address  (street)")
                .HasColumnName("street");
            entity.Property(e => e.Subcurrency)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("subcurrency");
            entity.Property(e => e.SyncDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Tax)
                .HasMaxLength(50)
                .HasColumnName("tax");
            entity.Property(e => e.TaxBranchId)
                .HasMaxLength(50)
                .HasColumnName("TaxBranchID");
            entity.Property(e => e.Trade).HasMaxLength(50);
            entity.Property(e => e.TransferCycle)
                .HasMaxLength(10)
                .HasDefaultValue("T1")
                .HasComment("link to Transfer cycle (process) code ");
            entity.Property(e => e.Val1)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 12)");
            entity.Property(e => e.Val2)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 12)");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.AnnualIncrease).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.ArName).HasMaxLength(150);
            entity.Property(e => e.BehanceUrl).HasMaxLength(250);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.BloodTypeId).HasColumnName("BloodTypeID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.ChName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.ChangedSalary).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Dt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DT");
            entity.Property(e => e.DtContractDue).HasColumnType("datetime");
            entity.Property(e => e.Dthiring)
                .HasColumnType("datetime")
                .HasColumnName("DThiring");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.ExpectedSalary).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.FaceBookUrl).HasMaxLength(250);
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.FingerPrintNumber).HasMaxLength(50);
            entity.Property(e => e.FrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.HiringStatus).HasMaxLength(50);
            entity.Property(e => e.HousingAllowance).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.Insurances).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.JobId).HasColumnName("JobID");
            entity.Property(e => e.LinkedInUrl).HasMaxLength(250);
            entity.Property(e => e.Mail).HasMaxLength(150);
            entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            entity.Property(e => e.Mob1).HasMaxLength(50);
            entity.Property(e => e.Mob2).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MonthlyCommissions).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.NationalityId).HasColumnName("NationalityID");
            entity.Property(e => e.Num)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherAllowances).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.PersonalId)
                .HasMaxLength(50)
                .HasColumnName("PersonalID");
            entity.Property(e => e.ProjectUrl).HasMaxLength(250);
            entity.Property(e => e.RoName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.RuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.Salary).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.SalaryGroupId).HasColumnName("SalaryGroupID");
            entity.Property(e => e.SectorId).HasColumnName("SectorID");
            entity.Property(e => e.Sex).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Taxes).HasColumnType("decimal(38, 12)");
            entity.Property(e => e.TuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.UrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.Writtenby).HasMaxLength(50);

            entity.HasOne(d => d.BloodType).WithMany(p => p.EmployeeBloodTypes)
                .HasForeignKey(d => d.BloodTypeId)
                .HasConstraintName("FK_Employees_BloodTypeID");

            entity.HasOne(d => d.Branch).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Employees_BranchID");

            entity.HasOne(d => d.City).WithMany(p => p.EmployeeCities)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Employees_CityId");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Employees_DepartmentID");

            entity.HasOne(d => d.Faculty).WithMany(p => p.EmployeeFaculties)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK_Employees_FacultyID");

            entity.HasOne(d => d.Job).WithMany(p => p.EmployeeJobs)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_Employees_JobID");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.EmployeeMaritalStatuses)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK_Employees_MaritalStatusID");

            entity.HasOne(d => d.Nationality).WithMany(p => p.EmployeeNationalities)
                .HasForeignKey(d => d.NationalityId)
                .HasConstraintName("FK_Employees_NationalityID");

            entity.HasOne(d => d.Sector).WithMany(p => p.EmployeeSectors)
                .HasForeignKey(d => d.SectorId)
                .HasConstraintName("FK_Employees_SectorID");





            entity.HasOne(e => e.BloodType)
                .WithMany(h => h.EmployeeBloodTypes)
                .HasForeignKey(e => e.BloodTypeId)
                .OnDelete(DeleteBehavior.Restrict);



            entity.HasOne(e => e.City)
                .WithMany(h => h.EmployeeCities)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(e => e.Department)
                .WithMany(h => h.EmployeeDepartments)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);



            entity.HasOne(e => e.Faculty)
                .WithMany(h => h.EmployeeFaculties)
                .HasForeignKey(e => e.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);



            entity.HasOne(e => e.Job)
                .WithMany(h => h.EmployeeJobs)
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Restrict);


            entity.HasOne(e => e.MaritalStatus)
                .WithMany(h => h.EmployeeMaritalStatuses)
                .HasForeignKey(e => e.MaritalStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Nationality)
                .WithMany(h => h.EmployeeNationalities)
                .HasForeignKey(e => e.NationalityId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Sector)
                .WithMany(h => h.EmployeeSectors)
                .HasForeignKey(e => e.SectorId)
                .OnDelete(DeleteBehavior.Restrict);


                    modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Branch)
                    .WithMany(b => b.Employees) 
                    .HasForeignKey(e => e.BranchId)
                    .OnDelete(DeleteBehavior.Restrict);


        });

        modelBuilder.Entity<HrAsset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmplAssets");

            entity.ToTable("HR_Assets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DtAssigned).HasColumnType("datetime");
            entity.Property(e => e.DtReturned).HasColumnType("datetime");
            entity.Property(e => e.EmplId).HasColumnName("EmplID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Serial).HasMaxLength(150);
            entity.Property(e => e.Txt1)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt1");
            entity.Property(e => e.Txt2)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt2");
            entity.Property(e => e.Txt3)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt3");
            entity.Property(e => e.Txt4)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt4");
            entity.Property(e => e.Txt5)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt5");
            entity.Property(e => e.Txt6)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt6");
            entity.Property(e => e.Txt7)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt7");
            entity.Property(e => e.Txt8)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt8");

            entity.HasOne(d => d.Branch).WithMany(p => p.HrAssets)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_HR_Assets_BranchID");

            entity.HasOne(d => d.Empl).WithMany(p => p.HrAssets)
                .HasForeignKey(d => d.EmplId)
                .HasConstraintName("FK_EmplID_HR_Assets");
        });

        modelBuilder.Entity<HrIndex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Work_Nationality");

            entity.ToTable("HR_Index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.ArName).HasMaxLength(150);
            entity.Property(e => e.ChName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DT");
            entity.Property(e => e.EnName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.FrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.IndexType).HasMaxLength(50);
            entity.Property(e => e.LstUpdate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(750);
            entity.Property(e => e.RoName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.RuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.TuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.Writtenby).HasMaxLength(50);


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
