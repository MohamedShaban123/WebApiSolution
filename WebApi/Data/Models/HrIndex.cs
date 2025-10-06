using System;
using System.Collections.Generic;

namespace WebApi.Data.Models;

public partial class HrIndex
{
    public int Id { get; set; }

    public string? ArName { get; set; }

    public string? EnName { get; set; }

    public string? FrName { get; set; }

    public string? UrName { get; set; }

    public string? TuName { get; set; }

    public string? RoName { get; set; }

    public string? ChName { get; set; }

    public string? RuName { get; set; }

    public string? Writtenby { get; set; }

    public DateTime? Dt { get; set; }

    public bool? Active { get; set; }

    public string? Note { get; set; }

    public string? IndexType { get; set; }

    public DateTime? LstUpdate { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid Rowguid { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Employee> EmployeeBloodTypes { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeCities { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeDepartments { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeFaculties { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeJobs { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeMaritalStatuses { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeNationalities { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeSectors { get; set; } = new List<Employee>();


}
