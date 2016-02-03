using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities.Custom
{
    public class BuildingName : BaseEntity<int>
    {
        BuildingName() { }

        [Required]
        public int Name { get; set; }

        [Required]
        public int BuildingLocationId { get; set; }
        [ForeignKey("BuildingLocationId")]

        public virtual BuildingLocation BuildingLocation { get; set; }
    }
}
