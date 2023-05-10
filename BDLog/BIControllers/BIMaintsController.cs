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
    public class BIMaintsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BIMaintsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BIMaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfMaint>>> GetBdpfMaints()
        {
            return await _context.BdpfMaints.ToListAsync();
        }

        // GET: api/BIMaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfMaint>> GetBdpfMaint(int id)
        {
            var bdpfMaint = await _context.BdpfMaints.FindAsync(id);

            if (bdpfMaint == null)
            {
                return NotFound();
            }

            return bdpfMaint;
        }

        // PUT: api/BIMaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfMaint(int id, BdpfMaint bdpfMaint)
        {
            if (id != bdpfMaint.MaintId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfMaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfMaintExists(id))
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

        // POST: api/BIMaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfMaint>> PostBdpfMaint(BdpfMaint bdpfMaint)
        {
            _context.BdpfMaints.Add(bdpfMaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfMaint", new { id = bdpfMaint.MaintId }, bdpfMaint);
        }

        // DELETE: api/BIMaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfMaint(int id)
        {
            var bdpfMaint = await _context.BdpfMaints.FindAsync(id);
            if (bdpfMaint == null)
            {
                return NotFound();
            }

            _context.BdpfMaints.Remove(bdpfMaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfMaintExists(int id)
        {
            return _context.BdpfMaints.Any(e => e.MaintId == id);
        }
    }
}
