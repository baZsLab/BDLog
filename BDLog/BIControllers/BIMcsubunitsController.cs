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
    public class BIMcsubunitsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIMcsubunitsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIMcsubunits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfMcsubunit>>> GetBdpfMcsubunits()
        {
            return await _context.BdpfMcsubunits.ToListAsync();
        }

        // GET: api/BIMcsubunits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfMcsubunit>> GetBdpfMcsubunit(int id)
        {
            var bdpfMcsubunit = await _context.BdpfMcsubunits.FindAsync(id);

            if (bdpfMcsubunit == null)
            {
                return NotFound();
            }

            return bdpfMcsubunit;
        }

        // PUT: api/BIMcsubunits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfMcsubunit(int id, BdpfMcsubunit bdpfMcsubunit)
        {
            if (id != bdpfMcsubunit.SubId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfMcsubunit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfMcsubunitExists(id))
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

        // POST: api/BIMcsubunits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfMcsubunit>> PostBdpfMcsubunit(BdpfMcsubunit bdpfMcsubunit)
        {
            _context.BdpfMcsubunits.Add(bdpfMcsubunit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfMcsubunit", new { id = bdpfMcsubunit.SubId }, bdpfMcsubunit);
        }

        // DELETE: api/BIMcsubunits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfMcsubunit(int id)
        {
            var bdpfMcsubunit = await _context.BdpfMcsubunits.FindAsync(id);
            if (bdpfMcsubunit == null)
            {
                return NotFound();
            }

            _context.BdpfMcsubunits.Remove(bdpfMcsubunit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfMcsubunitExists(int id)
        {
            return _context.BdpfMcsubunits.Any(e => e.SubId == id);
        }
    }
}
