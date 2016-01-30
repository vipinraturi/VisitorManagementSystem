using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evis.VisitorManagement.Business
{
    public class AccountBO : IAccountBO
    {
        private readonly IUnitOfWork m_unitOfWork;

        public AccountBO(IUnitOfWork unitOfWork)
        {
            m_unitOfWork = unitOfWork;
        }

        public AccountBO() //IUnitOfWork unitOfWork)
        {
            m_unitOfWork = new UnitOfWork();
        }
        

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await m_unitOfWork.UserRepository.FindAsync(userName, password);
        }

        public async Task<ApplicationUser> FindAsync(string userId)
        {
            return await m_unitOfWork.UserRepository.FindAsync(userId);
        }

        public async Task CreateAsync(ApplicationUser applicationUser, string password)
        {
            string passwordHashed = GetTemporaryPassword();
            await m_unitOfWork.UserRepository.CreateAsync(applicationUser, passwordHashed);
            m_unitOfWork.Commit();
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            var existingUserRecord = await m_unitOfWork.UserRepository.FindAsync(applicationUser.Id);
            existingUserRecord.FirstName = applicationUser.FirstName;
            existingUserRecord.LastName = applicationUser.LastName;
            existingUserRecord.PhoneNumber = applicationUser.PhoneNumber;
            await m_unitOfWork.UserRepository.UpdateAsync(existingUserRecord);
            
        }

        private string GetTemporaryPassword()
        {
            var passwordHash = new Microsoft.AspNet.Identity.PasswordHasher();
            return passwordHash.HashPassword("Evis@123");
        }

        

        public IQueryable<ApplicationRole> GetAllRoles()
        {
            return m_unitOfWork.GetRepository<ApplicationRole>().GetAll();
        }

        public async Task DeleteAsync(string userId)
        {
            await m_unitOfWork.UserRepository.DeleteAsync(userId);
        }
        public async Task DeleteAsync(ApplicationUser applicationUser)
        {
            await m_unitOfWork.UserRepository.DeleteAsync(applicationUser);
        }
    }
}
