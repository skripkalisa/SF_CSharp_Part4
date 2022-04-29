using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class CommentController : Controller
{
  // GET

  public IActionResult Index()
  {
    // return View();
    return Content("Comment");
  }
}