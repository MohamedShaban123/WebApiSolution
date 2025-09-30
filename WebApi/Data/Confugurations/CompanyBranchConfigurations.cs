using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Models;

namespace WebApi.Data.Confugurations
{
    public class CompanyBranchConfigurations : IEntityTypeConfiguration<CompanyBranch>
    {
        public void Configure(EntityTypeBuilder<CompanyBranch> builder)
        {
            builder.ToTable("Company_Branch", tb => tb.HasComment("this table for Branches information which linked to Organization "));

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Active)
                .HasComment("Active Branch (yes/no)")
                .HasColumnName("active");
            builder.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ActivityID");
            builder.Property(e => e.AdditionalNumber).HasMaxLength(50);
            builder.Property(e => e.AppNumber).HasMaxLength(50);
            builder.Property(e => e.BuildingNumber).HasMaxLength(50);
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasComment("Address(city)")
                .HasColumnName("city");
            builder.Property(e => e.CompanyId).HasColumnName("CompanyID");
            builder.Property(e => e.CostId)
                .HasComment("linked Cost center account")
                .HasColumnName("CostID");
            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            builder.Property(e => e.CountryId)
                .HasComment("country ID ")
                .HasColumnName("CountryID");
            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("used currency");
            builder.Property(e => e.District).HasMaxLength(50);
            builder.Property(e => e.Field)
                .HasMaxLength(250)
                .HasColumnName("field");
            builder.Property(e => e.Governorate).HasMaxLength(50);
            builder.Property(e => e.Landmark).HasMaxLength(250);
            builder.Property(e => e.Logo).HasColumnName("logo");
            builder.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            builder.Property(e => e.Mobile1)
                .HasMaxLength(20)
                .HasComment("Phone 1")
                .HasColumnName("mobile1");
            builder.Property(e => e.Mobile2)
                .HasMaxLength(20)
                .HasComment("Phone 2")
                .HasColumnName("mobile2");
            builder.Property(e => e.Mobile3)
                .HasMaxLength(20)
                .HasColumnName("mobile3");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("Branch name ")
                .HasColumnName("name");
            builder.Property(e => e.Num)
                .HasMaxLength(50)
                .HasColumnName("num");
            builder.Property(e => e.PostalNumber).HasMaxLength(50);
            builder.Property(e => e.PrefixId).HasColumnName("PrefixID");
            builder.Property(e => e.PurchaseCycle)
                .HasMaxLength(10)
                .HasDefaultValue("P1")
                .HasComment("link to purchasing cycle (process) code ");
            builder.Property(e => e.PurchaseReview).HasDefaultValue(false);
            builder.Property(e => e.ReportTemplateId).HasColumnName("ReportTemplateID");
            builder.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            builder.Property(e => e.SaleCycle)
                .HasMaxLength(10)
                .HasDefaultValue("S1")
                .HasComment("link to sales cycle (process) code ");
            builder.Property(e => e.SaleReview).HasDefaultValue(false);
            builder.Property(e => e.Street)
                .HasMaxLength(450)
                .HasComment("Address  (street)")
                .HasColumnName("street");
            builder.Property(e => e.Subcurrency)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("subcurrency");
            builder.Property(e => e.SyncDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Tax)
                .HasMaxLength(50)
                .HasColumnName("tax");
            builder.Property(e => e.TaxBranchId)
                .HasMaxLength(50)
                .HasColumnName("TaxBranchID");
            builder.Property(e => e.Trade).HasMaxLength(50);
            builder.Property(e => e.TransferCycle)
                .HasMaxLength(10)
                .HasDefaultValue("T1")
                .HasComment("link to Transfer cycle (process) code ");
            builder.Property(e => e.Val1)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 12)");
            builder.Property(e => e.Val2)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(38, 12)");
        }
    }
}
