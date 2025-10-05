using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Dtos;
using WebApi.Enums;
using WebApi.Errors;
using WebApi.Models;
using WebApi.Repository.IRepo;
using WebApi.Services.Interfaces;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HR_IndexController : ControllerBase
    {
        private readonly IHrIndexService _hrIndexService;

        public HR_IndexController(IHrIndexService hrIndexService)
        {
            this._hrIndexService = hrIndexService;
        }




        // GET: api/CustomHRIndex
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HrIndexDto>>>> GetHrIndices()
        {
            var response = await _hrIndexService.GetAllHrIndexServiceAsync();
            return Ok(response);
        }



        // GET: api/CustomHRIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<HrIndexDto>>> GetHrIndexById(int id)
        {
            var index = await _hrIndexService.GetHrIndexServiceByIdAsync(id);
            return Ok(index);
        }




        //// PUT: api/CustomHRIndex/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<HrIndexDto>>> UpdateHrIndex(int id, HrIndexDto hrIndex)
        {
            ApiResponse<HrIndexDto> result = new ApiResponse<HrIndexDto>();

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
                var response = await _hrIndexService.UpdateHrIndexServiceAsync(hrIndex);
                return Ok(response);
            }
        }




        // POST: api/CustomHRIndex
        [HttpPost]
        public async Task<ActionResult<ApiResponse<HrIndexDto>>> AddHrIndex(HrIndexDto hrIndex)
        {
            var response = await _hrIndexService.AddHrIndexServiceAsync(hrIndex);
            return Ok(response);
        }




        // DELETE: api/CustomHRIndex/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<HrIndexDto>>> DeleteHrIndex(int id)
        {
            var response = await _hrIndexService.DeleteHrIndexServiceAsync(id);
            return Ok(response);
        }

    }
}
