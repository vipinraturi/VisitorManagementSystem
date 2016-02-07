using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class Relation:BaseEntity<int>
    {
        //public int Id { get; set; }

        public Relation()
        {
            this.VisitorDetails = new HashSet<VisitorDetails>();
        }
        [Required]
        public string Name { get; set; }
        public string RelationDesc { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<VisitorDetails> VisitorDetails { get; set; } 
    }
}
