using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Models;

public class User
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Name is required.")]
  [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
  public string Name { get; set; }

  [Required(ErrorMessage = "Email is required.")]
  [EmailAddress(ErrorMessage = "Invalid Email Address")]
  public string Email { get; set; }

  [Required(ErrorMessage = "Password is required.")]
  public string Password { get; set; }

  [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
  public int Age { get; set; }


}
