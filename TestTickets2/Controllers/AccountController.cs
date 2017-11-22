using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TestTickets2.Data;
using TestTickets2.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTickets2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null)
        {
            if(ReturnUrl != null && Url.IsLocalUrl(ReturnUrl))
            {
                this.ViewData["ReturnUrl"] = ReturnUrl;
            }
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model) //form pushed data directly into instance of model, can now pull it from there again
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if(result.Succeeded)
                {
                    if(model.ReturnUrl != null && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(DefaultURL.Dashboard[1], DefaultURL.Dashboard[0]);
                    }
                }
                else
                {
                    throw new Exception("Invalid login attempt");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "TicketListView");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
