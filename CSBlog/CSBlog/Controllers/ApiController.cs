using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : Controller
{
  // GET
  public IActionResult Index()
  {
    return Content("Api");
    // return View();
  }
}