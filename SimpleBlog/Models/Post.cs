using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models;

public class Post
{
  public int Id { get; set; }
  [Required]
  [StringLength(100)]
  public string Title { get; set; }
  [Required]
  public string Content { get; set; }
  [DataType(DataType.Date)]
  public DateTime DateCreated { get; set; }
}
