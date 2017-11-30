using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TestTickets2.Data;
using TestTickets2.Models;
using Microsoft.AspNetCore.Authorization;
using TestTickets2.Services;

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
        public IActionResult Login(string ReturnUrl = null) //the ReturnUrl parameter here is created&populated from the url itself when the login view is called from elsewhere
        {
            if(ReturnUrl != null && Url.IsLocalUrl(ReturnUrl))
            {
                this.ViewData["ReturnUrl"] = ReturnUrl; //we now send the ReturnUrl variable into the view, where it is then pushed into the model instance
            }                                  //the view model instance is created when the view is first loaded. asp-for fields are synced with model instance properties
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model) //form pushed data directly into instance of model, we can now pull data from that instance
        {
            if (ModelState.IsValid)
            {
                if (model.UserName != null && model.Password != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);  //actual login happens on this line
                    if (result.Succeeded)
                    {
                        if (model.ReturnUrl != null && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl); //returnurl is valid, return to the page you came from 
                        }
                        else
                        {
                            return RedirectToAction(DefaultURL.Dashboard[1], DefaultURL.Dashboard[0]);  //returnurl is not valid or does not exist, go to default dashboard
                        }
                    }
                    else
                    {
                        this.ViewData["LoginError"] = "Invalid credentials, please try again:";
                        return View();
                    }
                }
                else
                {
                    this.ViewData["LoginError"] = "Please complete all fields, and try again:";
                    return View();
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();  //actual logout happens in this line
            return RedirectToAction("Index", "TicketListView");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
