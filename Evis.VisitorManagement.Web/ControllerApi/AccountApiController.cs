using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.Web.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class AccountApiController : ApiController
    {
        private IAccountBO m_accountBO = new AccountBO();

        public AccountApiController()
        {
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            m_accountBO = new AccountBO();
            var user = await m_accountBO.FindAsync(loginViewModel.UserName, loginViewModel.Password);

            if (user != null)
            {
                int timeout = FormsAuthentication.Timeout.Minutes; // 2 hours
                
                var ticket = new FormsAuthenticationTicket(loginViewModel.UserName.Trim().ToLower(), loginViewModel.isPasswordSave, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true; // cookie not available in javascript.
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                return NotFound();
            }

            return Ok(user);
        }

        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            ApplicationUser applicationUser
                = new ApplicationUser
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    GenderId = registerViewModel.GenderId,
                    Address = registerViewModel.Address

                };

            applicationUser.Roles.Add(
                new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole
                {
                    UserId = applicationUser.Id,
                    RoleId = registerViewModel.RoleId
                });

            await m_accountBO.CreateAsync(applicationUser, "Evis@123");
            return Ok(applicationUser);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult GetAllRoles()
        {
            var userRoles = m_accountBO.GetAllRoles();
            if (userRoles == null)
            {
                return NotFound();
            }
            return Ok(userRoles);
        }

        public IHttpActionResult GetAllGenders()
        {
            var userRoles = m_accountBO.GetAllGenders();
            if (userRoles == null)
            {
                return NotFound();
            }
            return Ok(userRoles);
        }

        public async Task<IHttpActionResult> GetAllUsers()
        {
            var applicationUsers = await m_accountBO.GetAllUsers();
            if (applicationUsers == null)
            {
                return NotFound();
            }
            return Ok(applicationUsers);
        }
    }
}