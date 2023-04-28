using BDELog.Models;
using BDELog.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BDELog.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Auth_Context _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, Auth_Context context)
        {
            _userManager = userManager;
             _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("CheckUserExist");
            
        }

        public async Task<IActionResult> CheckUserExist()
            {
            //string asd = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //asd = asd.Split('\\')[1];
            //var username = Regex.Replace("domain\\user", ".*\\\\(.*)", "$1", RegexOptions.None);
            var sss = User.Identity.Name;
            var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
           
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AccountReg model)
        {
            var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var password = "@Thispassword7";

            //string domainUser = Regex.Replace("domain\\user", ".*\\\\(.*)", "$1", RegexOptions.None);

            //username = "dummydomain\\istvan.szabo2";
            string domainUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
            var sss = User.Identity.Name;
            model.FullUserName = username;
            model.UserName = domainUser;
            model.Email = domainUser + "@bridgestone.eu";
            model.Password = password;



            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    FullUser= model.FullUserName,
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLogin model)
        {
            var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var password = "@Thispassword7";

            string domainUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];

            model.FullUserName = username;
            model.UserName = domainUser;
            //model.Email = domainUser + "@bridgestone.eu";
            model.Password = password;
            model.RememberMe = true;

            if(ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            }

            return RedirectToAction("Index", "Home");
        }
    }




}

