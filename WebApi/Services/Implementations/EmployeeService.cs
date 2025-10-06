using AutoMapper;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Repository.IRepo;
using WebApi.Repository.Repositories;
using WebApi.Services.Interfaces;



namespace WebApi.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<HrIndex> _indexRepository;
        private readonly IGenericRepository<CompanyBranch> _branchRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> employeeRepository
            ,IGenericRepository<HrIndex> indexRepository,
            IGenericRepository<CompanyBranch> branchRepository,IMapper mapper)
        {  
            _employeeRepository = employeeRepository;
            _indexRepository = indexRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<EmployeeDto>>> GetAllEmployeeServiceAsync()
        {
            ApiResponse<IEnumerable<EmployeeDto>> result = new ApiResponse<IEnumerable<EmployeeDto>>();
            var employees = await _employeeRepository.GetAllAsync();
            var dtolistmapping = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            result.IsSuccess = true;
            result.Message = "Success";
            result.Data = dtolistmapping;
            result.Errors = new List<ApiError>();
            return result;
        }


        public async Task<ApiResponse<EmployeeDto?>> GetEmployeeServiceByIdAsync(int id)
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                result.IsSuccess = false;
                result.Message = "id not found";
                result.Data = null;
                result.Errors = new List<ApiError>()
                  {
                    new ApiError(){StatusCode=404,Message=$"employee not found with id {id}"}
                  };
                return result;
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "id already exist";
                result.Data = _mapper.Map<Employee, EmployeeDto>(employee);
                result.Errors = new List<ApiError>();
                return result;
            }
        }





        public async Task<ApiResponse<EmployeeDto?>> AddEmployeeServiceAsync(EmployeeDtoPost entity)
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            var branch = await _branchRepository.GetByIdAsync(entity.BranchId);
            if (branch is null)
            {
                result.IsSuccess = false;
                result.Message = $"The branch with ID {entity.BranchId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The branch with ID {entity.BranchId} does not exist. Please provide a valid Branch ID." } };
                return result;
            }

            var departemnt = await _indexRepository.GetByIdAsync(entity.DepartmentId);
            if (departemnt is null)
            {
                result.IsSuccess = false;
                result.Message = $"The departemnt with ID {entity.DepartmentId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The departemnt with ID {entity.DepartmentId} does not exist. Please provide a valid departemnt ID." } };
                return result;
            }

            var job = await _indexRepository.GetByIdAsync(entity.JobId);
            if (job is null)
            {
                result.IsSuccess = false;
                result.Message = $"The job with ID {entity.JobId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The job with ID {entity.JobId} does not exist. Please provide a valid job ID." } };
                return result;
            }


            var nationality = await _indexRepository.GetByIdAsync(entity.NationalityId);
            if (nationality is null)
            {
                result.IsSuccess = false;
                result.Message = $"The nationality with ID {entity.NationalityId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The nationality with ID {entity.NationalityId} does not exist. Please provide a valid nationality ID." } };
                return result;
            }

            var maritalstatus = await _indexRepository.GetByIdAsync(entity.MaritalStatusId);
            if (maritalstatus is null)
            {
                result.IsSuccess = false;
                result.Message = $"The maritalstatus with ID {entity.MaritalStatusId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The maritalstatus with ID {entity.MaritalStatusId} does not exist. Please provide a valid maritalstatus ID." } };
                return result;
            }

            var bloodtype = await _indexRepository.GetByIdAsync(entity.BloodTypeId);
            if (bloodtype is null)
            {
                result.IsSuccess = false;
                result.Message = $"The bloodtype with ID {entity.BloodTypeId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The bloodtype with ID {entity.BloodTypeId} does not exist. Please provide a valid bloodtype ID." } };
                return result;
            }

            var faculty = await _indexRepository.GetByIdAsync(entity.FacultyId);
            if (faculty is null)
            {
                result.IsSuccess = false;
                result.Message = $"The faculty with ID {entity.FacultyId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The faculty with ID {entity.FacultyId} does not exist. Please provide a valid faculty ID." } };
                return result;
            }

            var sector = await _indexRepository.GetByIdAsync(entity.SectorId);
            if (sector is null)
            {
                result.IsSuccess = false;
                result.Message = $"The sector with ID {entity.SectorId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The sector with ID {entity.SectorId} does not exist. Please provide a valid sector ID." } };
                return result;
            }
            var employee = await _employeeRepository.AddAsync(_mapper.Map<EmployeeDtoPost,Employee>(entity));
            result.IsSuccess = true;
            result.Message = "add successfully";
            result.Data = _mapper.Map<Employee, EmployeeDto>(employee);
            result.Errors = new List<ApiError>();
            return result;
        }






        public async Task<ApiResponse<EmployeeDto>> DeleteEmployeeServiceAsync(int id)
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            var isDelete = await _employeeRepository.DeleteAsync(id);
            if (isDelete)
            {
                result.IsSuccess = true;
                result.Message = "delete successfully";
                result.Data = null;
                result.Errors = new List<ApiError>();
                return result;
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "id not exist";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 404, Message = "id not exist", Details = "id not exist " } };
                return result;
            }

        }


        public async Task<ApiResponse<EmployeeDto>> UpdateEmployeeServiceAsync(EmployeeDto entity)
        {
            ApiResponse<EmployeeDto> result = new ApiResponse<EmployeeDto>();
            var branch = await _branchRepository.GetByIdAsync(entity.BranchId);
            if (branch is null)
            {
                result.IsSuccess = false;
                result.Message = $"The branch with ID {entity.BranchId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The branch with ID {entity.BranchId} does not exist. Please provide a valid Branch ID." } };
                return result;
            }

            var departemnt = await _indexRepository.GetByIdAsync(entity.DepartmentId);
            if (departemnt is null)
            {
                result.IsSuccess = false;
                result.Message = $"The departemnt with ID {entity.DepartmentId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The departemnt with ID {entity.DepartmentId} does not exist. Please provide a valid departemnt ID." } };
                return result;
            }

            var job = await _indexRepository.GetByIdAsync(entity.JobId);
            if (job is null)
            {
                result.IsSuccess = false;
                result.Message = $"The job with ID {entity.JobId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The job with ID {entity.JobId} does not exist. Please provide a valid job ID." } };
                return result;
            }


            var nationality = await _indexRepository.GetByIdAsync(entity.NationalityId);
            if (nationality is null)
            {
                result.IsSuccess = false;
                result.Message = $"The nationality with ID {entity.NationalityId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The nationality with ID {entity.NationalityId} does not exist. Please provide a valid nationality ID." } };
                return result;
            }

            var maritalstatus = await _indexRepository.GetByIdAsync(entity.MaritalStatusId);
            if (maritalstatus is null)
            {
                result.IsSuccess = false;
                result.Message = $"The maritalstatus with ID {entity.MaritalStatusId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The maritalstatus with ID {entity.MaritalStatusId} does not exist. Please provide a valid maritalstatus ID." } };
                return result;
            }

            var bloodtype = await _indexRepository.GetByIdAsync(entity.BloodTypeId);
            if (bloodtype is null)
            {
                result.IsSuccess = false;
                result.Message = $"The bloodtype with ID {entity.BloodTypeId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The bloodtype with ID {entity.BloodTypeId} does not exist. Please provide a valid bloodtype ID." } };
                return result;
            }
            var isUpdate = await _employeeRepository.UpdateAsync(_mapper.Map<EmployeeDto, Employee>(entity));
            if (isUpdate)
            {
                result.IsSuccess = true;
                result.Message = "updated successfully";
                result.Data = null;
                result.Errors = new List<ApiError>();

            }
            return result;


        }

     
    }
}
