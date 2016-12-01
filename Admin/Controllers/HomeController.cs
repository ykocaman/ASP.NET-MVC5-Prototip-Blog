using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public ActionResult Login(string email, string password)
        {
            User user = db.UserSet.FirstOrDefault(r => r.Mail == email && r.Password == password);
            if (user != null)
            {
                Session["user"] = user;
                SaveLog("success", user.Id);

                return RedirectToAction("Index");
            }

            TempData["error"] = "Hatalı kullanıcı adı veya parola !";
            return View();
        }

        public ActionResult Logout()
        {
            SaveLog("failed", ((User)Session["user"]).Id);

            Session.Remove("user");
            return Redirect("Index");
        }

        private void SaveLog(string type, int UserId)
        {
            Log log = new Log();
            log.UserId = UserId;
            log.Date = DateTime.Now;
            log.Subject = "Login/" + type;
            log.Detail = HttpContext.Request.Params.ToString();
            db.LogSet.Add(log);
            db.SaveChanges();
        }
    }
}