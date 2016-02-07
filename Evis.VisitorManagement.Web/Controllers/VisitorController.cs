using Evis.VisitorManagement.Business.Contract;
using MODI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evis.VisitorManagement.Web.Controllers
{
    [Authorize]
    public class VisitorController : Controller
    {

        private readonly IVisitorBO _visitorBO;

        public VisitorController(IVisitorBO visitorBO)
        {
            _visitorBO = visitorBO;
        }
       
        public ActionResult List()
        {
            var VisitorList = _visitorBO.GetAll().ToList();

            return View(VisitorList);
        }

        // GET: Visitor
        [HttpGet]
        public ActionResult ScanVisitorCard()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ScanVisitorCard(HttpPostedFileBase uploadFile)
        {
            try
            {
                if (uploadFile.ContentLength > 0)
                {
                    var directoryPath = HttpContext.Server.MapPath("~/Content/Uploads");

                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);


                    var filePath = Path.Combine(directoryPath,
                                                   Path.GetFileName(uploadFile.FileName));
                    uploadFile.SaveAs(filePath);

                    var imageText = ExtractTextFromImage(filePath);
                }
                return View();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ActionResult AddVisitorManually()
        {
            return View();
        }

        public ActionResult VisitorList()
        {
            return View();
        }

        #region "Private Method"

        private string ExtractTextFromImage(string filePath)
        {
            Document modiDocument = new Document();
            modiDocument.Create(filePath);
            modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);

            MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            string extractedText = modiImage.Layout.Text;
            modiDocument.Close();
            return extractedText;
        }

        #endregion

    }
}