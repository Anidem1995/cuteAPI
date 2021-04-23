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
    public class CollectionDetailsController : ControllerBase
    {
        private readonly cute_homeContext _context;

        public CollectionDetailsController(cute_homeContext context)
        {
            _context = context;
        }

        // GET: api/CollectionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDetail>>> GetCollectionDetails()
        {
            return await _context.CollectionDetails.ToListAsync();
        }

        // GET: api/CollectionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionDetail>> GetCollectionDetail(int id)
        {
            var collectionDetail = await _context.CollectionDetails.FindAsync(id);

            if (collectionDetail == null)
            {
                return NotFound();
            }

            return collectionDetail;
        }

        // PUT: api/CollectionDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectionDetail(int id, CollectionDetail collectionDetail)
        {
            if (id != collectionDetail.IdMovement)
            {
                return BadRequest();
            }

            _context.Entry(collectionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionDetailExists(id))
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

        // POST: api/CollectionDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectionDetail>> PostCollectionDetail(CollectionDetail collectionDetail)
        {
            _context.CollectionDetails.Add(collectionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollectionDetail", new { id = collectionDetail.IdMovement }, collectionDetail);
        }

        // DELETE: api/CollectionDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectionDetail(int id)
        {
            var collectionDetail = await _context.CollectionDetails.FindAsync(id);
            if (collectionDetail == null)
            {
                return NotFound();
            }

            _context.CollectionDetails.Remove(collectionDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectionDetailExists(int id)
        {
            return _context.CollectionDetails.Any(e => e.IdMovement == id);
        }
    }
}
