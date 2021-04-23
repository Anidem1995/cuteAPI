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
    public class WalletDetailsController : ControllerBase
    {
        private readonly cute_homeContext _context;

        public WalletDetailsController(cute_homeContext context)
        {
            _context = context;
        }

        // GET: api/WalletDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletDetail>>> GetWalletDetails()
        {
            return await _context.WalletDetails.ToListAsync();
        }

        // GET: api/WalletDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WalletDetail>> GetWalletDetail(int id)
        {
            var walletDetail = await _context.WalletDetails.FindAsync(id);

            if (walletDetail == null)
            {
                return NotFound();
            }

            return walletDetail;
        }

        // PUT: api/WalletDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalletDetail(int id, WalletDetail walletDetail)
        {
            if (id != walletDetail.IdDetail)
            {
                return BadRequest();
            }

            _context.Entry(walletDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletDetailExists(id))
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

        // POST: api/WalletDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WalletDetail>> PostWalletDetail(WalletDetail walletDetail)
        {
            _context.WalletDetails.Add(walletDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWalletDetail", new { id = walletDetail.IdDetail }, walletDetail);
        }

        // DELETE: api/WalletDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalletDetail(int id)
        {
            var walletDetail = await _context.WalletDetails.FindAsync(id);
            if (walletDetail == null)
            {
                return NotFound();
            }

            _context.WalletDetails.Remove(walletDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WalletDetailExists(int id)
        {
            return _context.WalletDetails.Any(e => e.IdDetail == id);
        }
    }
}
