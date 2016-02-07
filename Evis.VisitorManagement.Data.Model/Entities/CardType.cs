using System;
using System.ComponentModel.DataAnnotations;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class CardType:BaseEntity<int>
    {
        public CardType() { }

        [Required]
        public string Name { get; set; }
        public string CardDesc { get; set; }
        public bool IsActive { get; set; }
    }
}
