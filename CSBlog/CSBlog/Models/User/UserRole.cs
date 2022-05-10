using System.ComponentModel.DataAnnotations;

namespace CSBlog.Models.User;

public class UserRole
{
  public Guid Id { get; set; } = Guid.NewGuid();
  [Required (ErrorMessage = "This field is required.")]
  [StringLength(16)]
  public string Role { get; set; } = "User";
}