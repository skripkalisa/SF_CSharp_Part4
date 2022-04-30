using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class ArticleController: Controller
{  
  private readonly IRepository<Article> _repo;
  
  public ArticleController(IRepository<Article> repo)
  {
    _repo = repo;
  }

  // GET
  public IActionResult Index()
  {
    // return View();
    return Content("Article");
  }
  
  // [Authorize]
  // [HttpPost]
  // public async Task<IActionResult> Create(Article article)
  // {
  //   await _repo.Create(article);
  //   return Content("Article");
  //   // return View(article);
  // }
  
}