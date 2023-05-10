using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDELog.Contexts;
using BDELog.Models;
using BDELog.Repo;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BDELog.Controllers
{
    [Authorize]
    public class qryMcSubUnitsController : Controller
    {
        private readonly BD_Context _context;

        public qryMcSubUnitsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfMcsubunits
        public async Task<IActionResult> Index()
        {
            var subRepository = new qryMcSubUnitsRepo(_context);
            var subs = subRepository.GetQryMcSubUnits();
            return View(subs);
        }

        // GET: BdpfMcsubunits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcsubunit = await _context.BdpfMcsubunits
                .Include(b => b.SubMcunitNavigation)
                .FirstOrDefaultAsync(m => m.SubId == id);
            if (bdpfMcsubunit == null)
            {
                return NotFound();
            }

            return View(bdpfMcsubunit);
        }

        // GET: BdpfMcsubunits/Create
        [Authorize(Roles = "Maintenance Developer")]
        public IActionResult Create()
        {
            ViewData["SubMcunit"] = new SelectList(_context.BdpfMcunits, "UnitId", "UnitName");
            return View();
        }

        // POST: BdpfMcsubunits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubId,SubName,SubSap,SubMcunit")] BdpfMcsubunit bdpfMcsubunit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfMcsubunit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubMcunit"] = new SelectList(_context.BdpfMcunits, "UnitId", "UnitName", bdpfMcsubunit.SubMcunit);
            return View(bdpfMcsubunit);
        }

        // GET: BdpfMcsubunits/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcsubunit = await _context.BdpfMcsubunits.FindAsync(id);
            if (bdpfMcsubunit == null)
            {
                return NotFound();
            }
            ViewData["SubMcunit"] = new SelectList(_context.BdpfMcunits, "UnitId", "UnitName", bdpfMcsubunit.SubMcunit);
            return View(bdpfMcsubunit);
        }

        // POST: BdpfMcsubunits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubId,SubName,SubSap,SubMcunit")] BdpfMcsubunit bdpfMcsubunit)
        {
            if (id != bdpfMcsubunit.SubId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfMcsubunit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfMcsubunitExists(bdpfMcsubunit.SubId))
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
            ViewData["SubMcunit"] = new SelectList(_context.BdpfMcunits, "UnitId", "UnitName", bdpfMcsubunit.SubMcunit);
            return View(bdpfMcsubunit);
        }

        // GET: BdpfMcsubunits/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMcsubunit = await _context.BdpfMcsubunits
                .Include(b => b.SubMcunitNavigation)
                .FirstOrDefaultAsync(m => m.SubId == id);
            if (bdpfMcsubunit == null)
            {
                return NotFound();
            }

            return View(bdpfMcsubunit);
        }

        // POST: BdpfMcsubunits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfMcsubunit = await _context.BdpfMcsubunits.FindAsync(id);
            _context.BdpfMcsubunits.Remove(bdpfMcsubunit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfMcsubunitExists(int id)
        {
            return _context.BdpfMcsubunits.Any(e => e.SubId == id);
        }
    }
}
