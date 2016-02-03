using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class Company : BaseEntity<int>
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Description { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string Fax { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
