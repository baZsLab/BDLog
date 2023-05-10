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
            AccountLogin acclog = new AccountLogin();
            AccountReg accreg = new AccountReg();
            var UserName = User.Identity.Name.Split('\\')[1]; ;
            //var username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
           
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                //return RedirectToAction("Login");
                var username = acclog.UserName;
                var password = "@Thispassword7";

                string domainUser = UserName;

                acclog.FullUserName = username;
                acclog.UserName = domainUser;
                //model.Email = domainUser + "@bridgestone.eu";
                acclog.Password = password;
                acclog.RememberMe = true;

                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(acclog.UserName, acclog.Password, acclog.RememberMe, false);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var username = User.Identity.Name;
                var password = "@Thispassword7";

                string domainUser = UserName;

                accreg.FullUserName = username;
                accreg.UserName = domainUser;
                accreg.Email = domainUser + "@bridgestone.eu";
                accreg.Password = password;

                if (ModelState.IsValid)
                {

                    var newuser = new ApplicationUser
                    {
                        FullUser = accreg.FullUserName,
                        UserName = accreg.UserName,
                        Email = accreg.Email,
                    };

                    var result = await _userManager.CreateAsync(newuser, accreg.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newuser, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }

                }

                return RedirectToAction("Index", "Home");
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

