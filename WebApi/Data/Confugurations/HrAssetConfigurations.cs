using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Models;

namespace WebApi.Data.Confugurations
{
    public class HrAssetConfigurations : IEntityTypeConfiguration<HrAsset>
    {
        public void Configure(EntityTypeBuilder<HrAsset> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_EmplAssets");

            builder.ToTable("HR_Assets");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.BranchId).HasColumnName("BranchID");
            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.DtAssigned).HasColumnType("datetime");
            builder.Property(e => e.DtReturned).HasColumnType("datetime");
            builder.Property(e => e.EmplId).HasColumnName("EmplID");
            builder.Property(e => e.GroupId).HasColumnName("GroupID");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            builder.Property(e => e.Note).HasMaxLength(500);
            builder.Property(e => e.Serial).HasMaxLength(150);
            builder.Property(e => e.Txt1)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt1");
            builder.Property(e => e.Txt2)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt2");
            builder.Property(e => e.Txt3)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt3");
            builder.Property(e => e.Txt4)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt4");
            builder.Property(e => e.Txt5)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt5");
            builder.Property(e => e.Txt6)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt6");
            builder.Property(e => e.Txt7)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt7");
            builder.Property(e => e.Txt8)
                .HasMaxLength(150)
                .HasDefaultValue("")
                .HasColumnName("txt8");
        }
    }
}
