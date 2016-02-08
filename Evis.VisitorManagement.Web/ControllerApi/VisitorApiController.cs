using Evis.VisitorManagement.Business;
using Evis.VisitorManagement.Business.Contract;
using Evis.VisitorManagement.DataProject.Model.Entities;
using System.Web.Http;
using System.Linq;


namespace Evis.VisitorManagement.Web.ControllerApi
{
    public class VisitorApiController : ApiController
    {

        #region Member Variables 

        //private readonly IVisitorBO _visitorBO;
        //private readonly IVisitorDetailsBO _visitorDetailsBO;
        //private readonly IGenderBO _genderBO;
        VisitorBO _visitorBO = null;
        VisitorDetailsBO _visitorDetailsBO = null;
        GenderBO _genderBO = null;

        #endregion

        #region Constructor

        public VisitorApiController()
        {
            //_visitorBO = new VisitorBO();
            //_visitorDetailsBO = new VisitorDetailsBO();
            _visitorBO = new VisitorBO();
            _visitorDetailsBO = new VisitorDetailsBO();
            _genderBO = new GenderBO();
        }

        #endregion

        #region Visitor Section

        public IHttpActionResult GetAllVisitors()
        {
            var visitorList = _visitorBO.GetAll().Where(x=> x.IsActive==true).ToList();
            if (visitorList == null)
                return NotFound();
            return Ok(visitorList);
        }

        public IHttpActionResult InsertUpdateVisitor([FromBody]Visitor visitor)
        {
            visitor.IsActive = true; ;
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
            Visitor visitor=_visitorBO.GetById(visitorId);
            visitor.IsActive=false;
           _visitorBO.Update(visitor);

            return Ok(visitor);
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

        public IHttpActionResult GetAllGender()
        {
            var genderList = _genderBO.GetAll();
            if (genderList == null)
                return NotFound();
            return Ok(genderList);
        }
        #endregion
    }
}