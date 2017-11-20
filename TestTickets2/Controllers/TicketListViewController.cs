using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
            var tickets = from t in _context.TicketList
                         select t;
            return View(tickets.ToList());
        }

        public IActionResult Agents()
        {
            var agents = from a in _context.AgentList
                          select a;
            return View(agents.ToList());
        }

        public IActionResult TicketsAgents()
        {
            //we are using 2 tables(models) with a join, and throwing it into a new view model which contains definitions for the original models inside it
            var tickets = from t in _context.TicketList
                          join a in _context.AgentList on t.Owner equals a.ID.ToString()
                          select new ViewModelTicketsAgents{ TicketModel = t, AgentModel = a };

            return View(tickets.ToList());
        }
    }
}
