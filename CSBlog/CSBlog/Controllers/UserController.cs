using CSBlog.Data.Repository;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace CSBlog.Controllers;

[Authorize(Policy = "Moderator")]
public class UserController : Controller
{
  private readonly IUserRepository _repo;

  public UserController(IUserRepository repo)
  {
    _repo = repo;
  }

  [Authorize(Policy = "User")]
  public async Task<IActionResult> Index()
  {
    await _repo.GetAllUsers();
    // return View();
    return Content("Users");
  }

  [AllowAnonymous]
  [HttpGet]
  public IActionResult Register()
  {
    // return View();
    return Content("Register GET");
  }

  [AllowAnonymous]
  [HttpPost]
  public async Task<IActionResult> Register(User user)
  {
    await _repo.AddUser(user);
    // return View();
    return Content("Register POST");
  }

  [HttpPost]
  [Authorize(Policy = "User")]
  public async Task<IActionResult> Edit(User user)
  {
    await _repo.EditUser(user);
    return Content("Edit user");
  }


  [HttpPost]
  public async Task<IActionResult> Delete(Guid userId)
  {
    await _repo.DeleteUser(userId);
    return Content("Delete user");
  }

  [HttpGet]
  [Authorize(Policy = "User")]
  public IActionResult GetBy(string userId)
  {
    var user = _repo.GetUserById(userId);

    // return View();
    return Content("User by ID");
  }
}