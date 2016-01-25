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
   public class Category
    {
       public Category()
       {
       }

        public int Id { get; set; }
        public String Name { get; set; }
        public bool IsActive { get; set; }

        public int TestColumn { get; set; }

    }
}
