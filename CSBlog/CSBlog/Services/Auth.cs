using CSBlog.Data;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using CSBlog.Models.User;

namespace CSBlog.Services;

public class Auth
{
  private readonly IHttpContextAccessor _httpContext;
  private readonly Cryptography _cryptography;
  private readonly string _authOptions;

  private readonly ApplicationDbContext _context;


  public Auth(IHttpContextAccessor httpContext, Cryptography cryptography, ApplicationDbContext context, IConfiguration authOptions)
  {
    _httpContext = httpContext;
    _cryptography = cryptography;
    _context = context;
    _authOptions = authOptions.GetSection("AuthKey:AuthEncryptionKey").Value;
  }

  private AuthInfo? _scopeAuthInfo;



  public AuthInfo? ScopeAuthInfo
  {
    get
    {
      if (_scopeAuthInfo == null)
      {
        AuthInfo? tokenAuthInfo = null;
        var cookieValue = _httpContext.HttpContext?.Request.Cookies["AuthToken"];

        if (!string.IsNullOrEmpty(cookieValue))
        {
          try
          {
            tokenAuthInfo = AuthInfoFromToken(cookieValue);
          }
          catch
          {
            // throw new Exception();
          }
        }

        _scopeAuthInfo = tokenAuthInfo ?? new AuthInfo();

      }

      return _scopeAuthInfo;
    }
  }


  public bool SignIn(string email, string password = "")
  {
    var user = _context.Users.FirstOrDefault(u => u.Email == email);
    // var user = _context.Users.Include(u => u.SecurityStamp).FirstOrDefault(u => u.Email == email);
    if (user == null) return false;
    var userCredential = user.SecurityStamp;
    var claimedPasswordHash = _cryptography.HashSHA256(password + userCredential);

    if (claimedPasswordHash != user.PasswordHash) return false;
    var userClaims = _context.UserClaims.Where(uc => uc.UserId == user.Id).Select(uc => uc.ClaimType);


    AuthInfo authInfo = new AuthInfo
    {
      UserId = user.Id,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email,
      Claims = new Dictionary<string, string>(),
      Permissions = userClaims.ToList()
    };
    _httpContext.HttpContext?.Response.Cookies.Append("AuthToken", AuthInfoToToken(authInfo));
    return true;
  }

  public void SignOut()
  {
    _httpContext.HttpContext?.Response.Cookies.Delete("AuthToken");
  }

  private string AuthInfoToToken(AuthInfo authInfo)
  {
    

    var serializedAuthInfo = JsonConvert.SerializeObject(authInfo);

    // Console.WriteLine($"AuthEncryptionKey: {_authOptions}");
    // Encrypt serialized authInfo
    // var key = Encoding.UTF8.GetBytes(_authOptions.AuthEncryptionKey);
    var key = Encoding.UTF8.GetBytes(_authOptions);
    var iv = Aes.Create().IV;
    var ivBase64 = Convert.ToBase64String(iv);
    var encBytes = _cryptography.EncryptStringToBytes_Aes(serializedAuthInfo, key, iv);
    var result = $"{ivBase64.Length.ToString().PadLeft(3, '0')}{ivBase64}{Convert.ToBase64String(encBytes)}";
    return result;
  }

  private AuthInfo? AuthInfoFromToken(string token)
  {
    // Decrypt token
    var ivLength = Convert.ToInt32(token.Substring(0, 3));
    var ivBase64 = token.Substring(3, ivLength);
    var iv = Convert.FromBase64String(ivBase64);
    var encBase64 = token.Substring(ivLength + 3);
    var encBytes = Convert.FromBase64String(encBase64);
    // var key = Encoding.UTF8.GetBytes(_authOptions.AuthEncryptionKey);
    var key = Encoding.UTF8.GetBytes(_authOptions);
    var decryptedToken = _cryptography.DecryptStringFromBytes_Aes(encBytes, key, iv);
    // Deserialize decrypted token
    var result = JsonConvert.DeserializeObject<AuthInfo>(decryptedToken);

    return result;
  }
}