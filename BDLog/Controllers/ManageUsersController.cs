using BDELog.Contexts;
using BDELog.Models;
using BDELog.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BDELog.Controllers
{
    public class ManageUsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly BD_Context _context;

        public ManageUsersController(UserManager<ApplicationUser> userManager,  BD_Context context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult UsersWithRoles()
        {
            //var usrRolesRepository = new qryUserInRoleRepo(_context);
            //var usersWithRoles = usrRolesRepository.GetQryUserInRole().ToList();

            var users = _userManager.Users.Select(c => new qryUserInRole()
            {
                UserId= c.Id,
                UserName = c.UserName,
                RoleName = string.Join(", ", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();

            return View(users);
        }
        public IActionResult Create()
        {
            ViewData["Roleid"] = new SelectList(_context.BRoles, "Id", "Name");
            ViewData["Userid"] = new SelectList(_context.BUsers, "Id", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,Roleid")] BUserrole bUserrole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bUserrole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UsersWithRoles));
            }
            ViewData["Roleid"] = new SelectList(_context.BRoles, "Id", "Id", bUserrole.Roleid);
            ViewData["Userid"] = new SelectList(_context.BUsers, "Id", "Id", bUserrole.Userid);
            return View(bUserrole);
        }
    }
}
