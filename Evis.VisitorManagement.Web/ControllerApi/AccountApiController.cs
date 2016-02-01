﻿using AutoMapper;
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
            if (string.IsNullOrEmpty(registerViewModel.UserId))
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

                //"Evis@123"
                await m_accountBO.CreateAsync(applicationUser, registerViewModel.Email);
                return Ok(applicationUser);
            }
            else
            {
                var applicationUser = Mapper.Map<RegisterViewModel, ApplicationUser>(registerViewModel);
                applicationUser.Id = registerViewModel.UserId;
                await m_accountBO.UpdateAsync(applicationUser);
                return Ok(applicationUser);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(string userId)
        {
            m_accountBO.DeleteAsync(userId);
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

        public async Task<IHttpActionResult> GetAllUsers(string id)
        {
            var applicationUsers = await m_accountBO.GetAllUsers();
            if (applicationUsers == null)
            {
                return NotFound();
            }
            return Ok(applicationUsers);
        }

        //[HttpPost]
        //[Route("/Api/Account/GetUser/{userId}")]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            //string userId = string.Empty;
            var applicationUser = await m_accountBO.FindAsync(userId);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return Ok(applicationUser);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(string userId)
        {
            //string userId = string.Empty;
            var isDeleted = await m_accountBO.DeleteAsync(userId);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok(isDeleted);
        }
    }
}