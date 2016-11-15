using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        [HttpGet]
        public ActionResult Index(int start = 0, int pageSize = 25)
        {
            var posts = db.PostSet.OrderByDescending(q => q.Id).Skip(start).Take(pageSize);

            ViewBag.start = start + pageSize;
            ViewBag.pageSize = pageSize;

            return View(posts);
        }

        public ActionResult Api()
        {
            var list = db.LogSet.Select(x => new { x.Id, x.Subject, x.Detail });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}