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

  public async Task AddUser(BlogUser user)
  {
    await _context.AddAsync(user);
    await _context.SaveChangesAsync();
  }

  public async Task EditUser(BlogUser user)
  {
    var blogUser = await _context.BlogUsers.FindAsync(user.Id);

    if (blogUser != null)

    {
      if (user.FirstName != string.Empty) blogUser.FirstName = user.FirstName;
      if (user.LastName != string.Empty) blogUser.LastName = user.LastName;
      // if (user.Login != string.Empty) blogUser.Login = user.Login;
      // if (user.Password != string.Empty) blogUser.Password = user.Password;
      if (user.Avatar != null ) blogUser.Avatar = user.Avatar;
      // if (user.UserRole.Count > 0)
      // {
      //   foreach (var role in user.UserRole)
      //   {
      //     if (!blogUser.UserRole.Contains(role))
      //       blogUser.UserRole.Add(role);
      //   }
      // }
    }

    await _context.SaveChangesAsync();
  }

  public BlogUser? GetUserById(string userId)
  {
    var user = _context.BlogUsers.Find(userId);
    // Console.WriteLine("User by Id: " + user?.Login);
    return user ?? null;
  }

  public async Task<BlogUser[]> GetAllUsers()
  {
    return await _context.BlogUsers.ToArrayAsync();
  }

  public async Task DeleteUser(string userId)
  {
    var user = _context.BlogUsers.Where(user => user.Id == userId);
    _context.Remove(user);
    await _context.SaveChangesAsync();
  }
}