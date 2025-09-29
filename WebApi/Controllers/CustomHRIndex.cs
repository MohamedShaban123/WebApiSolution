using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
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

        public CustomHRIndex( IIndexRepository<HrIndex> indexRepository)
        {
            _indexRepository = indexRepository;
        }

        // GET: api/CustomHRIndex
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HrIndexDto>>>> GetHrIndices()
        {
            ApiResponse<IEnumerable<HrIndexDto>> result = new ApiResponse<IEnumerable< HrIndexDto>>();

            var indices = await _indexRepository.GetAllAsync();
            if (indices == null)
            {
                //result.IsSuccess = false;
                //result.StatusCode = 404;
                //result.Message = "HR_Index is empty";
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data =null;
                return Ok(result);
               
            }
            else
            {
                var dtoList = indices.Select(i => new HrIndexDto
                {
                    Id = i.Id,
                    arName = i.ArName,
                    enName = i.EnName
                }).ToList();

                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = dtoList;
                return Ok(result);

            }
         
        }

        // GET: api/CustomHRIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrIndexDto>> GetHrIndex(int id)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();
            var index = await _indexRepository.GetByIdAsync(id);
            if(index == null)
            {
                //result.IsSuccess = false;
                //result.StatusCode = 404;
                //result.Message = "Id not exist ";
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = null;
                return Ok(result);
            }
            else
            {
                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = new HrIndexDto { Id=index.Id,arName=index.ArName,enName=index.EnName} ;
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
                //result.IsSuccess = false;
                //result.StatusCode = 404;
                //result.Message = "Id not match id of model";
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = null;
                return Ok(result);
            }
            else
            {
              var isUpdate =  await _indexRepository.UpdateAsync(hrIndex);
                if (isUpdate)
                {
                    //result.IsSuccess = true;
                    //result.StatusCode = 200;
                    //result.Message = string.Empty;
                    //result.Details = string.Empty;
                    //result.Date = DateTime.Now;
                    //result.Data = hrIndex;
                    return Ok(result);
                }

                else
                {
                    //result.IsSuccess =false;
                    //result.StatusCode = 500;
                    //result.Message = string.Empty;
                    //result.Details = string.Empty;
                    //result.Date = DateTime.Now;
                    //result.Data = null;
                    return Ok(result);
                }
            }
        }

        // POST: api/CustomHRIndex
        [HttpPost]
        public async Task<ActionResult<HrIndex>> PostHrIndex(HrIndex hrIndex)
        {
            ApiResponse<HrIndex> result = new ApiResponse<HrIndex>();
            var index = await _indexRepository.AddAsync(hrIndex);
            if (index == null)
            {
                //result.IsSuccess = false;
                //result.StatusCode = 500;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = null;
                return Ok(result);
            }
            else
            {
                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = index;
                return Ok(result);
            }
        }

        // DELETE: api/CustomHRIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrIndex(int id)
        {
            ApiResponse<HrIndex> result = new ApiResponse<HrIndex>();
            var isDelete = await _indexRepository.DeleteAsync(id);
            if(isDelete)
            {
                //result.IsSuccess = true;
                //result.StatusCode = 200;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data =null;
                return Ok(result);
            }
            else
            {
                //result.IsSuccess = false;
                //result.StatusCode = 500;
                //result.Message = string.Empty;
                //result.Details = string.Empty;
                //result.Date = DateTime.Now;
                //result.Data = null;
                return Ok(result);
            }
        }  

    }
}
