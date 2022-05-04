using CSBlog.Data.Repository;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class UserController : Controller
{
  private readonly IUserRepository _repo;

  public UserController(IUserRepository repo)
  {
    _repo = repo;
  }

  // GET
  public async Task<IActionResult> Index()
  {
    await _repo.GetAllUsers();
    // return View();
    return Content("User");
  }

  [HttpGet]
  public async Task<IActionResult> Register()
  {
    await _repo.GetAllUsers();
    // return View();
    return Content("Register GET");
  }

  [HttpPost]
  public async Task<IActionResult> Register(User user)
  {
    await _repo.AddUser(user);
    // return View();
    return Content("Register POST");
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> Edit(User user)
  {
    await _repo.EditUser(user);
    return Content("Edit user");
  }


  [HttpPost]
  [Authorize(Roles = "Administrator, Moderator")]
  public async Task<IActionResult> Delete(Guid userId)
  {
    await _repo.DeleteUser(userId);
    return Content("Delete user");
  }

  [HttpGet]
  public IActionResult GetBy(Guid userId)
  {
    var user = _repo.GetUserById(userId);
    // return View();
    return Content("User by ID");
  }
}