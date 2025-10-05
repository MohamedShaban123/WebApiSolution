using AutoMapper;
using WebApi.Dtos;
using WebApi.Enums;
using WebApi.Errors;
using WebApi.Models;
using WebApi.Repository.IRepo;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class HrIndexService : IHrIndexService
    {
        private readonly IGenericRepository<HrIndex> _indexRepository;
        private readonly IMapper _mapper;

        public HrIndexService(IGenericRepository<HrIndex> indexRepository, IMapper mapper)
        {
            _indexRepository = indexRepository;
            _mapper = mapper;
        }


        public async Task<ApiResponse<IEnumerable<HrIndexDto>>> GetAllHrIndexServiceAsync()
        {
            ApiResponse<IEnumerable<HrIndexDto>> result = new ApiResponse<IEnumerable<HrIndexDto>>();
            var indices = await _indexRepository.GetAllAsync();
            var dtolistmapping = _mapper.Map<IEnumerable<HrIndex>, IEnumerable<HrIndexDto>>(indices);
            result.IsSuccess = true;
            result.Message = "Success";
            result.Data = dtolistmapping;
            result.Errors = new List<ApiError>();
            return result;
        }

        public async Task<ApiResponse<HrIndexDto?>> GetHrIndexServiceByIdAsync(int id)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();

            var index = await _indexRepository.GetByIdAsync(id);

            if (index == null)
            {
                result.IsSuccess = false;
                result.Message = "id not found";
                result.Data = null;
                result.Errors = new List<ApiError>()
                  {
                    new ApiError(){StatusCode=404,Message=$"HR_Index not found with id {id}"}
                  };
                return result;
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "success";
                result.Data = _mapper.Map<HrIndexDto>(index);
                result.Errors = new List<ApiError>();
                return result;
            }

        }


        public async Task<ApiResponse<HrIndexDto>> UpdateHrIndexServiceAsync(HrIndexDto entity)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();
            var isUpdate = await _indexRepository.UpdateAsync(_mapper.Map<HrIndexDto, HrIndex>(entity));
            if (isUpdate)
            {
                result.IsSuccess = true;
                result.Message = "updated successfully";
                result.Data = null;
                result.Errors = new List<ApiError>();
                return result;

            }
            else
            {
                result.IsSuccess = false;
                result.Message = "updated failed";
                result.Data = null;
                result.Errors = new List<ApiError>()
                  {
                    new ApiError(){StatusCode=500,Message=$"Exception Occured  While saving in database"}
                  };
                return result;
            }
               
        }






        public async Task<ApiResponse<HrIndexDto?>> AddHrIndexServiceAsync(HrIndexDto entity)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();

            if (!Enum.IsDefined(typeof(IndexType), entity.indexType))
            {
                var allowed = string.Join(", ", Enum.GetNames(typeof(IndexType)));
                result.IsSuccess = false;
                result.Message = $"Invalid indexType value. Allowed values: {allowed}";
                result.Data = null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode = 400, Message = "bad request", Details = "check you match validation or not" } };
                return result;
            }
            else
            {
                    var index = await _indexRepository.AddAsync(_mapper.Map<HrIndexDto, HrIndex>(entity));
                    result.IsSuccess = true;
                    result.Message = "add successfully";
                    result.Data = new HrIndexDto { Id = index.Id, arName = index.ArName, indexType = entity.indexType  };
                    result.Errors = new List<ApiError>();
                    return result;       
            }
        }





        public async Task<ApiResponse<HrIndexDto>> DeleteHrIndexServiceAsync(int id)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();
            var isDelete = await _indexRepository.DeleteAsync(id);
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



    

    }
}
