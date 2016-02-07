using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.DataProject.Model.Entities;
using System.Web.Http;

namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class VisitorApiController : ApiController
    {

        #region Member Variables 

        private readonly IVisitorBO _visitorBO;
        private readonly IVisitorDetailsBO _visitorDetailsBO;

        #endregion

        #region Constructor

        public VisitorApiController()
        {
            _visitorBO = new VisitorBO();
            _visitorDetailsBO = new VisitorDetailsBO();
        }

        #endregion

        #region Visitor Section

        public IHttpActionResult GetAllVisitors()
        {
            var visitorList = _visitorBO.GetAll().GetEnumerator();
            if (visitorList == null)
                return NotFound();
            return Ok(visitorList);
        }

        public IHttpActionResult InsertUpdateVisitor([FromBody]Visitor visitor)
        {
            if (visitor.Id == 0)
            {
                var visitorFromDb = _visitorBO.Insert(visitor);

                if (visitorFromDb == null)
                    return NotFound();

                return Ok(visitorFromDb);
            }
            else
            {
                _visitorBO.Update(visitor);
                return Ok(visitor);
            }
        }

        public IHttpActionResult GetVisitoInfo(int visitorId)
        {
            var visitorFromDb = _visitorBO.GetById(visitorId);
            if (visitorFromDb == null)
                return NotFound();
            return Ok(visitorFromDb);
        }

        public IHttpActionResult DeleteVisitor(int visitorId)
        {
            var visitorFromDb = _visitorBO.DeleteById(visitorId);
            if (visitorFromDb)
                return Ok(visitorFromDb);
            return NotFound();

        }

        #endregion

        #region Visit Details Section

        public IHttpActionResult InsertUpdateVisitorDetails([FromBody]VisitorDetails visitorDetails)
        {
            if (visitorDetails.Id == 0)
            {
                var visitorDetailsFromDb = _visitorDetailsBO.Insert(visitorDetails);

                if (visitorDetailsFromDb == null)
                    return NotFound();

                return Ok(visitorDetailsFromDb);
            }
            else
            {
                _visitorDetailsBO.Update(visitorDetails);
                return Ok(visitorDetails);
            }
        }

        public IHttpActionResult GetAllVisitorsDetails()
        {
            var visitorDetailsList = _visitorDetailsBO.GetAll();
            if (visitorDetailsList == null)
                return NotFound();
            return Ok(visitorDetailsList);
        }

        #endregion
    }
}