using CSBlog.Models.User;

namespace CSBlog.Data.Repository;

public class UserRepository : IUserRepository
{
  public Task AddUser(User user)
  {
    throw new NotImplementedException();
  }

  public Task EditUserProfile(Guid userId)
  {
    throw new NotImplementedException();
  }

  public Task<User[]> GetAllUsers()
  {
    throw new NotImplementedException();
  }

  public Task DeleteUser(Guid userId)
  {
    throw new NotImplementedException();
  }
}