using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleBlog.Models;
namespace SimpleBlog.Repositories
{
  public interface IPostRepository
  {
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> RecentAsync();
    Task<Post> GetPostByIdAsync(int? id);
    Task AddPostAsync(Post post);
    Task UpdatePostAsync(Post post);
    Task DeletePostAsync(int id);
    Task<bool> PostExistsAsync(int id);
  }
}
