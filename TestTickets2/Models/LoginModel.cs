using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace TestTickets2.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string LoginError { get; set; }

        /*
        public string VerifyUser(TestTicketContext _context)
        {
            var userID = (from u in _context.Users2
                          where u.Username.Equals(UserName) &&
                             u.Password.Equals(Password)
                          select u).FirstOrDefault();

            if (userID != null)
            {

                return userID.ID.ToString();
            }
            else
            {
                return null;
            }

        }
        */
    }
}
