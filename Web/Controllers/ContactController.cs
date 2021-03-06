﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["categories"] = new SelectList(db.CategorySet.AsEnumerable(), "Id", "Title");
            ViewData["posts"] = new SelectList(db.PostSet.Where(q => q.CategoryId == db.CategorySet.FirstOrDefault().Id).AsEnumerable(), "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Send(MailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Gönderen: {0} ({1})</p><p>Konu: {2}</p><p>Telefon: {3}</p><p>Mesaj:</p><p>{4}</p>";
                var message = new MailMessage();
                message.From = new MailAddress("yusufkocaman90@gmail.com", "Blog E-Posta Servisi");
                message.To.Add(new MailAddress("yusuf.kocaman@yandex.com"));
                message.Subject = "Yeni mesajınız var!";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Subject, model.Phone, model.Message);
                message.IsBodyHtml = true;

                try
                {
                    using (var smtp = new SmtpClient())
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "epostaservisii@gmail.com",
                            Password = "1qaz2wsx3EDC"
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;

                        smtp.Send(message);
                        return RedirectToAction("Success");
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Fail");
                }
            }

            ViewData["categories"] = new SelectList(db.CategorySet.AsEnumerable(), "Id", "Title");
            ViewData["posts"] = new SelectList(db.PostSet.Where(q => q.CategoryId == db.CategorySet.FirstOrDefault().Id).AsEnumerable(), "Id", "Title");

            return View("Index", model);
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Fail()
        {
            return View();
        }
    }
}