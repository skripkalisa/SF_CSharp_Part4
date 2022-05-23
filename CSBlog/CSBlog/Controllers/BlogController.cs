using CSBlog.Core.Repository;
using CSBlog.Core.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class BlogController : Controller
{
  private readonly IUnitOfWork _unitOfWork;

  public BlogController(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  // GET
  public IActionResult Index()
  {
    // var tags = _unitOfWork.Blog.GetAllTags();
    // return Json(tags);
    return View();
  }

  // GET
  public IActionResult Tags()
  {
    // var tags = _unitOfWork.Blog.GetAllTags();
    // return Json(tags);
    return View("Tag/Tags");
  }

  public IActionResult CreateTag()
  {
    // return Json(tags);
    return View("Tag/CreateTag");
  }

  [HttpPost]
  public IActionResult CreateTag(TagViewModel data)
  {
    return Json(data);
    // return View("Tag/CreateTag");
  }
}