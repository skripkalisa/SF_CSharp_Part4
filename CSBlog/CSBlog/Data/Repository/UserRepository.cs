using CSBlog.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CSBlog.Data.Repository;

public class UserRepository : IUserRepository
{
  private readonly ApplicationDbContext _context;

  public UserRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task AddUser(User user)
  {
    await _context.AddAsync(user);
    await _context.SaveChangesAsync();
  }

  public async Task EditUser(User user)
  {
    var blogUser = await _context.BlogUsers.FindAsync(user.Id);

    if (blogUser != null)

    {
      if (user.FirstName != string.Empty) blogUser.FirstName = user.FirstName;
      if (user.LastName != string.Empty) blogUser.LastName = user.LastName;
      if (user.Login != string.Empty) blogUser.Login = user.Login;
      if (user.Avatar != string.Empty) blogUser.Avatar = user.Avatar;
      if (user.Avatar != string.Empty) blogUser.Avatar = user.Avatar;
      if (user.UserRole.Count > 0)
      {
        foreach (var role in user.UserRole)
        {
          if (!blogUser.UserRole.Contains(role))
            blogUser.UserRole.Add(role);
        }
      }
    }

    await _context.SaveChangesAsync();
  }

  public User? GetUserById(string userId)
  {
    var user = _context.BlogUsers.Find(userId);
    Console.WriteLine("User by Id: " + user?.Login);
    return user ?? null;
  }

  public async Task<User[]> GetAllUsers()
  {
    return await _context.BlogUsers.ToArrayAsync();
  }

  public async Task DeleteUser(Guid userId)
  {
    var user = _context.BlogUsers.Where(user => user.Id == userId.ToString());
    _context.Remove(user);
    await _context.SaveChangesAsync();
  }
}