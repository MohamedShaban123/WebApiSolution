using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Services.Implementations;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

     
        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EmployeeDto>>>> GetEmployees()
        {
            var response = await _employeeService.GetAllEmployeeServiceAsync();
            return Ok(response);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> GetHrEmployeeById(int id)
        {
            var response = await _employeeService.GetEmployeeServiceByIdAsync(id);
            return Ok(response);
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> DeleteEmployee(int id)
        {
            var response = await _employeeService.DeleteEmployeeServiceAsync(id);
            return Ok(response);
        }


        //// PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto hrAsset)
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            if (id != hrAsset.Id)
            {
                result.IsSuccess = false;
                result.Message = "Bad request";
                result.Data = null;
                result.Errors = new List<ApiError> { new ApiError { StatusCode = 400, Message = $"Bad request", Details = $"The ID in the URL ({id}) does not match the ID in the body ({hrAsset.Id})." } };
                return Ok(result);
            }
            else
            {
                var response = await _employeeService.UpdateEmployeeServiceAsync(hrAsset);
                return Ok(response);
            }
        }



        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<ApiResponse<EmployeeDto>>> AddHrIndex([FromBody] EmployeeDtoPost hrIndex)
        {
            var response = await _employeeService.AddEmployeeServiceAsync(hrIndex);
            return Ok(response);
        }





    }
}
