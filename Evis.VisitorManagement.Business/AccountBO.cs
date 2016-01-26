using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Data;
using Evis.VisitorManagement.DataProject.Model;
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

        public async Task<ApplicationUser> FindAsync(string userName, string password)
        {
            return await m_unitOfWork.UserRepository.FindAsync(userName, password);
        }
    }
}
