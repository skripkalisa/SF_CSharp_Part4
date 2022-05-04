using CSBlog.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class RoleController : Controller
{
  private readonly RoleManager<IdentityRole> _roleManager;

  // GET
  public RoleController(RoleManager<IdentityRole> roleManager)
  {
    _roleManager = roleManager;
  }

  public IActionResult Index()
  {
    return Content("Roles");
    // return View();
  }

  [Authorize(Roles = "Administrator")]
  public IActionResult Create()
  {
    return Content("Role Create get");
    // return View();
  }

  [Authorize(Roles = "Administrator")]
  [HttpPost]
  public async Task<IActionResult> Create(UserRole userRole)
  {
    var roleExists = await _roleManager.RoleExistsAsync(userRole.Role);
    if (!roleExists)
    {
      var result = await _roleManager.CreateAsync(new IdentityRole(userRole.Role));
    }

    return Content("Role Create post");
    // return View();
  }

  [Authorize(Roles = "Administrator")]
  public IActionResult Edit()
  {
    return Content("Role Create get");
    // return View();
  }

  [Authorize(Roles = "Administrator")]
  [HttpPost]
  public async Task<IActionResult> Edit(UserRole userRole)
  {
    var role = await _roleManager.FindByNameAsync(userRole.Role);
    if (role != null && userRole.Role != string.Empty)
    {
      role.Name = userRole.Role;
      await _roleManager.UpdateAsync(role);
    }

    return Content("Role Create post");
    // return View();
  }  
  
  [Authorize(Roles = "Administrator")]
  [HttpPost]
  public async Task<IActionResult> Delete(UserRole userRole)
  {
    var role = await _roleManager.FindByNameAsync(userRole.Role);
    if (role != null)
    {

      await _roleManager.DeleteAsync(role);
    }

    return Content("Role Create post");
    // return View();
  }
}