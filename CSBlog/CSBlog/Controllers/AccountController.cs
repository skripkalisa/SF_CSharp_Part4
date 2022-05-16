using CSBlog.Services;
using CSBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSBlog.Controllers;

public class AccountController : Controller
{
  private readonly Auth _auth;

  public AccountController(Auth auth)
  {
    _auth = auth;
  }

  public IActionResult Login(string? returnUrl = null)
  {
    ViewData["ReturnUrl"] = returnUrl;
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Login(AccountLogin model, string? returnUrl = null)
  {
    ViewData["ReturnUrl"] = returnUrl;
    if (ModelState.IsValid)
    {
      var loggedIn = _auth.SignIn(model.Email, model.Password);

      // Console.WriteLine($"Logged In: {loggedIn}");
      
      if (loggedIn)
      {
        
        return RedirectToLocal(returnUrl);
      }
      else
      {
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
      }
    }

    return View(model);
  }

  public IActionResult Logout()
  {
    _auth.SignOut();
    return RedirectToAction("Index", "Home");
  }

  private IActionResult RedirectToLocal(string? returnUrl)
  {
    if (Url.IsLocalUrl(returnUrl))
    {
      return Redirect(returnUrl);
    }
    else
    {
      return RedirectToAction(nameof(HomeController.Index), "Home");
    }
  }
}