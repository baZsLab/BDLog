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
    public class BdpfBdpfmasController : Controller
    {
        private readonly BD_Context _context;

        public BdpfBdpfmasController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfBdpfmas
        public async Task<IActionResult> Index()
        {
            var bD_Context = _context.BdpfBdpfmas.Include(b => b.BdContNavigation).Include(b => b.BdCuzNavigation).Include(b => b.BdDmgNavigation).Include(b => b.BdEmNavigation).Include(b => b.BdFaultNavigation).Include(b => b.BdMaintNavigation).Include(b => b.BdOpNavigation).Include(b => b.BdSubNavigation);
            return View(await bD_Context.ToListAsync());
        }

        // GET: BdpfBdpfmas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfBdpfma = await _context.BdpfBdpfmas
                .Include(b => b.BdContNavigation)
                .Include(b => b.BdCuzNavigation)
                .Include(b => b.BdDmgNavigation)
                .Include(b => b.BdEmNavigation)
                .Include(b => b.BdFaultNavigation)
                .Include(b => b.BdMaintNavigation)
                .Include(b => b.BdOpNavigation)
                .Include(b => b.BdSubNavigation)
                .FirstOrDefaultAsync(m => m.BdId == id);
            if (bdpfBdpfma == null)
            {
                return NotFound();
            }

            return View(bdpfBdpfma);
        }

        // GET: BdpfBdpfmas/Create
        public IActionResult Create()
        {
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContCode");
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode");
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode");
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName");
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName");
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName");
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName");
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName");
            return View();
        }

        // POST: BdpfBdpfmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BdId,BdSub,BdStartdate,BdStopdate,BdFault,BdOp,BdMaint,BdEm,BdM2p,BdTime,BdDmg,BdCuz,BdCont,BdPart,BdCost,BdFaultdesc,BdContmeas,BdContmeasdesc,BdPaperok,BdAnalysis,BdStandard,BdAddinfo,BdRepeat,BdIdaneed")] BdpfBdpfma bdpfBdpfma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfBdpfma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContCode", bdpfBdpfma.BdCont);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName", bdpfBdpfma.BdSub);
            return View(bdpfBdpfma);
        }

        // GET: BdpfBdpfmas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfBdpfma = await _context.BdpfBdpfmas.FindAsync(id);
            if (bdpfBdpfma == null)
            {
                return NotFound();
            }
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContCode", bdpfBdpfma.BdCont);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName", bdpfBdpfma.BdSub);
            return View(bdpfBdpfma);
        }

        // POST: BdpfBdpfmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BdId,BdSub,BdStartdate,BdStopdate,BdFault,BdOp,BdMaint,BdEm,BdM2p,BdTime,BdDmg,BdCuz,BdCont,BdPart,BdCost,BdFaultdesc,BdContmeas,BdContmeasdesc,BdPaperok,BdAnalysis,BdStandard,BdAddinfo,BdRepeat,BdIdaneed")] BdpfBdpfma bdpfBdpfma)
        {
            if (id != bdpfBdpfma.BdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfBdpfma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfBdpfmaExists(bdpfBdpfma.BdId))
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
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContCode", bdpfBdpfma.BdCont);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName", bdpfBdpfma.BdSub);
            return View(bdpfBdpfma);
        }

        // GET: BdpfBdpfmas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfBdpfma = await _context.BdpfBdpfmas
                .Include(b => b.BdContNavigation)
                .Include(b => b.BdCuzNavigation)
                .Include(b => b.BdDmgNavigation)
                .Include(b => b.BdEmNavigation)
                .Include(b => b.BdFaultNavigation)
                .Include(b => b.BdMaintNavigation)
                .Include(b => b.BdOpNavigation)
                .Include(b => b.BdSubNavigation)
                .FirstOrDefaultAsync(m => m.BdId == id);
            if (bdpfBdpfma == null)
            {
                return NotFound();
            }

            return View(bdpfBdpfma);
        }

        // POST: BdpfBdpfmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bdpfBdpfma = await _context.BdpfBdpfmas.FindAsync(id);
            _context.BdpfBdpfmas.Remove(bdpfBdpfma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfBdpfmaExists(long id)
        {
            return _context.BdpfBdpfmas.Any(e => e.BdId == id);
        }
    }
}
