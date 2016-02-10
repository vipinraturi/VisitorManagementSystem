using Evis.eLearning.Business;
using Evis.VisitorManagement.DataProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Evis.VisitorManagement.Utilities;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class CategoryApiController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            var categoryBO = new CategoryBO();
            categoryBO.AddCategory(new Category { Id = 0, Name = "Test", IsActive = true });
        }

        // PUT api/<controller>/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult Get(
    int page = 1,
    int itemsPerPage = 1,
    string sortBy = "Email",
    bool reverse = false,
    string search = null)
        {
            // create list of 100 dumy users, replace
            // with call to repo in real app
            var users = new List<User>();
            users.Add(new User { Id = "1", Email = "abc.com", FirstName = "a", LastName = "x", Role = "admin", Username = "test1" });
            users.Add(new User { Id = "2", Email = "xyz.com", FirstName = "b", LastName = "y", Role = "user", Username = "test3" });
            users.Add(new User { Id = "3", Email = "lol.com", FirstName = "c", LastName = "z", Role = "admin", Username = "test4" });


            // searching
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                users = users.ToList().Where(x =>
                    x.FirstName.ToLower().Contains(search) ||
                    x.LastName.ToLower().Contains(search) ||
                    x.Username.ToLower().Contains(search) ||
                    x.Email.ToLower().Contains(search) ||
                    x.Role.ToLower().Contains(search)).ToList();
            }


            // sorting (done with the System.Linq.Dynamic library available on NuGet)
            //users = users.OrderBy(sortBy + (reverse ? " descending" : ""));

            var sortExpression = (reverse ? "desc" : "asc");

            int totalCount = users.Count;
            users = users.ToList().OrderByName(sortExpression, sortBy).ToList();

            // paging
            users = users.ToList().Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            // json result
            var json = new
            {
                count = totalCount,
                data = users.Select(x => new
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    Email = x.Email,
                    Role = x.Role
                })
            };

            return Ok(json);
        }

    }
}