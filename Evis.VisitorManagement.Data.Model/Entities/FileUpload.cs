using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class FileUpload : BaseEntity<int>
    {
        public FileUpload()
        {
        }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string ImageType { get; set; }

        public byte[] ImageContent { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
