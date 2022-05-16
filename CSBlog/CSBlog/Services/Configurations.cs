namespace CSBlog.Services;

public class AuthOptions
{
  public const string AuthKey = "AuthKey";
  public string AuthEncryptionKey { get; set; } = String.Empty;
}