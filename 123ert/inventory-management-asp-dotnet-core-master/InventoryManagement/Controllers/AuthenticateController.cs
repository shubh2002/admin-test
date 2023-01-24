using InventoryManagement.Authentication;
using InventoryManagement.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using InventoryManagement.ExtensionMethods;
using System.Collections.Generic;

namespace InventoryManagement.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View(new LoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                throw new ArgumentException();
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                await _signInManager.SignInAsync(user, true, null);
                HttpContext.Session.Set<long>(SessionHelper.UserId, user.Id);
                HttpContext.Session.Set<string>(SessionHelper.UserName, user.FirstName);
                //var abc = _signInManager.IsSignedIn(User);
                var userRoles = await _userManager.GetRolesAsync(user);
                HttpContext.Session.Set<IList<string>>(SessionHelper.Roles, userRoles);
                //if (userRoles.Contains("Admin"))
                return RedirectToAction("Index", "Brand");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
