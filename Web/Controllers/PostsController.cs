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

       [HttpPost]
        public ActionResult Comment(int post_id, String comment_text)
        {
           var user = (User)Session["user"];

           if(user == null){
               TempData["comment_error"] = "Giriş yapmadan yorum yapamasınız !";
               return Redirect(Request.UrlReferrer.ToString());
           }

           if(comment_text == "" || post_id < 1){
               TempData["comment_error"] = "Formdaki eksikleri doldurunuz !";
               return Redirect(Request.UrlReferrer.ToString());
           }

           var comment = new Comment();
           comment.Date = DateTime.Now;
           comment.PostId = post_id;
           comment.Text = comment_text;
           comment.UserId = user.Id;
           comment.Verified = false;

           db.CommentSet.Add(comment);
           db.SaveChanges();

           TempData["comment_success"] = "Yorumunuz onay sonrasında yayına alınacaktır, teşekkürler !";
           return Redirect(Request.UrlReferrer.ToString());
        }

       [HttpPost]
       public ActionResult CommentAjax(int post_id, String comment_text)
       {
           Comment(post_id, comment_text);

           if(TempData["comment_error"] != null){
               return Content(TempData["comment_error"].ToString());
           }
           return Content(TempData["comment_success"].ToString()); 
       }

    }
}