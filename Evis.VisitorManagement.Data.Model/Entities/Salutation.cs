using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class Salutation : BaseEntity<int>
    {
        public Salutation() { }

        #region Properties
        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
        #endregion
    }
}
