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
    public class BdpfMaintsController : Controller
    {
        private readonly BD_Context _context;

        public BdpfMaintsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfMaints
        public async Task<IActionResult> Index()
        {
            return View(await _context.BdpfMaints.ToListAsync());
        }

        // GET: BdpfMaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMaint = await _context.BdpfMaints
                .FirstOrDefaultAsync(m => m.MaintId == id);
            if (bdpfMaint == null)
            {
                return NotFound();
            }

            return View(bdpfMaint);
        }

        // GET: BdpfMaints/Create
        [Authorize(Roles = "Maintenance Lead")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BdpfMaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintId,MaintName")] BdpfMaint bdpfMaint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfMaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bdpfMaint);
        }

        // GET: BdpfMaints/Edit/5
        [Authorize(Roles = "Maintenance Lead")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMaint = await _context.BdpfMaints.FindAsync(id);
            if (bdpfMaint == null)
            {
                return NotFound();
            }
            return View(bdpfMaint);
        }

        // POST: BdpfMaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaintId,MaintName")] BdpfMaint bdpfMaint)
        {
            if (id != bdpfMaint.MaintId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfMaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfMaintExists(bdpfMaint.MaintId))
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
            return View(bdpfMaint);
        }

        // GET: BdpfMaints/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfMaint = await _context.BdpfMaints
                .FirstOrDefaultAsync(m => m.MaintId == id);
            if (bdpfMaint == null)
            {
                return NotFound();
            }

            return View(bdpfMaint);
        }

        // POST: BdpfMaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfMaint = await _context.BdpfMaints.FindAsync(id);
            _context.BdpfMaints.Remove(bdpfMaint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfMaintExists(int id)
        {
            return _context.BdpfMaints.Any(e => e.MaintId == id);
        }
    }
}
