using Evis.VisitorManagement.Data.Contract;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.DataProject.Model.Entities.Custom;
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

        public async Task<ApplicationUser> FindAsync(string userId)
        {
            return await m_userManager.FindByIdAsync(userId);
        }

        public async Task CreateAsync(ApplicationUser applicationUser, string password)
        {
            //var systemAdminRole = await GetSystemAdminRole();

            //if (userRole == systemAdminRole.Id)
            //{
            //    throw new ApplicationException("Adding this role is not permitted");
            //}

            // Roles
            //applicationUser.Roles.Add(new IdentityUserRole() { UserId = applicationUser.Id, RoleId = userRole });


            // Defaults for New User Creation
            applicationUser.UserName = applicationUser.Email;
            applicationUser.EmailConfirmed = false;
            applicationUser.PhoneNumberConfirmed = false;
            applicationUser.TwoFactorEnabled = false;
            applicationUser.LockoutEnabled = false;
            applicationUser.AccessFailedCount = 0;

            await m_userManager.CreateAsync(applicationUser, password);
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            await m_userManager.UpdateAsync(applicationUser);
        }

        public async Task DeleteAsync(string userId)
        {
            var applicationUser = await m_userManager.FindByIdAsync(userId);
            await m_userManager.DeleteAsync(applicationUser);
        }
        public async Task DeleteAsync(ApplicationUser applicationUser)
        {
            await m_userManager.DeleteAsync(applicationUser);
        }

        public async Task<IEnumerable<UserList>> GetAll()
        {
            StringBuilder queryBuilder = new StringBuilder(@"SELECT DISTINCT A.Id, A.FirstName, A.LastName, A.Email, A.PhoneNumber, 
                                                                             A.GenderId, D.Name AS Gender, B.RoleId, C.Name As Role
                                                            FROM ASPNETUSERS A
                                                            LEFT JOIN AspNetUserRoles B
	                                                            ON A.Id = B.UserId
                                                            LEFT JOIN AspNetRoles C
	                                                            ON C.Id = B.RoleId
                                                            LEFT JOIN Genders D
	                                                            ON D.Id = A.GenderId
                                                            WHERE A.Email != 'systemadmin@evisuae.com'");

            return await m_dbContext.Database.SqlQuery<UserList>(queryBuilder.ToString()).ToListAsync();
        }
    }
}
