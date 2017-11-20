using Microsoft.EntityFrameworkCore;

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
    }
}
