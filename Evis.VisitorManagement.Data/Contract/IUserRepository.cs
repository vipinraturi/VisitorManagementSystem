using Evis.VisitorManagement.DataProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Data.Contract
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindAsync(string userName, string password);
    }
}
