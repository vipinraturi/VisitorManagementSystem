using Evis.VisitorManagement.DataProject.Model.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]

        public virtual Gender Gender { get; set; }
    }
}
