using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class Visitor:BaseEntity<long>
    {
        public Visitor()
        {
            this.VisitorDetails = new HashSet<VisitorDetails>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public byte Image { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public virtual ICollection<VisitorDetails> VisitorDetails { get; set; } 
        
    }
}
