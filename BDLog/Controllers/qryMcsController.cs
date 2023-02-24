using BDPFMA.Contexts;
using BDPFMA.Models;
using BDPFMA.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDPFMA.Controllers
{
    public class qryMcsController : Controller

    {
        private readonly BD_Context _context;

        public qryMcsController(BD_Context context)
        {
            _context = context;
        }




        // GET: HomeController1
        public ActionResult Index()
        {
            var mcRepository = new qryMcsRepo(_context);
            var mcs = mcRepository.GetQryMcs();
            return View(mcs);
        }

        // GET: HomeController1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mcRepository = new qryMcsRepo(_context);
            var mcs = mcRepository.GetQryMcs().FirstOrDefault(m => m.McId == id);
            //var bdpfMc = await _context.BdpfMcs
            //    .Include(b => b.McCellNavigation)

            if (mcs == null)
            {
                return NotFound();
            }

            return View(mcs);
        }


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

        // GET: HomeController1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int idint = new int();
            if (id == null)
            {
                return NotFound();
                
            }
            idint = Convert.ToInt16(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("McId,McName,McCell")] BdpfMc bdpfMc)
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

        // GET: HomeController1/Delete/5
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
