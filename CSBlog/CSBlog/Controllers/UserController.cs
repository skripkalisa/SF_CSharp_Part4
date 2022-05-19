using System.Diagnostics;
using CSBlog.Core.Repository;
using CSBlog.Core.ViewModels;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSBlog.Controllers;

public class UserController : Controller
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly SignInManager<BlogUser> _signInManager;

  public UserController(IUnitOfWork unitOfWork, SignInManager<BlogUser> signInManager)
  {
    _unitOfWork = unitOfWork;
    _signInManager = signInManager;
  }

  // GET
  public IActionResult Index()
  {
    var users = _unitOfWork.User.GetUsers();
    return View(users);
  }

  [HttpGet]
  public async Task<IActionResult> Edit(string id)
  {
    var user = _unitOfWork.User.GetUserById(id);

    var roles = _unitOfWork.Role.GetRoles();

    Debug.Assert(user != null, nameof(user) + " != null");
    var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

    var roleListItems = roles.Select(role =>
      new SelectListItem(
        role.Name,
        role.Id,
        userRoles.Any(ur => ur.Contains(role.Name)))).ToList();


    var vm = new EditUserViewModel
    {
      BlogUser = user,
      UserRoles = roleListItems
    };

    return View(vm);
  }

  [HttpPost]
  public async Task<IActionResult> Edit(EditUserViewModel data)
  {
    if (ModelState.IsValid)
    {
      var user = _unitOfWork.User.GetUserById(data.BlogUser.Id);
      if (user == null)
      {
        return NotFound();
      }

      user.FirstName = data.BlogUser.FirstName;
      user.LastName = data.BlogUser.LastName;
      user.Email = data.BlogUser.Email;
      List<string> rolesToAdd = new();
      List<string> rolesToRemove = new();

      var userRoles = await _signInManager.UserManager.GetRolesAsync(user);
      foreach (var role in data.UserRoles)
      {
        // var existingRole = userRoles.FirstOrDefault(ur => ur == role.Text);
        if (role.Selected && !userRoles.Contains(role.Text)) rolesToAdd.Add(role.Text);
         if (!role.Selected && userRoles.Contains(role.Text)) rolesToRemove.Add(role.Text);
      }

      if (rolesToAdd.Any())
      {
        await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
      }

      if (rolesToRemove.Any())
      {
        await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToRemove);
      }
      user.Updated = DateTime.Now;

      _unitOfWork.User.UpdateUser(user);

      // foreach (var role in userRoles)
      // {
      //   if (!user.UserRoleList.Contains(role))
      //     user.UserRoleList.Add(role);
      // }

      // return View(data);
      return RedirectToAction("Index");
    }

    // return Json(data);
    return View(data);
  }
}