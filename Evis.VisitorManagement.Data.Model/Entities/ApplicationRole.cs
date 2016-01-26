using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public sealed class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        { }
        public ApplicationRole(string name, string description)
            : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}
