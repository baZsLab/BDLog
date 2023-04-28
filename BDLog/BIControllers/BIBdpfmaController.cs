using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;

namespace BDELog.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIBdpfmaController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIBdpfmaController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIBdpfma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfBdpfma>>> GetBdpfBdpfmas()
        {
            return await _context.BdpfBdpfmas.ToListAsync();
        }

        // GET: api/BIBdpfma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfBdpfma>> GetBdpfBdpfma(long id)
        {
            var bdpfBdpfma = await _context.BdpfBdpfmas.FindAsync(id);

            if (bdpfBdpfma == null)
            {
                return NotFound();
            }

            return bdpfBdpfma;
        }

        // PUT: api/BIBdpfma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfBdpfma(long id, BdpfBdpfma bdpfBdpfma)
        {
            if (id != bdpfBdpfma.BdId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfBdpfma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfBdpfmaExists(id))
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

        // POST: api/BIBdpfma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfBdpfma>> PostBdpfBdpfma(BdpfBdpfma bdpfBdpfma)
        {
            _context.BdpfBdpfmas.Add(bdpfBdpfma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfBdpfma", new { id = bdpfBdpfma.BdId }, bdpfBdpfma);
        }

        // DELETE: api/BIBdpfma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfBdpfma(long id)
        {
            var bdpfBdpfma = await _context.BdpfBdpfmas.FindAsync(id);
            if (bdpfBdpfma == null)
            {
                return NotFound();
            }

            _context.BdpfBdpfmas.Remove(bdpfBdpfma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfBdpfmaExists(long id)
        {
            return _context.BdpfBdpfmas.Any(e => e.BdId == id);
        }
    }
}
