using BookStoreLesson.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreLesson.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();
        public IActionResult Index()
        {
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Details(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

    }
}
