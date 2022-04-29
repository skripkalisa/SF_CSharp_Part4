using Microsoft.AspNetCore.Identity;

namespace CSBlog.Models;

public class User : IdentityUser
{
  // public Guid Id { get; set; }
  internal string FirstName { get; set; } = string.Empty;
  internal string LastName { get; set; } = string.Empty;
  internal string Login { get; set; } = string.Empty;
  internal string Avatar { get; set; } = string.Empty;
}