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

        public int? SalutationId { get; set; }
        [ForeignKey("SalutationId")]

        public virtual Salutation Salutation { get; set; }
    }
}
