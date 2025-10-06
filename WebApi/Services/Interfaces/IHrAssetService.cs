using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Services.Interfaces
{
    public interface IHrAssetService
    {
        Task<ApiResponse<IEnumerable<HrAssetDto>>> GetAllHrAssetServiceAsync();
        Task<ApiResponse<HrAssetDto?>> GetHrAssetServiceByIdAsync(int id);
        Task<ApiResponse<HrAssetDto>> UpdateHrAssetServiceAsync(HrAssetDto entity);
        Task<ApiResponse<HrAssetDto?>> AddHrAssetServiceAsync(HrAssetDtoPost entity);
        Task<ApiResponse<HrAssetDto>> DeleteHrAssetServiceAsync(int id);
    }
}
