using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResponse<IEnumerable<EmployeeDto>>> GetAllEmployeeServiceAsync();
        Task<ApiResponse<EmployeeDto?>> GetEmployeeServiceByIdAsync(int id);
        Task<ApiResponse<EmployeeDto>> UpdateEmployeeServiceAsync(EmployeeDto entity);
        Task<ApiResponse<EmployeeDto?>> AddEmployeeServiceAsync(EmployeeDtoPost entity);
        Task<ApiResponse<EmployeeDto>> DeleteEmployeeServiceAsync(int id);
    }
}
