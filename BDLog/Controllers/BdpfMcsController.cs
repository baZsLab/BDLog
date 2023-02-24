using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDPFMA.Contexts;
using BDPFMA.Models;

namespace BDPFMA.Controllers
{
    public class BdpfMcsController : Controller
    {
        private readonly BD_Context _context;

        public BdpfMcsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfMcs
        public async Task<IActionResult> Index()
        {
            var bD_Context = _context.BdpfMcs.Include(b => b.McCellNavigation);
            return View(await bD_Context.ToListAsync());
        }

        // GET: BdpfMcs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMc = await _context.BdpfMcs
                .Include(b => b.McCellNavigation)
                .FirstOrDefaultAsync(m => m.McId == id);
            if (bdpfMc == null)
            {
                return NotFound();
            }

            return View(bdpfMc);
        }

        // GET: BdpfMcs/Create
        public IActionResult Create()
        {
            ViewData["McCell"] = new SelectList(_context.BdpfCells, "CellId", "CellName");
            return View();
        }

        // POST: BdpfMcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("McId,McName,McCell")] BdpfMc bdpfMc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfMc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["McCell"] = new SelectList(_context.BdpfCells, "CellId", "CellName", bdpfMc.McCell);
            return View(bdpfMc);
        }

        // GET: BdpfMcs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMc = await _context.BdpfMcs.FindAsync(id);
            if (bdpfMc == null)
            {
                return NotFound();
            }
            ViewData["McCell"] = new SelectList(_context.BdpfCells, "CellId", "CellName", bdpfMc.McCell);
            return View(bdpfMc);
        }

        // POST: BdpfMcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("McId,McName,McCell")] BdpfMc bdpfMc)
        {
            if (id != bdpfMc.McId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfMc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfMcExists(bdpfMc.McId))
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
            ViewData["McCell"] = new SelectList(_context.BdpfCells, "CellId", "CellName", bdpfMc.McCell);
            return View(bdpfMc);
        }

        // GET: BdpfMcs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMc = await _context.BdpfMcs
                .Include(b => b.McCellNavigation)
                .FirstOrDefaultAsync(m => m.McId == id);
            if (bdpfMc == null)
            {
                return NotFound();
            }

            return View(bdpfMc);
        }

        // POST: BdpfMcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var bdpfMc = await _context.BdpfMcs.FindAsync(id);
            _context.BdpfMcs.Remove(bdpfMc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfMcExists(decimal id)
        {
            return _context.BdpfMcs.Any(e => e.McId == id);
        }
    }
}
