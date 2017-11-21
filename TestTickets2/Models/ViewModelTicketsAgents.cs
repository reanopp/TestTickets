namespace TestTickets2.Models
{
    public class ViewModelTicketsAgents
    {
        //this model is used because we are joining 2 db tables (agents & tickets). below we are defining both:
        public AgentModel AgentModel { get; set; }
        public TicketModel TicketModel { get; set; }


        //here we do a logical check to see if AgentModel.Role matches a certain string. This is applicable per ROW returned. Used in the view.
        //Example: in the controller we get a list of rows of all tickets and innerjoin it on agent name. Then for each of those rows, we also have an "escalated" flag.
        public string Escalated
        {
            get
            {
                if (AgentModel.Role == "Admin")
                {
                    return "Yes";
                }
                else { return "No"; }
            }
        }
    }
}
