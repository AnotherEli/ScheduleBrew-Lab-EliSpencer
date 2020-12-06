using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleBrewEFClasses.Models;

namespace ScheduleBrewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchContainersController : ControllerBase
    {
        private readonly ScheduleBrewSolutionContext _context;

        public BatchContainersController(ScheduleBrewSolutionContext context)
        {
            _context = context;
        }

        // GET: api/BatchContainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatchContainer>>> GetBatchContainer()
        {
            return await _context.BatchContainer.ToListAsync();
        }

        // GET: api/BatchContainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatchContainer>> GetBatchContainer(int id)
        {
            var batchContainer = await _context.BatchContainer.FindAsync(id);

            if (batchContainer == null)
            {
                return NotFound();
            }

            return batchContainer;
        }

        // PUT: api/BatchContainers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatchContainer(int id, BatchContainer batchContainer)
        {
            if (id != batchContainer.BatchId)
            {
                return BadRequest();
            }

            _context.Entry(batchContainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchContainerExists(id))
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

        // POST: api/BatchContainers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BatchContainer>> PostBatchContainer(BatchContainer batchContainer)
        {
            _context.BatchContainer.Add(batchContainer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BatchContainerExists(batchContainer.BatchId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBatchContainer", new { id = batchContainer.BatchId }, batchContainer);
        }

        // DELETE: api/BatchContainers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BatchContainer>> DeleteBatchContainer(int id)
        {
            var batchContainer = await _context.BatchContainer.FindAsync(id);
            if (batchContainer == null)
            {
                return NotFound();
            }

            _context.BatchContainer.Remove(batchContainer);
            await _context.SaveChangesAsync();

            return batchContainer;
        }

        private bool BatchContainerExists(int id)
        {
            return _context.BatchContainer.Any(e => e.BatchId == id);
        }
    }
}
