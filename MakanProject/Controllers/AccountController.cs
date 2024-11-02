using MakanProject.Data;
using MakanProject.Models;
using MakanProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MakanProject.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _SignInManager;
        private RoleManager<IdentityRole> _RoleManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> SignInManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
        }
      
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Mobile,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    return RedirectToAction("Login");
                }
                return View(model);

            }
            return View(model);

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var r = await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (r.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email Or Password");
                return View(model);

            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Add() 
        {
            return View();
        }
      
        public IActionResult AccessDenied()
        {
            return View(); 
        }


    }
}
