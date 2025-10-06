using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class HrAssetDtoPost
    {
        [Required(ErrorMessage = "Employee ID is required")]
        public int EmplId { get; set; }

        [Required(ErrorMessage = "Asset name is required")]
        [MaxLength(200)]
        public string? Name { get; set; }

        public int? GroupId { get; set; }

        [Required(ErrorMessage = "Serial number is required")]
        [MaxLength(100)]
        public string? Serial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DtAssigned { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DtReturned { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }

        [Required(ErrorMessage = "Branch ID is required")]
        public int BranchId { get; set; }

        [MaxLength(200)]
        public string? Txt1 { get; set; }

        [MaxLength(200)]
        public string? Txt2 { get; set; }

        [MaxLength(200)]
        public string? Txt3 { get; set; }

        [MaxLength(200)]
        public string? Txt4 { get; set; }

        [MaxLength(200)]
        public string? Txt5 { get; set; }

        [MaxLength(200)]
        public string? Txt6 { get; set; }

        [MaxLength(200)]
        public string? Txt7 { get; set; }

        [MaxLength(200)]
        public string? Txt8 { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
