using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Models;

namespace WebApi.Data.Confugurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address).HasMaxLength(250);
            builder.Property(e => e.AnnualIncrease).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.ArName).HasMaxLength(150);
            builder.Property(e => e.BehanceUrl).HasMaxLength(250);
            builder.Property(e => e.Birthday).HasColumnType("datetime");
            builder.Property(e => e.BloodTypeId).HasColumnName("BloodTypeID");
            builder.Property(e => e.BranchId).HasColumnName("BranchID");
            builder.Property(e => e.ChName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.ChangedSalary).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            builder.Property(e => e.Dt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DT");
            builder.Property(e => e.DtContractDue).HasColumnType("datetime");
            builder.Property(e => e.Dthiring)
                .HasColumnType("datetime")
                .HasColumnName("DThiring");
            builder.Property(e => e.EnName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.ExpectedSalary).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.FaceBookUrl).HasMaxLength(250);
            builder.Property(e => e.FacultyId).HasColumnName("FacultyID");
            builder.Property(e => e.FingerPrintNumber).HasMaxLength(50);
            builder.Property(e => e.FrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.HiringStatus).HasMaxLength(50);
            builder.Property(e => e.HousingAllowance).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.Insurances).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.JobId).HasColumnName("JobID");
            builder.Property(e => e.LinkedInUrl).HasMaxLength(250);
            builder.Property(e => e.Mail).HasMaxLength(150);
            builder.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
            builder.Property(e => e.Mob1).HasMaxLength(50);
            builder.Property(e => e.Mob2).HasMaxLength(50);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.MonthlyCommissions).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.NationalityId).HasColumnName("NationalityID");
            builder.Property(e => e.Num)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.OtherAllowances).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.PersonalId)
                .HasMaxLength(50)
                .HasColumnName("PersonalID");
            builder.Property(e => e.ProjectUrl).HasMaxLength(250);
            builder.Property(e => e.RoName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.RuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.Salary).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.SalaryGroupId).HasColumnName("SalaryGroupID");
            builder.Property(e => e.SectorId).HasColumnName("SectorID");
            builder.Property(e => e.Sex).HasMaxLength(50);
            builder.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Taxes).HasColumnType("decimal(38, 12)");
            builder.Property(e => e.TuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.UrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.Writtenby).HasMaxLength(50);

            builder.HasOne(d => d.Branch).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_Employees_BranchID");
        }
    }
}
