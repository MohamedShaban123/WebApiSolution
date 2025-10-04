using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Enums;
using WebApi.Errors;
using WebApi.Models;
using WebApi.Repository.IRepo;
using WebApi.Repository.Repo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomAsset : ControllerBase
    {
        private readonly IGenericRepository<HrAsset> _assetRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<CompanyBranch> _branchRepository;
        private readonly IMapper _mapper;




        public CustomAsset(IGenericRepository<HrAsset> assetRepository,
           IGenericRepository<Employee> employeeRepository,
           IGenericRepository<CompanyBranch> branchRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _employeeRepository = employeeRepository;
           _branchRepository = branchRepository;
            _mapper = mapper;
        }




        // GET: api/CustomAsset
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HrAsset>>>> GetHRAssets()
        {
            ApiResponse<IEnumerable<HrAssetDto>> result = new ApiResponse<IEnumerable<HrAssetDto>>();
            var assets = await _assetRepository.GetAllAsync();
            var dtolistmapping = _mapper.Map<IEnumerable<HrAsset>, IEnumerable<HrAssetDto>>(assets);
            result.IsSuccess = true;
            result.Message = "Success";
            result.Data = dtolistmapping;
            result.Errors = new List<ApiError>();
            return Ok(result);
        }


        // GET: api/CustomAsset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrAssetDto>> GetHrAssetById(int id)
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
                return Ok(result);
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "id already exist";
                result.Data = _mapper.Map<HrAsset, HrAssetDto>(asset);
                result.Errors = new List<ApiError>();
                return Ok(result);
            }
        }




        // POST: api/CustomAsset
        [HttpPost]
        public async Task<ActionResult<HrAssetDto>> AddHrAsset(HrAssetDto hrAsset)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();
            var employee = await _employeeRepository.GetByIdAsync(hrAsset.EmplId);
            if (employee is null)
            {
                result.IsSuccess = false;
                result.Message = $"The employee with ID {hrAsset.EmplId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The employee with ID {hrAsset.EmplId} does not exist. Please provide a valid Employee ID." } };
                return Ok(result);
            }
            var branch = await _branchRepository.GetByIdAsync(hrAsset.BranchId);
            if (branch is null)
            {
                result.IsSuccess = false;
                result.Message = $"The branch with ID {hrAsset.BranchId} does not exist.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = $"The branch with ID {hrAsset.BranchId} does not exist. Please provide a valid Branch ID." } };
                return Ok(result);
            }

             var assets = await _assetRepository.GetAllAsync();
             var isSerialDuplicate=assets?.Any(asset => asset.Serial == hrAsset.Serial);
             if(isSerialDuplicate is true)
             {
                result.IsSuccess = false;
                result.Message = "Serial number already exists. Please enter a unique serial number.";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = "The serial number you entered is already in use. Each asset must have a unique serial number." } };

                return Ok(result);
            }


             var asset = await _assetRepository.AddAsync(_mapper.Map<HrAssetDto,HrAsset>(hrAsset));
                result.IsSuccess = true;
                result.Message = "add successfully";
                result.Data = _mapper.Map<HrAsset, HrAssetDto>(asset);
                result.Errors = new List<ApiError>();
                return Ok(result);       
        }



        // DELETE: api/CustomAsset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrAsset(int id)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();
            var isDelete = await _assetRepository.DeleteAsync(id);
            if (isDelete)
            {
                result.IsSuccess = true;
                result.Message = "delete successfully";
                result.Data = null;
                result.Errors = new List<ApiError>();
                return Ok(result);
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "id not exist";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 404, Message = "id not exist", Details = "id not exist " } };
                return Ok(result);
            }
        }






        //// PUT: api/CustomAsset/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHrAsset(int id, HrAssetDto hrAsset)
        {
            ApiResponse<HrAssetDto> result = new ApiResponse<HrAssetDto>();

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

                var isUpdate = await _assetRepository.UpdateAsync(_mapper.Map<HrAssetDto,HrAsset>(hrAsset));
                if (isUpdate)
                {
                    result.IsSuccess = true;
                    result.Message = "updated successfully";
                    result.Data = null;
                    result.Errors = new List<ApiError>();

                }
                return Ok(result);
            }
        }



    }
}
