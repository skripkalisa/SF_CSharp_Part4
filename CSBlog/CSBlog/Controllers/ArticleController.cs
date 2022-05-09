using CSBlog.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

// [Authorize(Policy = "User")]
public class ArticleController: Controller
{  
  private readonly IBlogRepository _repo;
  
  public ArticleController(IBlogRepository repo)
  {
    _repo = repo;
  }

  // GET
  [AllowAnonymous]
  public async Task<IActionResult> Index()
  {
    await _repo.GetAllArticles();
    return View();
    // return Content("Article");
  }


  [HttpGet]
  public  IActionResult Create()
  {
    return View();
  }  
  
  [HttpPost]
  public async Task<IActionResult> Create(Article article)
  {
    await _repo.AddArticle(article);
    return Content("Create Article");
    // return View(article);
  }  
  

  [HttpPost]
  public async Task<IActionResult> Edit(Article article)
  {
    await _repo.EditArticle(article);
    return Content("Edit Article");
    // return View(article);
  }  
  

  [HttpPost]
  public async Task<IActionResult> Delete(Guid articleId)
  {
    await _repo.DeleteArticle(articleId);
    return Content("Delete Article");
    // return View(article);
  }
  
  [HttpGet]
    public async Task<IActionResult> GetBy(Guid authorId)
    {
      var articles =  await _repo.GetArticlesByAuthor(authorId);
    // return View();
    return Content("Articles by author");
  }
}