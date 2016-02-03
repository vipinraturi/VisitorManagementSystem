using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class Building : BaseEntity<int>
    {
        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public int BuildingNameId { get; set; }
        [ForeignKey("BuildingNameId")]

        public virtual BuildingName BuildingName { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public virtual Company Company { get; set; }
    }
}
