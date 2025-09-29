using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class HrIndexDto
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string? arName { get; set; }
        [MaxLength(150)]
        public string? enName { get; set; }

    }
}
