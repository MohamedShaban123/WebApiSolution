using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data.Confugurations
{
    public class HR_IndexConfugurations : IEntityTypeConfiguration<HrIndex>
    {
        public void Configure(EntityTypeBuilder<HrIndex> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Work_Nationality");
            builder.ToTable("HR_Index");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Active).HasDefaultValue(true);
            builder.Property(e => e.ArName).HasMaxLength(150);
            builder.Property(e => e.ChName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Dt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("DT");
            builder.Property(e => e.EnName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.FrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.IndexType).HasMaxLength(50);
            builder.Property(e => e.LstUpdate).HasColumnType("datetime");
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Note).HasMaxLength(750);
            builder.Property(e => e.RoName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("rowguid");
            builder.Property(e => e.RuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.TuName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.UpdatedBy).HasMaxLength(50);
            builder.Property(e => e.UrName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            builder.Property(e => e.Writtenby).HasMaxLength(50);
        }
    }
}
