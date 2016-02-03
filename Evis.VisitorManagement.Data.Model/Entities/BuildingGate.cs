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
    public class BuildingGate : BaseEntity<int>
    {
        [Required]
        public string GateNumber { get; set; }

        public string Description  { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]

        public virtual Building Building { get; set; }

    }
}
