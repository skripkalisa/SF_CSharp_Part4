using CSBlog.Core.Repository;
using CSBlog.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : Controller
{
  // GET

  private readonly IUnitOfWork _unitOfWork;

  public TagController(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  public IActionResult Index()
  {
    return View();
  }
    
  // [HttpGet(Name = "GetTag")]
  public IEnumerable<Tag> Get()
  {
    return _unitOfWork.Tag.GetAll()
      .ToArray();
  }
  
}