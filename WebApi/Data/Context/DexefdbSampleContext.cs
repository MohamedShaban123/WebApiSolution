using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

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

    public virtual DbSet<HrIndex> HrIndices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=92.205.56.198,1439\n;Database=DEXEFDB_Sample; User Id=sa;Password=~!@Dexef321;TrustServerCertificate=True;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

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
