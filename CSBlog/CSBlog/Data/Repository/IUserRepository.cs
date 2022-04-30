using CSBlog.Models.User;

namespace CSBlog.Data.Repository;

public interface IUserRepository
{
  Task AddUser(User user);
  Task EditUserProfile(Guid userId);
  Task<User[]> GetAllUsers();
  Task DeleteUser(Guid userId);
}