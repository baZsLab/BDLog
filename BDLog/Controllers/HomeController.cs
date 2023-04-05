using BDELog.Contexts;
using BDELog.Models;
using BDELog.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BDELog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BD_Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(BD_Context context, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public JsonResult GetAreaDrp()
        {
            var area_result = _context.BdpfAreas.ToList();
            return new JsonResult(area_result);
        }
        public JsonResult GetCellDrp(int id)
        {
            var mcRepository = new qryCellsRepo(_context);
            var cells = mcRepository.GetQryCells();
            var cell_result_part = cells.Where(e => e.CellArea == id);
            var cell_result = cell_result_part.OrderBy(ce => ce.CellName).ToList();
            return new JsonResult(cell_result);
        }
        public JsonResult GetMcDrp(int id)
        {
            var mcs_result_part = _context.BdpfMcs.Where(e => e.McCell == id);
            var mcs_result = mcs_result_part.OrderBy(e => e.McName).ToList();
            return new JsonResult(mcs_result);
        }
        public JsonResult GetMcUnitDrp(int id)
        {
            var units_result_part = _context.BdpfMcunits.Where(e => e.UnitMc == id);
            var units_result = units_result_part.OrderBy(e => e.UnitName).ToList();
            return new JsonResult(units_result);
        }

        public JsonResult GetMcSubDrp(int id)
        {
            var subs_result_part = _context.BdpfMcsubunits.Where(e => e.SubMcunit == id);
            var sub_result = subs_result_part.OrderBy(e => e.SubName).ToList();
            return new JsonResult(sub_result);
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return Redirect("Account/Index");
            }
                
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
