using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Data.Models;



public partial class Employee
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public string? Num { get; set; }

    public string? ArName { get; set; }

    public string? EnName { get; set; }

    public string? FrName { get; set; }

    public string? UrName { get; set; }

    public string? TuName { get; set; }

    public string? RoName { get; set; }

    public string? ChName { get; set; }

    public string? RuName { get; set; }

    public string? Status { get; set; }

    public DateTime? Dt { get; set; }

    public decimal? Salary { get; set; }

    public decimal? ChangedSalary { get; set; }

    public decimal? Insurances { get; set; }

    public decimal? Taxes { get; set; }

    public decimal? AnnualIncrease { get; set; }

    public string? Writtenby { get; set; }

    public string? FingerPrintNumber { get; set; }


    public string? Mob1 { get; set; }

    public string? Mob2 { get; set; }

    public string? Mail { get; set; }

    public string? Address { get; set; }

    public string? Sex { get; set; }

    public int? DepartmentId { get; set; }

    public int? JobId { get; set; }

    public int? NationalityId { get; set; }

    public int? MaritalStatusId { get; set; }

    public int? BloodTypeId { get; set; }

    public int? FacultyId { get; set; }

    public int? GraduationYear { get; set; }

    public bool? Attach { get; set; }

    public string? HiringStatus { get; set; }

    public int? SalaryGroupId { get; set; }

    public DateTime? Birthday { get; set; }

    public string? PersonalId { get; set; }

    public DateTime? Dthiring { get; set; }

    public int? CityId { get; set; }

    public decimal? ExpectedSalary { get; set; }

    public string? LinkedInUrl { get; set; }

    public string? FaceBookUrl { get; set; }

    public string? BehanceUrl { get; set; }

    public string? ProjectUrl { get; set; }

    public decimal? MonthlyCommissions { get; set; }

    public decimal? HousingAllowance { get; set; }

    public decimal? OtherAllowances { get; set; }

    public DateTime? DtContractDue { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? SectorId { get; set; }



    public virtual HrIndex? BloodType { get; set; }

    public virtual CompanyBranch? Branch { get; set; }

    public virtual HrIndex? City { get; set; }

    public virtual HrIndex? Department { get; set; }

    public virtual HrIndex? Faculty { get; set; }

    public virtual ICollection<HrAsset> HrAssets { get; set; } = new List<HrAsset>();

    public virtual HrIndex? Job { get; set; }

    public virtual HrIndex? MaritalStatus { get; set; }

    public virtual HrIndex? Nationality { get; set; }

    public virtual HrIndex? Sector { get; set; }


}
