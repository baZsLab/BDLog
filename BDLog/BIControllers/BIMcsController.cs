using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;
using Microsoft.AspNetCore.Http.Features;

namespace BDELog.BIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BIMcsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIMcsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIMcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfMc>>> GetBdpfMcs(int? mccell)
        {
            var response = await _context.BdpfMcs.ToListAsync();
            var items = response;
            if (mccell.HasValue)
            {
                var item = items.Where(i => i.McCell == mccell.Value);
                return item.ToList();
            }
    
  
            return await _context.BdpfMcs.ToListAsync();
        }

        // GET: api/BIMcs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfMc>> GetBdpfMc(int id)
        {
            var bdpfMc = await _context.BdpfMcs.FindAsync(id);

            if (bdpfMc == null)
            {
                return NotFound();
            }

            return bdpfMc;
        }

        // PUT: api/BIMcs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfMc(int id, BdpfMc bdpfMc)
        {
            if (id != bdpfMc.McId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfMc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfMcExists(id))
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

        // POST: api/BIMcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfMc>> PostBdpfMc(BdpfMc bdpfMc)
        {
            _context.BdpfMcs.Add(bdpfMc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfMc", new { id = bdpfMc.McId }, bdpfMc);
        }

        // DELETE: api/BIMcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfMc(int id)
        {
            var bdpfMc = await _context.BdpfMcs.FindAsync(id);
            if (bdpfMc == null)
            {
                return NotFound();
            }

            _context.BdpfMcs.Remove(bdpfMc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfMcExists(int id)
        {
            return _context.BdpfMcs.Any(e => e.McId == id);
        }
    }
}
