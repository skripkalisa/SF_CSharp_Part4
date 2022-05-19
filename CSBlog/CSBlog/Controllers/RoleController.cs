using CSBlog.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class RoleController : Controller
{
  // GET
  // [Authorize(Roles = "User,Administrator,Moderator")]
  // [Authorize(Policy = Constants.Policies.RequireAdmin)]
  [Authorize]
  public IActionResult Index()
  {
    return View();
  }

  // [Authorize(Policy = "RequireModerator")]
  [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Moderator}")]
  public IActionResult Moderator()
  {
    return View();
  }


  [Authorize(Policy = Constants.Policies.RequireAdmin)]
  public IActionResult Admin()
  {
    return View();
  }
}