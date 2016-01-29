using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evis.VisitorManagement.Web.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        public ActionResult ScanVisitorCard()
        {
            return View();
        }

        public ActionResult AddVisitorManually()
        {
            return View();
        }

        public ActionResult VisitorList()
        {
            return View();
        }

    }
}