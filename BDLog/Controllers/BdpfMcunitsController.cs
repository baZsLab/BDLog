using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;

namespace BDELog.Controllers
{
    public class BdpfMcunitsController : Controller
    {
        private readonly BD_Context _context;

        public BdpfMcunitsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfMcunits
        public async Task<IActionResult> Index()
        {
            var bD_Context = _context.BdpfMcunits.Include(b => b.UnitMcNavigation);
            return View(await bD_Context.ToListAsync());
        }

        // GET: BdpfMcunits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcunit = await _context.BdpfMcunits
                .Include(b => b.UnitMcNavigation)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (bdpfMcunit == null)
            {
                return NotFound();
            }

            return View(bdpfMcunit);
        }

        // GET: BdpfMcunits/Create
        public IActionResult Create()
        {
            ViewData["UnitMc"] = new SelectList(_context.BdpfMcs, "McId", "McName");
            return View();
        }

        // POST: BdpfMcunits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitId,UnitName,UnitSap,UnitMc")] BdpfMcunit bdpfMcunit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfMcunit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitMc"] = new SelectList(_context.BdpfMcs, "McId", "McName", bdpfMcunit.UnitMc);
            return View(bdpfMcunit);
        }

        // GET: BdpfMcunits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcunit = await _context.BdpfMcunits.FindAsync(id);
            if (bdpfMcunit == null)
            {
                return NotFound();
            }
            ViewData["UnitMc"] = new SelectList(_context.BdpfMcs, "McId", "McName", bdpfMcunit.UnitMc);
            return View(bdpfMcunit);
        }

        // POST: BdpfMcunits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitId,UnitName,UnitSap,UnitMc")] BdpfMcunit bdpfMcunit)
        {
            if (id != bdpfMcunit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfMcunit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfMcunitExists(bdpfMcunit.UnitId))
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
            ViewData["UnitMc"] = new SelectList(_context.BdpfMcs, "McId", "McName", bdpfMcunit.UnitMc);
            return View(bdpfMcunit);
        }

        // GET: BdpfMcunits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcunit = await _context.BdpfMcunits
                .Include(b => b.UnitMcNavigation)
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (bdpfMcunit == null)
            {
                return NotFound();
            }

            return View(bdpfMcunit);
        }

        // POST: BdpfMcunits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfMcunit = await _context.BdpfMcunits.FindAsync(id);
            _context.BdpfMcunits.Remove(bdpfMcunit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfMcunitExists(int id)
        {
            return _context.BdpfMcunits.Any(e => e.UnitId == id);
        }
    }
}
