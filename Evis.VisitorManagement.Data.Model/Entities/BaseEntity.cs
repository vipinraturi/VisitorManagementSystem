using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model.Entities
{
    public class BaseEntity<TEntity>
    {
        public TEntity Id { get; set; }
    }
}
