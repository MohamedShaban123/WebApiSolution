using System;
using System.Collections.Generic;

namespace WebApi.Data.Models;

public partial class HrAsset
{
    public int Id { get; set; }

    public int? EmplId { get; set; }

    public string? Name { get; set; }

    public int? GroupId { get; set; }

    public string? Serial { get; set; }

    public DateTime? DtAssigned { get; set; }

    public DateTime? DtReturned { get; set; }

    public string? Note { get; set; }

    public int? BranchId { get; set; }

    public string? Txt1 { get; set; }

    public string? Txt2 { get; set; }

    public string? Txt3 { get; set; }

    public string? Txt4 { get; set; }

    public string? Txt5 { get; set; }

    public string? Txt6 { get; set; }

    public string? Txt7 { get; set; }

    public string? Txt8 { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
