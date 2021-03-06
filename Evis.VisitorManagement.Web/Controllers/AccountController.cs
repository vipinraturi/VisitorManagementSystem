﻿using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Evis.VisitorManagement.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountBO m_accountBO;

        public AccountController(IAccountBO accountBO)
        {
            m_accountBO = accountBO;
        }
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Login()
        {
            HttpCookie authCookie = System.Web.HttpContext.Current.Request.Cookies[".ASPXAUTH"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null & !authTicket.Expired)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            string test = System.Guid.NewGuid().ToString();
            var passwordHash = new Microsoft.AspNet.Identity.PasswordHasher();
            var hashedPassword = passwordHash.HashPassword("Evis@123");
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
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

        public ActionResult Users(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        public ActionResult EditUser(string userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }


    }
}