using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model.Entities;

namespace Evis.VisitorManagement.Business
{
    public class VisitorBO : Repository<Visitor>, IVisitorBO
    {
        public VisitorBO() { }
    }
}
