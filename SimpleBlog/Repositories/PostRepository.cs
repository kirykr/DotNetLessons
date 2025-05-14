using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SimpleBlog.Repositories
{
  public class PostRepository : IPostRepository
  {
    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
      return await _context.Posts.ToListAsync();
    }
    public async Task<Post> GetPostByIdAsync(int id)
    {
      return await _context.Posts.FindAsync(id);
    }
    public async Task AddPostAsync(Post post)
    {
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();
    }
    public async Task UpdatePostAsync(Post post)
    {
      _context.Posts.Update(post);
      await _context.SaveChangesAsync();
    }
    public async Task DeletePostAsync(int id)
    {
      var post = await _context.Posts.FindAsync(id); if (post != null)
      {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
      }
    }
  }
}
