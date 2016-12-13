using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    [Filters.AdminAuthorize]
    public class BaseController : Controller
    {
        public dbContainer db = new dbContainer();

        public BaseController()
        {
            var user = (User)System.Web.HttpContext.Current.Session["user"];
            if (user != null)
            {
                var context = System.Web.HttpContext.Current;
                Log log = new Log();
                log.UserId = user.Id;
                log.Date = DateTime.Now;
                log.Subject = context.Request.Path;
                log.Detail = context.Request.Params.ToString();
                db.LogSet.Add(log);
                db.SaveChanges();
            }
        }
    }
}