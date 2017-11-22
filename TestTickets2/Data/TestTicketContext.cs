using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TestTickets2.Data;

namespace TestTickets2.Models
{
    public class TestTicketContext : DbContext
    {
        public TestTicketContext(DbContextOptions<TestTicketContext> options)
            : base(options)
        {
        }
        //define tables here. each table must have its own model class:
        public DbSet<TestTickets2.Models.TicketModel> TicketList { get; set; }
        public DbSet<TestTickets2.Models.AgentModel> AgentList { get; set; }
        public DbSet<TestTickets2.Models.UserModel> Users { get; set; }
    }
}
