using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Dtos;
using WebApi.Enums;
using WebApi.Errors;
using WebApi.Repository.IRepo;
using WebApi.Repository.Repo;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HR_AssetController : ControllerBase
    {
        private readonly IHrAssetService _hrAssetService;

        public HR_AssetController(IHrAssetService hrAssetService)
        {
            _hrAssetService = hrAssetService;
        }




        // GET: api/CustomAsset
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<HrAssetDto>>>> GetHRAssets()
        {
            var response = await _hrAssetService.GetAllHrAssetServiceAsync();
            return Ok(response);
        }



        // GET: api/CustomAsset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrAssetDto>> GetHrAssetById(int id)
        {
            var response = await _hrAssetService.GetHrAssetServiceByIdAsync(id);
            return Ok(response);
        }




        // POST: api/CustomAsset
        [HttpPost]
        public async Task<ActionResult<HrAssetDto>> AddHrAsset(HrAssetDtoPost hrAsset)
        {
            var response = await _hrAssetService.AddHrAssetServiceAsync(hrAsset);
            return Ok(response);
        }




        // DELETE: api/CustomAsset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrAsset(int id)
        {
            var response = await _hrAssetService.DeleteHrAssetServiceAsync(id);
            return Ok(response);
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
                var response = await _hrAssetService.UpdateHrAssetServiceAsync(hrAsset);
                return Ok(response);
            }
        }


    }
}

