using AutoMapper;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Repository.IRepo;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class HrAssetService  : IHrAssetService
    {
        private readonly IGenericRepository<HrAsset> _assetRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<CompanyBranch> _branchRepository;
        private readonly IMapper _mapper;


        public HrAssetService(IGenericRepository<HrAsset> assetRepository,
           IGenericRepository<Employee> employeeRepository,
           IGenericRepository<CompanyBranch> branchRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _employeeRepository = employeeRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<HrAssetDto>>> GetAllHrAssetServiceAsync()
        {
            ApiResponse<IEnumerable<HrAssetDto>> result = new ApiResponse<IEnumerable<HrAssetDto>>();
            var assets = await _assetRepository.GetAllAsync();
            var dtolistmapping = _mapper.Map<IEnumerable<HrAsset>, IEnumerable<HrAssetDto>>(assets);
            result.IsSuccess = true;
            result.Message = "Success";
            result.Data = dtolistmapping;
            result.Errors = new List<ApiError>();     
            return result;
        }




        public async Task<ApiResponse<HrAssetDto?>> GetHrAssetServiceByIdAsync(int id)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();
            var asset = await _assetRepository.GetByIdAsync(id);
            if (asset == null)
            {
                result.IsSuccess = false;
                result.Message = "id not found";
                result.Data = null;
                result.Errors = new List<ApiError>()
                  {
                    new ApiError(){StatusCode=404,Message=$"asset not found with id {id}"}
                  };
                return result;
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "id already exist";
                result.Data = _mapper.Map<HrAsset,HrAssetDto>(asset);
                result.Errors = new List<ApiError>();
                return result;
            }
        }





        public async Task<ApiResponse<HrAssetDto?>> AddHrAssetServiceAsync(HrAssetDtoPost entity)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();

            var employee = await _employeeRepository.GetByIdAsync(entity.EmplId);
            if (employee is null)
            {
                result.IsSuccess = false;
                result.Message = $"The employee with ID {entity.EmplId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The employee with ID {entity.EmplId} does not exist. Please provide a valid Employee ID." } };
                return result;
            }

            var branch = await _branchRepository.GetByIdAsync(entity.BranchId);
            if (branch is null)
            {
                result.IsSuccess = false;
                result.Message = $"The branch with ID {entity.BranchId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The branch with ID {entity.BranchId} does not exist. Please provide a valid Branch ID." } };
                return result;
            }

            var assets = await _assetRepository.GetAllAsync();
            var isSerialDuplicate = assets?.Any(asset => asset.Serial == entity.Serial);
            if (isSerialDuplicate is true)
            {
                result.IsSuccess = false;
                result.Message = "Serial number already exists. Please enter a unique serial number.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = "The serial number you entered is already in use. Each asset must have a unique serial number." } };

                return result;
            }
            var asset = await _assetRepository.AddAsync(_mapper.Map<HrAssetDtoPost, HrAsset>(entity));
            result.IsSuccess = true;
            result.Message = "add successfully";
            result.Data = _mapper.Map<HrAsset, HrAssetDto>(asset);
            result.Errors = new List<ApiError>();
            return result;
        }







        public async Task<ApiResponse<HrAssetDto>> DeleteHrAssetServiceAsync(int id)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();
            var isDelete = await _assetRepository.DeleteAsync(id);
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





        public async Task<ApiResponse<HrAssetDto>> UpdateHrAssetServiceAsync(HrAssetDto entity)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();
            var employee = await _employeeRepository.GetByIdAsync(entity.EmplId);
            if (employee is null)
            {
                result.IsSuccess = false;
                result.Message = $"The employee with ID {entity.EmplId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The employee with ID {entity.EmplId} does not exist. Please provide a valid Employee ID." } };
                return result;
            }
            var branch = await _branchRepository.GetByIdAsync(entity.BranchId);
            if (branch is null)
            {
                result.IsSuccess = false;
                result.Message = $"The branch with ID {entity.BranchId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The branch with ID {entity.BranchId} does not exist. Please provide a valid Branch ID." } };
                return result;
            }

            var isUpdate = await _assetRepository.UpdateAsync(_mapper.Map<HrAssetDto, HrAsset>(entity));
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

