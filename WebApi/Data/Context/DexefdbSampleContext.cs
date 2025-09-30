using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    public virtual DbSet<HrIndex> HrIndices { get; set; }
    public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<HrAsset> HrAssets { get; set; }




}
