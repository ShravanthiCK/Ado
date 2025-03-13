using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo1.Models;


namespace EntityFrameworkDemo1.Controllers
{
    public class PostController : Controller
    {
        NorthwndContext cnt=new NorthwndContext();

        // GET: PostController
        public ActionResult Index()
        {
            return View(cnt.Posts.ToList());
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            Post post = cnt.Posts.Find(id);
            if (post == null)
            {
                return Content("post not found");
            }
            return View(post);
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
           if(ModelState.IsValid)
            {
                cnt.Posts.Add(post);
                cnt.SaveChanges();
                return RedirectToAction("Index");   
            }
           return View(post);
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            Post post = cnt.Posts.Find(id);
            if(post==null)
            {
                return Content("Post Not found");
            }
            return View(post);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                cnt.Entry(post).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                cnt.SaveChanges(true);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            Post post = cnt.Posts.Find(id);
            cnt.Posts.Remove(post);
            cnt.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: PostController/Delete/5
       
    }
}
