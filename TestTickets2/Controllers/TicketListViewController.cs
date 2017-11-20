using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTickets2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTickets2.Models
{
    public class TicketListViewController : Controller
    {
        private readonly TestTicketContext _context;

        public TicketListViewController(TestTicketContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            //return View();

            var tickets = from t in _context.TicketList
                         select t;
            return View(tickets.ToList());

        }

        public IActionResult Agents()
        {

            //return View();

            var agents = from a in _context.AgentList
                          select a;
            return View(agents.ToList());

        }
    }
}
