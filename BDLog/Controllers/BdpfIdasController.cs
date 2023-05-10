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
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BDELog.Controllers
{
    public class BdpfIdasController : Controller
    {
        private readonly BD_Context _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BdpfIdasController(BD_Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: BdpfIdas
        public async Task<IActionResult> Index()
        {
            var idaRepository = new qryIdaRepo(_context);
            var idas = idaRepository.GetIda().OrderByDescending(m => m.BdStartdate).ToList();
            return View(idas);
        }

        // GET: BdpfIdas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfIdum = await _context.BdpfIda
                .Include(b => b.IdaBdNavigation)
                .FirstOrDefaultAsync(m => m.IdaId == id);
            if (bdpfIdum == null)
            {
                return NotFound();
            }

            return View(bdpfIdum);
        }

        // GET: BdpfIdas/Create
        public IActionResult Create(long? bdnumber)
        {
            if (bdnumber.HasValue)
            {
                var model = new BdpfIdum { IdaBd = bdnumber.Value };
                return View(model);  
            }

            return RedirectToAction("Index");
        }

        // POST: BdpfIdas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("IdaId,IdaBd,IdaStarted,IdaStartdate,IdaEnded,IdaEnddate,IdaNo,IdaDesc")] BdpfIdum bdpfIdum)
        {

            List<qryIDAbyCell> result = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("Authorization", accessToken);

                var request = _httpContextAccessor.HttpContext!.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                client.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = await client.GetAsync("api/biqrybd");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadFromJsonAsync<List<qryIDAbyCell>>();
                }


            }
            int cellNo = result[0].CellNo;
            int cellCount = result[0].IDACount;


            if (ModelState.IsValid)
            {
                _context.Add(bdpfIdum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdaBd"] = new SelectList(_context.BdpfBdpfmas, "BdId", "BdId", bdpfIdum.IdaBd);
            return View(bdpfIdum);
        }

        // GET: BdpfIdas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfIdum = await _context.BdpfIda.FindAsync(id);
            if (bdpfIdum == null)
            {
                return NotFound();
            }
            ViewData["IdaBd"] = new SelectList(_context.BdpfBdpfmas, "BdId", "BdId", bdpfIdum.IdaBd);
            return View(bdpfIdum);
        }

        // POST: BdpfIdas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdaId,IdaBd,IdaStarted,IdaStartdate,IdaEnded,IdaEnddate,IdaNo,IdaDesc")] BdpfIdum bdpfIdum)
        {
            if (id != bdpfIdum.IdaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bdpfIdum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BdpfIdumExists(bdpfIdum.IdaId))
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
            ViewData["IdaBd"] = new SelectList(_context.BdpfBdpfmas, "BdId", "BdId", bdpfIdum.IdaBd);
            return View(bdpfIdum);
        }

        // GET: BdpfIdas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bdpfIdum = await _context.BdpfIda
                .Include(b => b.IdaBdNavigation)
                .FirstOrDefaultAsync(m => m.IdaId == id);
            if (bdpfIdum == null)
            {
                return NotFound();
            }

            return View(bdpfIdum);
        }

        // POST: BdpfIdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bdpfIdum = await _context.BdpfIda.FindAsync(id);
            _context.BdpfIda.Remove(bdpfIdum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BdpfIdumExists(int id)
        {
            return _context.BdpfIda.Any(e => e.IdaId == id);
        }
    }
}
