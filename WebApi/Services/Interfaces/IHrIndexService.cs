using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Services.Interfaces
{
    public interface IHrIndexService
    {
        Task< ApiResponse<IEnumerable<HrIndexDto>>> GetAllHrIndexServiceAsync();
        Task<ApiResponse<HrIndexDto?>> GetHrIndexServiceByIdAsync(int id);
        Task<ApiResponse<HrIndexDto>> UpdateHrIndexServiceAsync(HrIndexDto entity);
        Task<ApiResponse<HrIndexDto?>> AddHrIndexServiceAsync(HrIndexDtoPost entity);
        Task<ApiResponse<HrIndexDto>> DeleteHrIndexServiceAsync(int id);
    }
}
