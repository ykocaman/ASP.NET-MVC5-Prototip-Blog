using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Api()
        {
            dbContainer db = new dbContainer();
            var list = db.LogSet.Select(x => new { x.Id, x.Subject, x.Detail });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}