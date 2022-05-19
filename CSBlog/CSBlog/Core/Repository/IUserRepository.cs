using CSBlog.Models.User;

namespace CSBlog.Core;

public interface IUserRepository
{
  /// <summary>
  /// User management related methods
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  ///
  ICollection<BlogUser> GetUsers();

  Task AddUser(BlogUser user);
  Task EditUser(BlogUser user);
  BlogUser? GetUserById(string userId);
  Task<BlogUser[]> GetAllUsers();
  Task DeleteUser(string userId);
}