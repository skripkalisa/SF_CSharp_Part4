// using CSBlog.Models.Blog;
// using CSBlog.Models.User;
// using Microsoft.EntityFrameworkCore;
//
// namespace CSBlog.Data.Repository;
//
// public class UserRepository : IUserRepository
// {
//   private readonly ApplicationDbContext _context;
//
//   public UserRepository(ApplicationDbContext context)
//   {
//     _context = context;
//   }
//
//   public async Task AddUser(BlogUser blogUser)
//   {
//     await _context.AddAsync(blogUser);
//     await _context.SaveChangesAsync();
//   }
//
//   public async Task EditUser(BlogUser blogUser)
//   {
//     var user = await _context.BlogUsers.FindAsync(blogUser);
//
//     if (user != null)
//
//     {
//       if (user.FirstName != string.Empty) blogUser.FirstName = user.FirstName;
//       if (user.LastName != string.Empty) blogUser.LastName = user.LastName;
//       if (user.Login != string.Empty) blogUser.Login = user.Login;
//       if (user.Password != string.Empty) blogUser.Password = user.Password;
//       if (user.Avatar != null ) blogUser.Avatar = user.Avatar;
//       if (user.UserRole.Count > 0)
//       {
//         foreach (var role in user.UserRole)
//         {
//           if (!blogUser.UserRole.Contains(role))
//             blogUser.UserRole.Add(role);
//         }
//       }
//     }
//
//     await _context.SaveChangesAsync();
//   }
//
//   public BlogUser? GetUserById(string userId)
//   {
//     var user = _context.BlogUsers.Find(userId);
//     Console.WriteLine("User by Id: " + user?.Login);
//     return user ?? null;
//   }
//
//   public async Task<List<BlogUser>> GetAllUsers()
//   {
//     return await _context.BlogUsers.ToListAsync();
//   }
//
//
//
//   public async Task DeleteUser(string userId)
//   {
//     var user = _context.BlogUsers.Where(user => user.Id == userId);
//     _context.Remove(user);
//     await _context.SaveChangesAsync();
//   }
// }