using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTickets2.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTickets2.Controllers
{
    public class LoginController : Controller
    {

        private readonly TestTicketContext _context;
        //LoginModel loginModel = new LoginModel();

        public LoginController(TestTicketContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            
            return View("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model) //form pushed data directly into instance of model, can now pull it from there again
        {
            string userID = model.VerifyUser(_context);

            if (userID != null)
            {
                HttpContext.Session.SetString("userID", userID);
                HttpContext.Session.SetString("loggedIn", "Yes");
                return View(model);
            }
            else
            {
                HttpContext.Session.Remove("userID");
                HttpContext.Session.Remove("loggedIn");
                HttpContext.Session.Clear();
                return View("Index");
            }
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login2(string userName, string password)
        {
            loginModel.UserName = userName;
            loginModel.Password = password;

            string userID = loginModel.VerifyUser(_context);
            
            if (userID != null)
            {
                HttpContext.Session.SetString("userID", userID);
                HttpContext.Session.SetString("loggedIn", "Yes");
                return View(loginModel);
            }
            else
            {
                return View("Index");
            }

            //return View(loginModel);
        }
        */
    }
}
