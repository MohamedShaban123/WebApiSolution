using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IHrIndexService
    {
        Task< ApiResponse<IEnumerable<HrIndexDto>>> GetAllHrIndexServiceAsync();
        Task<ApiResponse<HrIndexDto?>> GetHrIndexServiceByIdAsync(int id);
        Task<ApiResponse<HrIndexDto>> UpdateHrIndexServiceAsync(HrIndexDto entity);
        Task<ApiResponse<HrIndexDto?>> AddHrIndexServiceAsync(HrIndexDto entity);
        Task<ApiResponse<HrIndexDto>> DeleteHrIndexServiceAsync(int id);
    }
}
