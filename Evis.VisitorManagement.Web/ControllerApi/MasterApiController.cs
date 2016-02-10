using AutoMapper;
using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.DataProject.Model;
using Evis.VisitorManagement.DataProject.Model.Entities;
using Evis.VisitorManagement.Web.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Security;
using System.Linq;
using System.Net.Http;
using Evis.VisitorManagement.Common;
using System;
using MODI;
using System.IO;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class MasterApiController : ApiController
    {
        #region Member variables

        private IAccountBO m_accountBO = null;
        private IBuildingBO m_buildingBO = null;


        #endregion

        public MasterApiController()
        {
            m_buildingBO = new BuildingBO();
            m_accountBO = new AccountBO();
        }

        #region Login

        public async Task<IHttpActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {

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

        #endregion

        #region Master Data

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
            var genders = m_accountBO.GetAllGenders();
            if (genders == null)
            {
                return NotFound();
            }
            return Ok(genders.ToList());
        }


        #endregion

        #region Manage Users

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

                string defaultPassword = WebConfigurationManager.AppSettings["DefaultPassword"];
                await m_accountBO.CreateAsync(applicationUser, defaultPassword);
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


        [HttpPost]
        public async Task<IHttpActionResult> GetAllUsers(HttpRequestMessage request, PagingInformation pagingInformation)
        {
            var applicationUsers = await m_accountBO.GetAllUsers();

            applicationUsers = applicationUsers.ToList().OrderBy(item => item.FirstName).Skip((pagingInformation.CurrentPageNumber - 1) * pagingInformation.PageSize).Take(pagingInformation.PageSize).ToList();

            //applicationUsers = applicationUsers.ToList().OrderBy(item => item.FirstName).Skip(0).Take(1).ToList();

            if (applicationUsers == null)
            {
                return NotFound();
            }

            var userViewModel = new UsersViewModel();
            userViewModel.CurrentPageNumber = pagingInformation.CurrentPageNumber;
            userViewModel.SortDirection = pagingInformation.SortDirection;
            userViewModel.SortExpression = pagingInformation.SortExpression;
            userViewModel.TotalPages = pagingInformation.TotalPages;
            userViewModel.TotalRows = applicationUsers.Count();
            userViewModel.UsersList = applicationUsers;


            return Ok(userViewModel);
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

        // DELETE api/<controller>/5
        public void Delete(string userId)
        {
            m_accountBO.DeleteAsync(userId);
        }

        #endregion

        #region Client Profile

        [HttpGet]
        public IHttpActionResult GetCompanyInformation()
        {
            var comapanyInfo = m_buildingBO.GetCompanyInformation();
            if (comapanyInfo == null)
            {
                return NotFound();
            }
            return Ok(comapanyInfo);
        }

        public IHttpActionResult SaveCompany([FromBody]Company companyViewModel)
        {
            if (companyViewModel.Id == 0)
            {
                companyViewModel = m_buildingBO.InsertCompany(companyViewModel);
                return Ok(companyViewModel);
            }
            else
            {
                m_buildingBO.UpdateCompany(companyViewModel);
                return Ok(companyViewModel);
            }
        }

        #endregion

        #region Buildings

        public IHttpActionResult GetAllBuildings()
        {
            var allBuildings = m_buildingBO.GetAllBuildings();
            if (allBuildings == null)
                return NotFound();
            return Ok(allBuildings);
        }

        public IHttpActionResult InsertBuilding([FromBody]Building building)
        {
            if (building.Id == 0)
            {
                var allBuildings = m_buildingBO.InsertBuilding(building);
                if (allBuildings == null)
                    return NotFound();
                return Ok(allBuildings);
            }
            else
            {
                var isSuccess = m_buildingBO.UpdateBuilding(building);
                if (isSuccess)
                    return Ok(building);
                return NotFound();
            }
        }

        public IHttpActionResult GetAllBuildingLocations()
        {
            var allBuildingLocations = m_buildingBO.GetAllBuildingLocations();
            if (allBuildingLocations == null)
                return NotFound();
            return Ok(allBuildingLocations);

        }

        public IHttpActionResult GetBuildingInfo(int buildingId)
        {
            var building = m_buildingBO.GetBuildingInfo(buildingId);
            if (building == null)
                return NotFound();
            return Ok(building);
        }

        public IHttpActionResult DeleteBuilding(int buildingId)
        {
            var building = m_buildingBO.DeleteBuilding(buildingId);
            if (building)
                return Ok(building);
            return NotFound();

        }

        #endregion

        #region Gates

        public IHttpActionResult InsertGate([FromBody]BuildingGate buildingGate)
        {
            if (buildingGate.Id == 0)
            {
                var allBuildings = m_buildingBO.InsertBuildingGate(buildingGate);
                if (allBuildings == null)
                    return NotFound();
                return Ok(allBuildings);
            }
            else
            {
                var isSuccess = m_buildingBO.UpdateBuildingGate(buildingGate);
                if (isSuccess)
                    return Ok(buildingGate);
                return NotFound();
            }
        }

        public IHttpActionResult GetAllGates()
        {
            var allBuildingsGates = m_buildingBO.GetAllBuildingGates();
            if (allBuildingsGates == null)
                return NotFound();

            var buildingsGates = allBuildingsGates.Select(x => new
            {
                Id = x.Id,
                BuildingName = x.Building.Name,
                GateNumber = x.GateNumber,
                Description = x.Description,
                PhoneNumber = x.PhoneNumber,
                BuildingId = x.BuildingId,
                Region = x.Building.Region,
                Country = x.Building.Country,
                State = x.Building.State,
                City = x.Building.City
            });

            return Ok(buildingsGates);
        }

        public IHttpActionResult GetBuildingGateInfo(int gateId)
        {
            var buildingGate = m_buildingBO.GetBuildingGateInfo(gateId);
            if (buildingGate == null)
                return NotFound();

            var buildingGateInfo = new
            {
                Id = buildingGate.Id,
                BuildingName = buildingGate.Building.Name,
                GateNumber = buildingGate.GateNumber,
                Description = buildingGate.Description,
                PhoneNumber = buildingGate.PhoneNumber,
                BuildingId = buildingGate.BuildingId,
                Region = buildingGate.Building.Region,
                Country = buildingGate.Building.Country,
                State = buildingGate.Building.State,
                City = buildingGate.Building.City
            };

            return Ok(buildingGateInfo);
        }

        public IHttpActionResult DeleteBuildingGate(int gateId)
        {
            var isDeleted = m_buildingBO.DeleteBuildingGate(gateId);
            if (isDeleted)
                return Ok(isDeleted);
            return NotFound();
        }

        #endregion

        public IHttpActionResult ImageUpload([FromBody]FileUpload fileUpload)
        {
            if (fileUpload.Id == 0)
            {
                fileUpload.ImageContent = Convert.FromBase64String(fileUpload.ImageType.Split(',')[1]);
                fileUpload.ImageType = fileUpload.ImageType.Split(',')[0];
                //string base64String = Convert.ToBase64String(fileUpload.Picture);
                var allBuildings = m_buildingBO.InsertImage(fileUpload);
                if (allBuildings == null)
                    return NotFound();
                return Ok(allBuildings);
            }
            else
            {
                fileUpload.ImageContent = Convert.FromBase64String(fileUpload.ImageType.Split(',')[1]);
                fileUpload.ImageType = fileUpload.ImageType.Split(',')[0];
                var isSuccess = m_buildingBO.UpdateImage(fileUpload);
                if (isSuccess)
                    return Ok(fileUpload);
                return NotFound();
            }
        }

        public IHttpActionResult GetImage(string userId)
        {
            var imageRecord = m_buildingBO.GetImage(userId);
            if (imageRecord == null)
                return NotFound();
            imageRecord.ImageType = imageRecord.ImageType + ',' + Convert.ToBase64String(imageRecord.ImageContent);
            return Ok(imageRecord);
        }
    }
}