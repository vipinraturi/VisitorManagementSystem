using Evis.VisitorManagement.DataProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Business.Contract
{
    public interface ICategoryBO
    {
        void AddCategory(Category category);
    }
}
