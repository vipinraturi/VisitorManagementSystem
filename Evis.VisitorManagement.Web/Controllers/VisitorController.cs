using MODI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evis.VisitorManagement.Web.Controllers
{
    public class VisitorController : Controller
    {
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
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                                                   Path.GetFileName(uploadFile.FileName));
                    uploadFile.SaveAs(filePath);

                    string imageText = ExtractTextFromImage(filePath);
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