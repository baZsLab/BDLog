using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDPFMA.Contexts;
using BDPFMA.Models;

namespace BDPFMA.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIMcunitsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIMcunitsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIMcunits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfMcunit>>> GetBdpfMcunits()
        {
            return await _context.BdpfMcunits.ToListAsync();
        }

        // GET: api/BIMcunits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfMcunit>> GetBdpfMcunit(int id)
        {
            var bdpfMcunit = await _context.BdpfMcunits.FindAsync(id);

            if (bdpfMcunit == null)
            {
                return NotFound();
            }

            return bdpfMcunit;
        }

        // PUT: api/BIMcunits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfMcunit(int id, BdpfMcunit bdpfMcunit)
        {
            if (id != bdpfMcunit.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfMcunit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfMcunitExists(id))
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

        // POST: api/BIMcunits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfMcunit>> PostBdpfMcunit(BdpfMcunit bdpfMcunit)
        {
            _context.BdpfMcunits.Add(bdpfMcunit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfMcunit", new { id = bdpfMcunit.UnitId }, bdpfMcunit);
        }

        // DELETE: api/BIMcunits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfMcunit(int id)
        {
            var bdpfMcunit = await _context.BdpfMcunits.FindAsync(id);
            if (bdpfMcunit == null)
            {
                return NotFound();
            }

            _context.BdpfMcunits.Remove(bdpfMcunit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfMcunitExists(int id)
        {
            return _context.BdpfMcunits.Any(e => e.UnitId == id);
        }
    }
}
