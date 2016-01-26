using Evis.VisitorManagement.DataProject.Model.Entities;
/********************************************************************************
 * File Name    : Category.cs
 * Company Name : EVIS
 * Author       : Shambhoo Kumar
 * Created On   : 01/23/2016
 * Description  : Category Model
 *******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.DataProject.Model
{
    public class Category : BaseEntity<int>
    {
        public Category()
        {
        }

        public String Name { get; set; }
        public bool IsActive { get; set; }

        public int TestColumn { get; set; }

    }
}
