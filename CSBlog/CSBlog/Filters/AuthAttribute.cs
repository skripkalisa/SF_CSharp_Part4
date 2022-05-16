using CSBlog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CSBlog.Filters;

public class AuthAttribute : ActionFilterAttribute, IAuthorizationFilter
{
  private readonly List<string> _permissions;

  public AuthAttribute(string permissions = "")
  {
    _permissions = permissions.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
      .Select(p => p.Trim())
      .ToList();
  }

  public void OnAuthorization(AuthorizationFilterContext context)
  {
    var service = context.HttpContext.RequestServices.GetService(typeof(Auth)) as Auth;

    if (service?.ScopeAuthInfo is { IsAuthenticated: true } && !_permissions.Any())
    {
      return;
    }

    if (service?.ScopeAuthInfo != null && (!service.ScopeAuthInfo.IsAuthenticated || !_permissions.Any(p => service.ScopeAuthInfo.Permissions != null && service.ScopeAuthInfo.Permissions.Contains(p))))
    {
      var returnUrl = context.HttpContext.Request.Path;
      context.Result = new RedirectToActionResult("Login", "Account", new { returnUrl });
    }
  }
  
}