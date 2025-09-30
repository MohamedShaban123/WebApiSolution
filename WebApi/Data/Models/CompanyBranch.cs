using System;
using System.Collections.Generic;

namespace WebApi.Data.Models;


public partial class CompanyBranch
{
    public int Id { get; set; }

    public string Num { get; set; } = null!;

   
    public string? Name { get; set; }


    public string? Mobile1 { get; set; }

    public string? Mobile2 { get; set; }

    public string? Mobile3 { get; set; }


    public bool? Active { get; set; }

    public string? Currency { get; set; }

    public decimal? Val1 { get; set; }

    public decimal? Val2 { get; set; }


    public int? CostId { get; set; }


    public string? PurchaseCycle { get; set; }

    public bool? PurchaseReview { get; set; }


    public string? SaleCycle { get; set; }

    public bool? SaleReview { get; set; }

   
    public string? TransferCycle { get; set; }

    public Guid Rowguid { get; set; }

    public int? CountryId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Subcurrency { get; set; }

    public string? BuildingNumber { get; set; }

    public string? Governorate { get; set; }

    public string? Landmark { get; set; }

    public string? Mail { get; set; }

    public int? ReportTemplateId { get; set; }

    public int? CompanyId { get; set; }

    public string? TaxBranchId { get; set; }

    public string? ActivityId { get; set; }

    public string? PostalNumber { get; set; }

    public bool? IsMasterBranch { get; set; }

    public string? AppNumber { get; set; }

    public string? AdditionalNumber { get; set; }

    public string? Field { get; set; }

    public string? Tax { get; set; }

    public string? Trade { get; set; }

    public byte[]? Logo { get; set; }

    public DateTime? SyncDate { get; set; }

    public int? PrefixId { get; set; }

    public string? District { get; set; }

    public int? CurrencyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool Attach { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
