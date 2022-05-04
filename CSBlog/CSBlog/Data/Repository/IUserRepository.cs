using CSBlog.Models.User;

namespace CSBlog.Data.Repository;

public interface IUserRepository
{
  /// <summary>
  /// User management related methods
  /// </summary>
  /// <param name="user"></param>
  /// <returns></returns>
  Task AddUser(User user);
  Task EditUser(User user);
  User? GetUserById(string userId);
  Task<User[]> GetAllUsers();
  Task DeleteUser(Guid userId);
}