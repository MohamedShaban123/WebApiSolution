using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApi.Enums;

namespace WebApi.Dtos
{
    public class HrIndexDtoPost
    {
        [MaxLength(150)]
        public string? arName { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public IndexType? indexType { get; set; }
    }
}
