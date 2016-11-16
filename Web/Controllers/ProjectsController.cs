using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProjectsController : BaseController
    {
        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.ProjectSet.AsQueryable();

            return View(projects);
        }

        public ActionResult Download(int id)
        {
            var project = db.ProjectSet.FirstOrDefault(q => q.Id == id);
            if (project == null)
            {
                return Content("Dosya bulunamadı");
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=" + project.Title);

            return File(project.File, project.ContentType);
        }
    }
}