using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.Web.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class AccountApiController : ApiController
    {
        private IAccountBO m_accountBO = new AccountBO();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {
            //var loginViewModel = JsonConvert.DeserializeObject<List<LoginViewModel>>(loginViewModelJSON);
            m_accountBO = new AccountBO();
            var user = await m_accountBO.FindAsync(loginViewModel.UserName, loginViewModel.Password);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel registerViewModel)
        {
            //var loginViewModel = JsonConvert.DeserializeObject<List<LoginViewModel>>(loginViewModelJSON);
            //m_accountBO = new AccountBO();
            var user = await m_accountBO.FindAsync(registerViewModel.UserName);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}