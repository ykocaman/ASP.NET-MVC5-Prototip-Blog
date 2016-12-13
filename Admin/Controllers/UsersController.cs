using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Admin.Helpers;
using System.Drawing.Imaging;

namespace Admin.Controllers
{
    public class UsersController : BaseController
    {

        // GET: Users
        public ActionResult Index()
        {
            var userSet = db.UserSet.Include(u => u.UserType);
            return View(userSet.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypeSet, "Id", "Title");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserTypeId,Name,Mail,Password")] User user, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(Avatar.InputStream))
                    {
                        user.Avatar = reader.ReadBytes(Avatar.ContentLength);
                    }
                }

                db.UserSet.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypeSet, "Id", "Title", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypeSet, "Id", "Title", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserTypeId,Name,Mail,Password")] User user, HttpPostedFileBase Avatar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;

                if (Avatar != null && Avatar.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(Avatar.InputStream))
                    {
                        user.Avatar = reader.ReadBytes(Avatar.ContentLength);
                    }
                }
                else
                {
                    db.Entry(user).Property("Avatar").IsModified = false;
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypeSet, "Id", "Title", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.UserSet.Find(id);
            db.UserSet.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Avatar(int id)
        {
            byte[] file = db.UserSet.Find(id).Avatar;
            if (file == null)
            {
                return Content("Resim bulunamadı");
            }
            return File(file,ImageHelper.GetContentType(file).ToString());
        }
    }
}
