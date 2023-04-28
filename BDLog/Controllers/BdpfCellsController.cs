using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;
using Microsoft.AspNetCore.Authorization;

namespace BDELog.Controllers
{
    [Authorize]
    public class BdpfCellsController : Controller
    {
        private readonly BD_Context _context;

        public BdpfCellsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfCells
        public async Task<IActionResult> Index()
        {
            var bD_Context = _context.BdpfCells.Include(b => b.CellAreaNavigation);
            return View(await bD_Context.ToListAsync());
        }

        // GET: BdpfCells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfCell = await _context.BdpfCells
                .Include(b => b.CellAreaNavigation)
                .FirstOrDefaultAsync(m => m.CellId == id);
            if (bdpfCell == null)
            {
                return NotFound();
            }

            return View(bdpfCell);
        }

        [Authorize(Roles = "Admin")]
        // GET: BdpfCells/Create
        public IActionResult Create()
        {
            ViewData["CellArea"] = new SelectList(_context.BdpfAreas, "AreaId", "AreaName");
            return View();
        }

        // POST: BdpfCells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CellName,CellNo,CellId,CellArea")] BdpfCell bdpfCell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfCell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CellArea"] = new SelectList(_context.BdpfAreas, "AreaId", "AreaName", bdpfCell.CellArea);
            return View(bdpfCell);
        }

        [Authorize(Roles = "Admin")]
        // GET: BdpfCells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfCell = await _context.BdpfCells.FindAsync(id);
            if (bdpfCell == null)
            {
                return NotFound();
            }
            ViewData["CellArea"] = new SelectList(_context.BdpfAreas, "AreaId", "AreaName", bdpfCell.CellArea);
            return View(bdpfCell);
        }

        // POST: BdpfCells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CellName,CellNo,CellId,CellArea")] BdpfCell bdpfCell)
        {
            if (id != bdpfCell.CellId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfCell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfCellExists(bdpfCell.CellId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CellArea"] = new SelectList(_context.BdpfAreas, "AreaId", "AreaName", bdpfCell.CellArea);
            return View(bdpfCell);
        }

        // GET: BdpfCells/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfCell = await _context.BdpfCells
                .Include(b => b.CellAreaNavigation)
                .FirstOrDefaultAsync(m => m.CellId == id);
            if (bdpfCell == null)
            {
                return NotFound();
            }

            return View(bdpfCell);
        }

        // POST: BdpfCells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfCell = await _context.BdpfCells.FindAsync(id);
            _context.BdpfCells.Remove(bdpfCell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfCellExists(int id)
        {
            return _context.BdpfCells.Any(e => e.CellId == id);
        }
    }
}
