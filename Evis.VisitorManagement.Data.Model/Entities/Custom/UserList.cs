using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities.Custom
{
    public class UserList
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }

        public string Gender { get; set; }

        public string RoleId { get; set; }

        public string Role { get; set; }
    }
}
