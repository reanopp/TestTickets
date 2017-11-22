using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTickets2.Models
{
    public class UserModel
    {
        //define table columns here
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AgentID { get; set; }
    }
}
