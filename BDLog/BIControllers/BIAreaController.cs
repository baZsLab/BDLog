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
    public class BIAreaController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIAreaController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIArea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfArea>>> GetBdpfAreas()
        {
            return await _context.BdpfAreas.ToListAsync();
        }

        // GET: api/BIArea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfArea>> GetBdpfArea(int id)
        {
            var bdpfArea = await _context.BdpfAreas.FindAsync(id);

            if (bdpfArea == null)
            {
                return NotFound();
            }

            return bdpfArea;
        }

        // PUT: api/BIArea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfArea(int id, BdpfArea bdpfArea)
        {
            if (id != bdpfArea.AreaId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfAreaExists(id))
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

        // POST: api/BIArea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfArea>> PostBdpfArea(BdpfArea bdpfArea)
        {
            _context.BdpfAreas.Add(bdpfArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfArea", new { id = bdpfArea.AreaId }, bdpfArea);
        }

        // DELETE: api/BIArea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfArea(int id)
        {
            var bdpfArea = await _context.BdpfAreas.FindAsync(id);
            if (bdpfArea == null)
            {
                return NotFound();
            }

            _context.BdpfAreas.Remove(bdpfArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfAreaExists(int id)
        {
            return _context.BdpfAreas.Any(e => e.AreaId == id);
        }
    }
}
