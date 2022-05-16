using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.ViewModels;

public class UserRegister : UserChangePassword
{
  [Required, StringLength(50, MinimumLength = 3)]
  [Display(Name = "First Name")]
  public string FirstName { get; set; } = String.Empty;

  [Required, StringLength(50, MinimumLength = 3)]
  [Display(Name = "Last Name")]
  public string LastName { get; set; } = String.Empty;

  [Required, EmailAddress, StringLength(100)]
  [Remote("CheckEmailExists", "User", ErrorMessage = "This email address is already registered")]
  public string Email { get; set; } = String.Empty;
}

public class UserEdit
{
  [Required, StringLength(50, MinimumLength = 3)]
  [Display(Name = "First Name")]
  public string FirstName { get; set; } = String.Empty;

  [Required, StringLength(50, MinimumLength = 3)]
  [Display(Name = "Last Name")]
  public string LastName { get; set; } = String.Empty;

  [Required, EmailAddress, StringLength(100)]
  [Remote("CheckEmailExists", "User", ErrorMessage = "This email address is already registered")]
  public string Email { get; set; } = String.Empty;
}

public class UserChangePassword
{
  [Required, StringLength(15, MinimumLength = 6)]
  [DataType(DataType.Password)]
  public string Password { get; set; } = String.Empty;

  [Required, StringLength(15, MinimumLength = 6)]
  [Compare("Password")]
  [Display(Name = "Confirm Password")]
  [DataType(DataType.Password)]
  public string ConfirmPassword { get; set; } = String.Empty;
}