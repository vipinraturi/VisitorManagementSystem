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

        Task<ApplicationUser> FindAsync(string userId);

        Task CreateAsync(ApplicationUser applicationUser, string password);

        Task UpdateAsync(ApplicationUser applicationUser);

        Task DeleteAsync(string userId);
        Task DeleteAsync(ApplicationUser applicationUser);
    }
}
