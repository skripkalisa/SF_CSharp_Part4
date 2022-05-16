namespace CSBlog.Models.User;

public class AuthInfo
{
  public AuthInfo()
  {
    CreationDate = DateTime.UtcNow;
  }

  public string? UserId { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public List<string>? Permissions { get; set; }
  public Dictionary<string, string>? Claims { get; set; }
  public DateTime CreationDate { get; set; }

  public bool IsAuthenticated => UserId != null;

  
  // public bool IsAuthenticated => UserId != null && Int32.Parse(UserId) > 0;
}