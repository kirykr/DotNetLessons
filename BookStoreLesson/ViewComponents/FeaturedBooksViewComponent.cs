using System;
using BookStoreLesson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStoreLesson.ViewComponents;

public class FeaturedBooksViewComponent : ViewComponent
{
  private static List<Book> books =
  [
      new Book { Id = 1, Title = "Featured Book 1", Author = "Author 1", Price = 29.99M },
      new Book { Id = 2, Title = "Featured Book 2", Author = "Author 2", Price = 39.99M }
  ];
  public async Task<IViewComponentResult> InvokeAsync()
  {
    var featuredBooks = books.Where(b => b.Price > 20).ToList();
    return View(featuredBooks);
  }
}
