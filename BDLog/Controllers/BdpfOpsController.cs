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
    public class BdpfOpsController : Controller
    {
        private readonly BD_Context _context;

        public BdpfOpsController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfOps
        public async Task<IActionResult> Index()
        {
            return View(await _context.BdpfOps.ToListAsync());
        }

        // GET: BdpfOps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfOp = await _context.BdpfOps
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (bdpfOp == null)
            {
                return NotFound();
            }

            return View(bdpfOp);
        }

        // GET: BdpfOps/Create
        [Authorize(Roles = "Maintenance Lead")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BdpfOps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpId,OpName")] BdpfOp bdpfOp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfOp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bdpfOp);
        }

        // GET: BdpfOps/Edit/5
        [Authorize(Roles = "Maintenance Lead")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfOp = await _context.BdpfOps.FindAsync(id);
            if (bdpfOp == null)
            {
                return NotFound();
            }
            return View(bdpfOp);
        }

        // POST: BdpfOps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpId,OpName")] BdpfOp bdpfOp)
        {
            if (id != bdpfOp.OpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfOp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfOpExists(bdpfOp.OpId))
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
            return View(bdpfOp);
        }

        // GET: BdpfOps/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfOp = await _context.BdpfOps
                .FirstOrDefaultAsync(m => m.OpId == id);
            if (bdpfOp == null)
            {
                return NotFound();
            }

            return View(bdpfOp);
        }

        // POST: BdpfOps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfOp = await _context.BdpfOps.FindAsync(id);
            _context.BdpfOps.Remove(bdpfOp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfOpExists(int id)
        {
            return _context.BdpfOps.Any(e => e.OpId == id);
        }
    }
}
