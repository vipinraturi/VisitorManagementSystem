using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class ImageUpload : BaseEntity<int>
    {
        public ImageUpload() { }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
