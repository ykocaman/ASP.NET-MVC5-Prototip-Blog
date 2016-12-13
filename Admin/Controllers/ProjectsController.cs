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
    public class ProjectsController : BaseController
    {

        // GET: Projects
        public ActionResult Index()
        {
            var projectSet = db.ProjectSet.Include(p => p.User);
            return View(projectSet.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.ProjectSet.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,UserId,Title,Text,Price")] Project project, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                if (File != null && File.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(File.InputStream))
                    {
                        project.File = reader.ReadBytes(File.ContentLength);
                        project.Filename = File.FileName;
                        project.ContentType = File.ContentType;
                    }
                }
                else
                {
                    project.ContentType = "";
                    project.Filename = "";
                }

                db.ProjectSet.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", project.UserId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.ProjectSet.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", project.UserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,UserId,Title,Text,Price")] Project project, HttpPostedFileBase File)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;

                if (File != null && File.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(File.InputStream))
                    {
                        project.File = reader.ReadBytes(File.ContentLength);
                        project.Filename = File.FileName;
                        project.ContentType = File.ContentType;
                    }
                }
                else
                {
                    db.Entry(project).Property("File").IsModified = false;
                    db.Entry(project).Property("Filename").IsModified = false;
                    db.Entry(project).Property("ContentType").IsModified = false;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", project.UserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.ProjectSet.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.ProjectSet.Find(id);
            db.ProjectSet.Remove(project);
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

        public ActionResult File(int id)
        {
            Project item = db.ProjectSet.Find(id);
            if (item == null)
            {
                return Content("Dosya bulunamadı");
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=" + item.Filename);

            return File(item.File, item.ContentType);
        }
    }
}
