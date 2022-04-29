using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class ArticleController: Controller
{  
  // GET
  public IActionResult Index()
  {
    // return View();
    return Content("Article");
  }
  
}