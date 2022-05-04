using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

[Authorize(Policy = "User")]
public class CommentController : Controller
{
  
    private readonly IBlogRepository _repo;

    public CommentController(IBlogRepository repo)
    {
      _repo = repo;
    }
    // GET
[AllowAnonymous]
  public async Task<IActionResult> Index()
  {
    await _repo.GetAllComments();
    // return View();
    return Content("Comments");
  }


  [HttpPost]
  public async Task<IActionResult> Create(Comment comment)
  {
    await _repo.AddComment(comment);
    return Content("Create Comment");
    // return View(Comment);
  }  
  

  [HttpPost]
  public async Task<IActionResult> Edit(Comment comment)
  {
    await _repo.EditComment(comment);
    return Content("Edit Comment");
    // return View(Comment);
  }  
  

  [HttpPost]
  public async Task<IActionResult> Delete(Guid commentId)
  {
    await _repo.DeleteComment(commentId);
    return Content("Delete Comment");
    // return View(Comment);
  }
  
  [HttpGet]
  public  IActionResult GetBy(Guid commentId)
  {
    var comment =   _repo.GetCommentById(commentId);
    // return View();
    return Content("Comment by ID");
  }
}