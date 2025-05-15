using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models;

namespace SimpleBlog.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }
  public DbSet<Post> Posts { get; set; }
  public DbSet<User> Users { get; set; }
}
