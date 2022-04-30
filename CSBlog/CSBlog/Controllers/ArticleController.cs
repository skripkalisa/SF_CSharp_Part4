using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class ArticleController: Controller
{  
  private readonly IBlogRepository _repo;
  
  public ArticleController(IBlogRepository repo)
  {
    _repo = repo;
  }

  // GET
  public IActionResult Index()
  {
    // return View();
    return Content("Article");
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> Create(Article article)
  {
    await _repo.AddArticle(article);
    return Content("Create Article");
    // return View(article);
  }
  
}