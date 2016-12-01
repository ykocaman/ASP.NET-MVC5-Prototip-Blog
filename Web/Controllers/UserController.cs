using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;
using Web.ViewModel;

namespace Web.Controllers
{
    public class UserController : BaseController
    {

        public ActionResult LoginForm(UserViewModel user)
        {
            if (Session["user"] == null)
            {
                 return View();
            }
            return RedirectToAction("Index", "Posts");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                User found = db.UserSet.FirstOrDefault(r => r.Mail == user.Email && r.Password == user.Password);
                if (found != null)
                {
                    Session["user"] = found;
                    return Redirect(Request.UrlReferrer.ToString());
                }

                TempData["error"] = "Hatalı kullanıcı adı veya parola !";
            }
            else
            {
                TempData["error"] = "Eksik form alanı bıraktınız...";
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            TempData["error"] = "Çıkış yapıldı.";

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Avatar(int id)
        {
            byte[] file = db.UserSet.Find(id).Avatar;
            if (file == null)
            {
                return Content("Resim bulunamadı");
            }
            return File(file, ImageHelper.GetContentType(file).ToString());
        }

    }
}