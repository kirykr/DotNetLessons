using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Data;
using SimpleBlog.Models;

namespace SimpleBlog.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context; public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync(); return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                // User is authenticated
                return RedirectToAction("Index");
            }
            // Authentication failed
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }

    }
}
