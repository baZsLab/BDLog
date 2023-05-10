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
    public class BIOpsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIOpsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIOps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfOp>>> GetBdpfOps()
        {
            return await _context.BdpfOps.ToListAsync();
        }

        // GET: api/BIOps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfOp>> GetBdpfOp(int id)
        {
            var bdpfOp = await _context.BdpfOps.FindAsync(id);

            if (bdpfOp == null)
            {
                return NotFound();
            }

            return bdpfOp;
        }

        // PUT: api/BIOps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfOp(int id, BdpfOp bdpfOp)
        {
            if (id != bdpfOp.OpId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfOp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfOpExists(id))
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

        // POST: api/BIOps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfOp>> PostBdpfOp(BdpfOp bdpfOp)
        {
            _context.BdpfOps.Add(bdpfOp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfOp", new { id = bdpfOp.OpId }, bdpfOp);
        }

        // DELETE: api/BIOps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfOp(int id)
        {
            var bdpfOp = await _context.BdpfOps.FindAsync(id);
            if (bdpfOp == null)
            {
                return NotFound();
            }

            _context.BdpfOps.Remove(bdpfOp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfOpExists(int id)
        {
            return _context.BdpfOps.Any(e => e.OpId == id);
        }
    }
}
