using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Repositories;
using System.Threading.Tasks;

namespace SimpleBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return View(posts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id); if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                await _postRepository.AddPostAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id); if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _postRepository.UpdatePostAsync(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id); if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postRepository.DeletePostAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
