using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class UserController : Controller
{
  // GET
  public IActionResult Index()
  {
    // return View();
    return Content("User");
  }
}