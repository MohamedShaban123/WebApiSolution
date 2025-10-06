namespace WebApi.Dtos
{
    public class EmployeeDtoPost
    {
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
        public string? FingerPrintNumber { get; set; }

        public string? Mob1 { get; set; }
        public string? Mob2 { get; set; }
        public string? Mail { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }

        public DateTime? Birthday { get; set; }
        public string? PersonalId { get; set; }
        public DateTime? Dthiring { get; set; }

        public decimal? ExpectedSalary { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? FaceBookUrl { get; set; }
        public string? BehanceUrl { get; set; }
        public string? ProjectUrl { get; set; }

        public decimal? MonthlyCommissions { get; set; }
        public decimal? HousingAllowance { get; set; }
        public decimal? OtherAllowances { get; set; }
        public DateTime? DtContractDue { get; set; }

        // Foreign Keys
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int JobId { get; set; }
        public int NationalityId { get; set; }
        public int MaritalStatusId { get; set; }
        public int BloodTypeId { get; set; }
        public int FacultyId { get; set; }
        public int SectorId { get; set; }

    }
}
