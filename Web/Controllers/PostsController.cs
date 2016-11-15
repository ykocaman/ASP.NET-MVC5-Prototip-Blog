using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
    public class PostsController : BaseController
    {
        public ActionResult Index(int id=0, int start = 0, int pageSize = 25, string query = "")
        {
            var posts = db.PostSet.AsQueryable();
            
            if(id > 0) {
                posts = posts.Where(q=> q.CategoryId == id);
            }

            if (query.Length > 0)
            {
                posts = posts.Where(q => q.Title.Contains(query) || q.Text.Contains(query));
            }

            posts.OrderByDescending(q => q.Id).Skip(start).Take(pageSize);

            ViewBag.start = start + pageSize;
            ViewBag.pageSize = pageSize;

            return View(posts);
        }

        // GET: Posts
        public ActionResult Show(int id=0)
        {
            Post post = db.PostSet.FirstOrDefault(q => q.Id == id);
            return View(post);
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