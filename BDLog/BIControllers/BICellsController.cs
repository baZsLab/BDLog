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
    public class BICellsController : ControllerBase
    {
        private readonly BD_Context _context;

        public BICellsController(BD_Context context)
        {
            _context = context;
        }

        // GET: api/BICells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BdpfCell>>> GetBdpfCells()
        {
            return await _context.BdpfCells.ToListAsync();
        }

        // GET: api/BICells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BdpfCell>> GetBdpfCell(int id)
        {
            var bdpfCell = await _context.BdpfCells.FindAsync(id);

            if (bdpfCell == null)
            {
                return NotFound();
            }

            return bdpfCell;
        }

        // PUT: api/BICells/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBdpfCell(int id, BdpfCell bdpfCell)
        {
            if (id != bdpfCell.CellId)
            {
                return BadRequest();
            }

            _context.Entry(bdpfCell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BdpfCellExists(id))
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

        // POST: api/BICells
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BdpfCell>> PostBdpfCell(BdpfCell bdpfCell)
        {
            _context.BdpfCells.Add(bdpfCell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBdpfCell", new { id = bdpfCell.CellId }, bdpfCell);
        }

        // DELETE: api/BICells/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBdpfCell(int id)
        {
            var bdpfCell = await _context.BdpfCells.FindAsync(id);
            if (bdpfCell == null)
            {
                return NotFound();
            }

            _context.BdpfCells.Remove(bdpfCell);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BdpfCellExists(int id)
        {
            return _context.BdpfCells.Any(e => e.CellId == id);
        }
    }
}
