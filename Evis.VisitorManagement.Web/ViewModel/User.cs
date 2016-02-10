using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
