using Evis.VisitorManagement.Data.Contract;
using Evis.VisitorManagement.DataProject.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Data.Context
{

    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        readonly UserManager<ApplicationUser> m_userManager;
        readonly VMSDbContext m_dbContext;

        public UserRepository(System.Data.Entity.DbContext dbContext)
            : base()
        {
            m_dbContext = (m_dbContext ?? (VMSDbContext)dbContext);

            m_userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new VMSDbContext()));
            m_userManager.UserValidator = new UserValidator<ApplicationUser>(m_userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };
        }

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await m_userManager.FindAsync(userName, password);
        }
    }
}
