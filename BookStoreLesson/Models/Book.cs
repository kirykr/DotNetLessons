using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreLesson.Models;

public class Book
{
  public int Id { get; set; }
  [Required(ErrorMessage = "The title is required.")]
  [StringLength(200, ErrorMessage = "The title cannot exceed 200 characters.")]
  public string Title { get; set; }
  [Required(ErrorMessage = "The author is required.")]
  [StringLength(100, ErrorMessage = "The author cannot exceed 100 characters.")]
  public string Author { get; set; }
  [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000.")]
  public decimal Price { get; set; }
}
