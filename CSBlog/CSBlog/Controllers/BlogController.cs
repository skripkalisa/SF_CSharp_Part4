using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class BlogController : Controller
{

  public IActionResult Index()
  {
    // return View();
    return Content("Blog");
  }


}