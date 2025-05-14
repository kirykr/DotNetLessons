using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class PostsController : Controller
    {
        private static List<Post> posts = new List<Post>
        {
            new Post { Id = 1, Title = "First Post", Content = "This is the first post.", DateCreated =
            DateTime.Now },
            new Post { Id = 2, Title = "Second Post", Content = "This is the second post.",
            DateCreated = DateTime.Now }
        };
        // GET: /Posts
        public IActionResult Index()
        {
            return View(posts);
        }
        // GET: /Posts/Details/1
        public IActionResult Details(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        // GET: /Posts/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: /Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = posts.Max(p => p.Id) + 1;
                post.DateCreated = DateTime.Now;
                posts.Add(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        // GET: /Posts/Edit/1
        public IActionResult Edit(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        // POST: /Posts/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            var existingPost = posts.FirstOrDefault(p => p.Id == id);
            if (existingPost == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        // GET: /Posts/Delete/1
        public IActionResult Delete(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        // POST: /Posts/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                posts.Remove(post);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
