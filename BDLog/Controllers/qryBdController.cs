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

namespace BDELog.Controllers
{
    public class qryBdController : Controller
    {
        private readonly BD_Context _context;

        public qryBdController(BD_Context context)
        {
            _context = context;
        }

        // GET: BdpfBdpfmas
        public async Task<IActionResult> Index()
        {
            var bdRepository = new qryBDRepo(_context);
            var bds = bdRepository.GetBD().OrderByDescending(m=>m.BdCreateddate).ToList();
            return View(bds);
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
                .Include(b => b.BdContmeasNavigation)
                .Include(b => b.BdCreatedbyNavigation)
                .Include(b => b.BdCuzNavigation)
                .Include(b => b.BdDmgNavigation)
                .Include(b => b.BdEmNavigation)
                .Include(b => b.BdFaultNavigation)
                .Include(b => b.BdMaintNavigation)
                .Include(b => b.BdModifiedbyNavigation)
                .Include(b => b.BdOpNavigation)
                .Include(b => b.BdPaperokNavigation)
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
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContName").OrderBy(m=>m.Text);
            ViewData["BdContmeas"] = new SelectList(_context.BdpfContmeas, "ContmeasId", "ContmeasName");
            ViewData["BdCreatedby"] = new SelectList(_context.BUsers, "Id", "Id");
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzName").OrderBy(m => m.Text);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgName").OrderBy(m => m.Text);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName");
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName");
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName").OrderBy(m => m.Text);
            ViewData["BdModifiedby"] = new SelectList(_context.BUsers, "Id", "Id");
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName").OrderBy(m => m.Text);
            ViewData["BdPaperok"] = new SelectList(_context.BdpfPapers, "PaperId", "PaperName");
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName");
            return View();
        }

        // POST: BdpfBdpfmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BdId,BdSub,BdStartdate,BdStopdate,BdFault,BdOp,BdMaint,BdEm,BdM2p,BdDmg,BdCuz,BdCont,BdPart,BdCost,BdFaultdesc,BdContmeas,BdContmeasdesc,BdPaperok,BdAnalysis,BdStandard,BdAddinfo,BdIdaneed,BdCreatedby,BdCreateddate,BdModifiedby,BdModifieddate,BdInactive,BdRepeat")] BdpfBdpfma bdpfBdpfma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bdpfBdpfma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BdCont"] = new SelectList(_context.BdpfContmeasurecodes, "ContId", "ContCode", bdpfBdpfma.BdCont);
            ViewData["BdContmeas"] = new SelectList(_context.BdpfContmeas, "ContmeasId", "ContmeasName", bdpfBdpfma.BdContmeas);
            ViewData["BdCreatedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdCreatedby);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdModifiedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdModifiedby);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdPaperok"] = new SelectList(_context.BdpfPapers, "PaperId", "PaperName", bdpfBdpfma.BdPaperok);
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
            ViewData["BdContmeas"] = new SelectList(_context.BdpfContmeas, "ContmeasId", "ContmeasName", bdpfBdpfma.BdContmeas);
            ViewData["BdCreatedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdCreatedby);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdModifiedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdModifiedby);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdPaperok"] = new SelectList(_context.BdpfPapers, "PaperId", "PaperName", bdpfBdpfma.BdPaperok);
            ViewData["BdSub"] = new SelectList(_context.BdpfMcsubunits, "SubId", "SubName", bdpfBdpfma.BdSub);
            return View(bdpfBdpfma);
        }

        // POST: BdpfBdpfmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BdId,BdSub,BdStartdate,BdStopdate,BdFault,BdOp,BdMaint,BdEm,BdM2p,BdDmg,BdCuz,BdCont,BdPart,BdCost,BdFaultdesc,BdContmeas,BdContmeasdesc,BdPaperok,BdAnalysis,BdStandard,BdAddinfo,BdIdaneed,BdCreatedby,BdCreateddate,BdModifiedby,BdModifieddate,BdInactive,BdRepeat")] BdpfBdpfma bdpfBdpfma)
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
            ViewData["BdContmeas"] = new SelectList(_context.BdpfContmeas, "ContmeasId", "ContmeasName", bdpfBdpfma.BdContmeas);
            ViewData["BdCreatedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdCreatedby);
            ViewData["BdCuz"] = new SelectList(_context.BdpfCausecodes, "CuzId", "CuzCode", bdpfBdpfma.BdCuz);
            ViewData["BdDmg"] = new SelectList(_context.BdpfDamagecodes, "DmgId", "DmgCode", bdpfBdpfma.BdDmg);
            ViewData["BdEm"] = new SelectList(_context.BdpfEms, "BdpfId", "BdpfName", bdpfBdpfma.BdEm);
            ViewData["BdFault"] = new SelectList(_context.BdpfFaults, "FaultId", "FaultName", bdpfBdpfma.BdFault);
            ViewData["BdMaint"] = new SelectList(_context.BdpfMaints, "MaintId", "MaintName", bdpfBdpfma.BdMaint);
            ViewData["BdModifiedby"] = new SelectList(_context.BUsers, "Id", "Id", bdpfBdpfma.BdModifiedby);
            ViewData["BdOp"] = new SelectList(_context.BdpfOps, "OpId", "OpName", bdpfBdpfma.BdOp);
            ViewData["BdPaperok"] = new SelectList(_context.BdpfPapers, "PaperId", "PaperName", bdpfBdpfma.BdPaperok);
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
                .Include(b => b.BdContmeasNavigation)
                .Include(b => b.BdCreatedbyNavigation)
                .Include(b => b.BdCuzNavigation)
                .Include(b => b.BdDmgNavigation)
                .Include(b => b.BdEmNavigation)
                .Include(b => b.BdFaultNavigation)
                .Include(b => b.BdMaintNavigation)
                .Include(b => b.BdModifiedbyNavigation)
                .Include(b => b.BdOpNavigation)
                .Include(b => b.BdPaperokNavigation)
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
