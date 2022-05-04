using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class TagController : Controller
{
  private readonly IBlogRepository _repo;

  public TagController(IBlogRepository repo)
  {
    _repo = repo;
  }
  // GET

  public async Task<IActionResult> Index()
  {
    await _repo.GetAllTags();
    // return View();
    return Content("Tags");
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> Create(Tag tag)
  {
    await _repo.AddTag(tag);
    return Content("Create Tag");
    // return View(Tag);
  }  
  
  [Authorize]
  [HttpPost]
  public async Task<IActionResult> Edit(Tag tag)
  {
    await _repo.EditTag(tag);
    return Content("Edit Tag");
    // return View(Tag);
  }  
  
  [Authorize]
  [HttpPost]
  public async Task<IActionResult> Delete(Guid tagId)
  {
    await _repo.DeleteTag(tagId);
    return Content("Delete Tag");
    // return View(Tag);
  }
  
  [HttpGet]
  public  IActionResult GetBy(Guid tagId)
  {
    var tag =   _repo.GetTagById(tagId);
    // return View();
    return Content("Tag by ID");
  }
}