using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public interface IUserRepository
{
  /// <summary>
  /// User management related methods
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  Task AddUser(BlogUser user);
  Task EditUser(BlogUser user);
  BlogUser? GetUserById(string userId);
  Task<BlogUser[]> GetAllUsers();
  Task DeleteUser(Guid userId);
}