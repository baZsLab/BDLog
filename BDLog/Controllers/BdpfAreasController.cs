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
    public class BdpfAreasController : Controller
    {
        private readonly BD_Context _context;

        public BdpfAreasController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfAreas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BdpfAreas.ToListAsync());
        }

        // GET: BdpfAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfArea = await _context.BdpfAreas
                .FirstOrDefaultAsync(m => m.AreaId == id);
            if (bdpfArea == null)
            {
                return NotFound();
            }

            return View(bdpfArea);
        }

        // GET: BdpfAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BdpfAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaName,AreaId")] BdpfArea bdpfArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bdpfArea);
        }

        // GET: BdpfAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfArea = await _context.BdpfAreas.FindAsync(id);
            if (bdpfArea == null)
            {
                return NotFound();
            }
            return View(bdpfArea);
        }

        // POST: BdpfAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaName,AreaId")] BdpfArea bdpfArea)
        {
            if (id != bdpfArea.AreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfAreaExists(bdpfArea.AreaId))
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
            return View(bdpfArea);
        }

        // GET: BdpfAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfArea = await _context.BdpfAreas
                .FirstOrDefaultAsync(m => m.AreaId == id);
            if (bdpfArea == null)
            {
                return NotFound();
            }

            return View(bdpfArea);
        }

        // POST: BdpfAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfArea = await _context.BdpfAreas.FindAsync(id);
            _context.BdpfAreas.Remove(bdpfArea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfAreaExists(int id)
        {
            return _context.BdpfAreas.Any(e => e.AreaId == id);
        }
    }
}
