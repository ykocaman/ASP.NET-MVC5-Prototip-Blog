using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace Admin.Controllers
{
    public class ProjectAccessesController : BaseController
    {

        // GET: ProjectAccesses
        public ActionResult Index()
        {
            var projectAccessSet = db.ProjectAccessSet.Include(p => p.Project).Include(p => p.User).Include(p => p.Payment);
            return View(projectAccessSet.ToList());
        }

        // GET: ProjectAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAccess projectAccess = db.ProjectAccessSet.Find(id);
            if (projectAccess == null)
            {
                return HttpNotFound();
            }
            return View(projectAccess);
        }

        // GET: ProjectAccesses/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.ProjectSet, "Id", "Title");
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name");
            ViewBag.Id = new SelectList(db.PaymentSet, "Id", "Id");
            return View();
        }

        // POST: ProjectAccesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectId,UserId")] ProjectAccess projectAccess)
        {
            if (ModelState.IsValid)
            {
                db.ProjectAccessSet.Add(projectAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.ProjectSet, "Id", "Title", projectAccess.ProjectId);
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", projectAccess.UserId);
            ViewBag.Id = new SelectList(db.PaymentSet, "Id", "Id", projectAccess.Id);
            return View(projectAccess);
        }

        // GET: ProjectAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAccess projectAccess = db.ProjectAccessSet.Find(id);
            if (projectAccess == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.ProjectSet, "Id", "Title", projectAccess.ProjectId);
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", projectAccess.UserId);
            ViewBag.Id = new SelectList(db.PaymentSet, "Id", "Id", projectAccess.Id);
            return View(projectAccess);
        }

        // POST: ProjectAccesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectId,UserId")] ProjectAccess projectAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.ProjectSet, "Id", "Title", projectAccess.ProjectId);
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", projectAccess.UserId);
            ViewBag.Id = new SelectList(db.PaymentSet, "Id", "Id", projectAccess.Id);
            return View(projectAccess);
        }

        // GET: ProjectAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAccess projectAccess = db.ProjectAccessSet.Find(id);
            if (projectAccess == null)
            {
                return HttpNotFound();
            }
            return View(projectAccess);
        }

        // POST: ProjectAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectAccess projectAccess = db.ProjectAccessSet.Find(id);
            db.ProjectAccessSet.Remove(projectAccess);
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
    }
}
