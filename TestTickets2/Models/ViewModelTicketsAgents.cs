namespace TestTickets2.Models
{
    public class ViewModelTicketsAgents
    {
        //this model is used because we are joining 2 db tables (agents & tickets). below we are defining both:
        public AgentModel AgentModel { get; set; }
        public TicketModel TicketModel { get; set; }
    }
}
