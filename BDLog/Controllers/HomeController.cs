using BDPFMA.Contexts;
using BDPFMA.Models;
using BDPFMA.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BDPFMA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BD_Context _context;
        private readonly Auth_Context _authcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(BD_Context context, ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager, Auth_Context authcontext)
        {
            _logger = logger;
            _context = context;

            _authcontext = authcontext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            
            
            var user = _authcontext.BdpfUsernames.SingleOrDefault(u => u.UserName == "testuser02");
            
            if (user == null)
            {
                user = new BdpfUsername { UserName = "testuser02", UserRole = 1 };
                _authcontext.BdpfUsernames.Add(user);
                _authcontext.SaveChanges();

            }

            return Redirect("/Home/Index");
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
        public IActionResult Index()
        {
            return View();
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
