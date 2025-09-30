using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Dtos;
using WebApi.Errors;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomHRIndex : ControllerBase
    {
        private readonly IIndexRepository<HrIndex> _indexRepository;

        public CustomHRIndex(IIndexRepository<HrIndex> indexRepository)
        {
            _indexRepository = indexRepository;
        }

        // GET: api/CustomHRIndex
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HrIndexDto>>>> GetHrIndices()
        {
            ApiResponse<IEnumerable<HrIndexDto>> result = new ApiResponse<IEnumerable<HrIndexDto>>();
            var indices = await _indexRepository.GetAllAsync();
            var dtoList = indices.Select(i => new HrIndexDto
            {
                arName = i.ArName,
                enName = i.EnName
            }).ToList();
            result.IsSuccess = true;
            result.Message = "Success";
            result.Data = dtoList;
            result.Errors = new List<ApiError>();
            return Ok(result);
        }

        // GET: api/CustomHRIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrIndexDto>> GetHrIndex(int id)
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
                return Ok(result);
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "id already exist";
                result.Data = new HrIndexDto {arName=index.ArName,enName=index.EnName};
                result.Errors = new List<ApiError>();
                return Ok(result);
            }
        }

        // PUT: api/CustomHRIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHrIndex(int id, HrIndex hrIndex)
        {
            ApiResponse<HrIndex> result = new ApiResponse<HrIndex>();

            if (id != hrIndex.Id)
            {
                result.IsSuccess = false;
                result.Message = "Bad request";
                result.Data = null;
                result.Errors = new List<ApiError> { new ApiError { StatusCode = 400, Message = $"Bad request", Details = $"The ID in the URL ({id}) does not match the ID in the body ({hrIndex.Id})." } };
                return Ok(result);
            }
            else
            {
                var isUpdate = await _indexRepository.UpdateAsync(hrIndex);
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

        // POST: api/CustomHRIndex
        [HttpPost]
        public async Task<ActionResult<HrIndexDto>> PostHrIndex(HrIndexDto hrIndex)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();
            var index = await _indexRepository.AddAsync(new HrIndex { ArName=hrIndex.arName,EnName=hrIndex.enName});
            if (index == null)
            {
                result.IsSuccess = false;
                result.Message = "Problem occured while add hrIndex";
                result.Data=null;
                result.Errors = new List<ApiError>() { new ApiError { StatusCode=400,Message="bad request",Details="check you match validation or not"} };
                return Ok(result);
            }
            else
            {
                result.IsSuccess = true;
                result.Message = "add successfully";
                result.Data = new HrIndexDto { arName=index.ArName,enName=index.EnName};
                result.Errors = new List<ApiError>();
                return Ok(result);
            }
        }

        // DELETE: api/CustomHRIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrIndex(int id)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();
            var isDelete = await _indexRepository.DeleteAsync(id);
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

    }
}
