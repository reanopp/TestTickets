namespace TestTickets2.Models
{
    public class TicketModel
    {
        //define table columns here
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}
