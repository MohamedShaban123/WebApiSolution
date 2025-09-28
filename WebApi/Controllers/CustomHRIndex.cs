using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomHRIndex : ControllerBase
    {
        private readonly DexefdbSampleContext _context;

        public CustomHRIndex(DexefdbSampleContext context)
        {
            _context = context;
        }

        // GET: api/CustomHRIndex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HrIndex>>> GetHrIndices()
        {
            return await _context.HrIndices.ToListAsync();
        }

        // GET: api/CustomHRIndex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrIndex>> GetHrIndex(int id)
        {
            var hrIndex = await _context.HrIndices.FindAsync(id);

            if (hrIndex == null)
            {
                return NotFound();
            }

            return hrIndex;
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

            _context.Entry(hrIndex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HrIndexExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomHRIndex
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HrIndex>> PostHrIndex(HrIndex hrIndex)
        {
            _context.HrIndices.Add(hrIndex);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHrIndex", new { id = hrIndex.Id }, hrIndex);
        }

        // DELETE: api/CustomHRIndex/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHrIndex(int id)
        {
            var hrIndex = await _context.HrIndices.FindAsync(id);
            if (hrIndex == null)
            {
                return NotFound();
            }

            _context.HrIndices.Remove(hrIndex);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HrIndexExists(int id)
        {
            return _context.HrIndices.Any(e => e.Id == id);
        }
    }
}
