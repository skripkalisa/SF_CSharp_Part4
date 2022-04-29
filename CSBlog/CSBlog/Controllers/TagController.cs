using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class TagController : Controller
{
  // GET
  public IActionResult Index()
  {
    // return View();
    return Content("Tag");
  }
}