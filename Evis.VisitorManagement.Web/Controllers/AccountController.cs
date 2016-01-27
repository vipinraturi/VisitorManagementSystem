using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Evis.VisitorManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountBO m_accountBO;

        public AccountController(IAccountBO accountBO)
        {
            m_accountBO = accountBO;
        }
        //
        // GET: /Account/
        public ActionResult Index()
        {
            string test = System.Guid.NewGuid().ToString();
            var passwordHash = new Microsoft.AspNet.Identity.PasswordHasher();
            var hashedPassword = passwordHash.HashPassword("Evis@123");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await m_accountBO.FindAsync(loginViewModel.UserName, loginViewModel.Password);

            return View("Login");
        }

       
        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult NewUsers()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

    }
}