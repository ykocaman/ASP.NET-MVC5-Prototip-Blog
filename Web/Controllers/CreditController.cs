using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class CreditController : BaseController
    {
        // GET: Credit
        public ActionResult Index(int Id)
        {
            var project = db.ProjectSet.FirstOrDefault(q => q.Id == Id);
            ViewBag.project = project;

            return View();
        }

        [HttpPost]
        public ActionResult Pay(int Id, CreditViewModel credit)
        {
            if (ModelState.IsValid)
            {
                Project project = db.ProjectSet.FirstOrDefault(q => q.Id == Id);

                ProjectAccess access = new ProjectAccess();
                access.UserId = ((User)Session["user"]).Id;
                access.ProjectId = project.Id;

                Payment payment = new Payment();
                payment.Amount = project.Price;
                payment.Date = DateTime.Now;
                payment.UserId = ((User)Session["user"]).Id;
                payment.ProjectAccess = access;
                db.PaymentSet.Add(payment);

                db.SaveChanges();

                return RedirectToAction("Success");
            }

            return View("Index");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}