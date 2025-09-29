using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Dtos;
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
        public async Task<ActionResult<IEnumerable<HrIndexDto>>> GetHrIndices()
        {
           var indices = await _indexRepository.GetAllAsync();
            if (indices == null)
            {
                return NotFound();
            }
            else
            {
                var dtoList = indices.Select(i => new HrIndexDto
                {
                    Id = i.Id,
                    arName = i.ArName,
                    enName = i.EnName
                }).ToList();
                return Ok(dtoList);
            }
         
        }

        // GET: api/CustomHRIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrIndexDto>> GetHrIndex(int id)
        {
            var index = await _indexRepository.GetByIdAsync(id);
            if(index == null)
                return NotFound();
            else
            {

                return Ok(new HrIndexDto { Id=index.Id,arName=index.ArName,enName=index.EnName});
            }
        }

        // PUT: api/CustomHRIndex/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHrIndex(int id, HrIndex hrIndex)
        {
            if (id != hrIndex.Id)
            {
                return BadRequest();
            }
            else
            {
              var isUpdate =  await _indexRepository.UpdateAsync(hrIndex);
              if(isUpdate)             
                    return Ok();
             
                else 
                    return NotFound();
            }
        }

        // POST: api/CustomHRIndex
        [HttpPost]
        public async Task<ActionResult<HrIndex>> PostHrIndex(HrIndex hrIndex)
        {
           var index = await _indexRepository.AddAsync(hrIndex);
            if (index == null)
                return NoContent();
            else
                return Ok(index);
        }

        // DELETE: api/CustomHRIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrIndex(int id)
        {
           var isDelete = await _indexRepository.DeleteAsync(id);
            if(isDelete)
                return Ok();
            else 
                return NoContent();
        }  

    }
}
