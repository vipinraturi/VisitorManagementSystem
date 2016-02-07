using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class VisitorDetails:BaseEntity<long>
    {
        public VisitorDetails()
        {

        }
        
        [Required]
        public long VisitorId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public string ToMeet { get; set; }
        public string PurposeOfVisit { get; set; }
        public string IdentityNo { get; set; }

        [Required]
        public int CardTypeId { get; set; }
        [ForeignKey("CardTypeId")]
        public virtual CardType CardType { get; set; }
       
        [Required]
        public int RelationId { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("VisitorId")]
        public virtual Visitor Visitor { get; set; }

        [ForeignKey("RelationId")]
        public virtual Relation Relation { get; set; }
    }
}
