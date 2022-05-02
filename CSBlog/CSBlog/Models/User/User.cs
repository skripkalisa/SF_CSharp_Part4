using Microsoft.AspNetCore.Identity;

namespace CSBlog.Models.User;

public class User : IdentityUser
{
  // public Guid Id { get; set; }
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Login { get; set; } = string.Empty;
  public string Avatar { get; set; } = string.Empty;
}