using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Filters;
using Web.Helpers;
using Web.ViewModel;

namespace Web.Controllers
{
    [MemberAuthorize]
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var carts = getCarts();
            return View(carts);
        }

        public ActionResult PayForm(){
            var carts = getCarts();
            if (carts != null && carts.Count() > 0)
            {
                ViewBag.Amount = carts.Sum(q => q.Project.Price);
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Pay(CreditViewModel credit)
        {
            var carts = getCarts();

            if (ModelState.IsValid)
            {
                foreach (var cart in carts)
                {
                    ProjectAccess access = new ProjectAccess();
                    access.UserId = UserHelper.Current().Id;
                    access.ProjectId =  cart.ProjectId;

                    Payment payment = new Payment();
                    payment.Amount = cart.Project.Price;
                    payment.Date = DateTime.Now;
                    payment.UserId = UserHelper.Current().Id;
                    payment.ProjectAccess = access;
                    db.PaymentSet.Add(payment);

                    cart.Status = CartStatus.Paid;
                }

                db.SaveChanges();

                return RedirectToAction("Success");
            }

            ViewBag.Amount = carts.Sum(q => q.Project.Price);
            return View("PayForm");
        }

        public ActionResult Success()
        {
            return View();
        }

        private IQueryable<Cart> getCarts()
        {
            if (UserHelper.isMember() == true)
            {
                int userId = UserHelper.Current().Id;
                return db.CartSet.Where(q => q.UserId == userId && q.Status == Data.CartStatus.New);
            }

            return null;
        }
    }
}