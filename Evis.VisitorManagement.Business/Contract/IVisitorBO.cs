using Evis.VisitorManagement.DataProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.Data.Contract;

namespace Evis.VisitorManagement.Business.Contract
{
    public interface IVisitorBO : IRepository<Visitor>
    {

    }
}
