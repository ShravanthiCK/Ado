using Microsoft.AspNetCore.Mvc;
using codefirstentityframeworkdemo.Models;
using codefirstentityframeworkdemo.Repositories;

namespace codefirstentityframeworkdemo.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postRepository;

        public PostController(IPost postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.GetPosts();
            return View(posts);
        }

        // GET: Post/Details/5
        public IActionResult Details(int id)
        {
            var post = _postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _postRepository.InsertPost(post);
                _postRepository.save();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Post/Edit/5
        public IActionResult Edit(int id)
        {
            var post = _postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _postRepository.UpdatePost(post);
                    _postRepository.save();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public IActionResult Delete(int id)
        {
            var post = _postRepository.GetPostByID(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _postRepository.DeletePost(id);
            _postRepository.save();
            return RedirectToAction(nameof(Index));
        }
    }
}
