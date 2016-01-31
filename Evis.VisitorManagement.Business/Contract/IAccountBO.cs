using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Business.Contract
{
    public interface IAccountBO
    {
        Task<ApplicationUser> FindAsync(string userName, string password);

        Task<ApplicationUser> FindAsync(string userId);

        Task CreateAsync(ApplicationUser applicationUser, string password);

        Task UpdateAsync(ApplicationUser applicationUser);

        Task DeleteAsync(string userId);
        Task DeleteAsync(ApplicationUser applicationUser);

        

        IQueryable<ApplicationRole> GetAllRoles();

        IQueryable<Gender> GetAllGenders();

        Task<IEnumerable<UserList>> GetAllUsers();
        
    }
}
