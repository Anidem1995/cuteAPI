using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cuteAPI.Models;

namespace cuteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeasingContractsController : ControllerBase
    {
        private readonly cute_homeContext _context;

        public LeasingContractsController(cute_homeContext context)
        {
            _context = context;
        }

        // GET: api/LeasingContracts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeasingContract>>> GetLeasingContracts()
        {
            return await _context.LeasingContracts.ToListAsync();
        }

        // GET: api/LeasingContracts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeasingContract>> GetLeasingContract(int id)
        {
            var leasingContract = await _context.LeasingContracts.FindAsync(id);

            if (leasingContract == null)
            {
                return NotFound();
            }

            return leasingContract;
        }

        // PUT: api/LeasingContracts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeasingContract(int id, LeasingContract leasingContract)
        {
            if (id != leasingContract.IdContract)
            {
                return BadRequest();
            }

            _context.Entry(leasingContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeasingContractExists(id))
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

        // POST: api/LeasingContracts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeasingContract>> PostLeasingContract(LeasingContract leasingContract)
        {
            _context.LeasingContracts.Add(leasingContract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeasingContract", new { id = leasingContract.IdContract }, leasingContract);
        }

        // DELETE: api/LeasingContracts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeasingContract(int id)
        {
            var leasingContract = await _context.LeasingContracts.FindAsync(id);
            if (leasingContract == null)
            {
                return NotFound();
            }

            _context.LeasingContracts.Remove(leasingContract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeasingContractExists(int id)
        {
            return _context.LeasingContracts.Any(e => e.IdContract == id);
        }
    }
}
