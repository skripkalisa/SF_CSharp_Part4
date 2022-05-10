using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CSBlog.Models.User;

public class User : IdentityUser
{
  // public Guid Id { get; set; }
  [Required (ErrorMessage = "This field is required.")] [StringLength(32)] public string FirstName { get; set; } = string.Empty;
  [Required (ErrorMessage = "This field is required.")] [StringLength(32)] public string LastName { get; set; } = string.Empty;
  [Required (ErrorMessage = "This field is required.")] [StringLength(32)] public string Login { get; set; } = string.Empty;
  [Required (ErrorMessage = "This field is required.")] [StringLength(64)] public string UserEmail { get; set; } = string.Empty;

  [NotMapped]
  [FileExtensions(Extensions = "jpg, jpeg, png, svg")]
  public IFormFile? Avatar { get; set; }

  [Required (ErrorMessage = "This field is required.")] [StringLength(12, MinimumLength = 6)][PasswordPropertyText] public string Password { get; set; } = string.Empty;
  public List<UserRole> UserRole { get; set; } = null!;
}