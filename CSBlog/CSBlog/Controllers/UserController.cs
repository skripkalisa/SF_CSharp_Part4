using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSBlog.Data;
using CSBlog.Filters;
using CSBlog.Models.User;
using CSBlog.Services;
using CSBlog.ViewModels;

namespace CSBlog.Controllers;

// [Auth(permissions: "User")]
[Auth]
public class UserController : Controller
{
  private readonly ApplicationDbContext _context;
  private readonly Cryptography _cryptography;
  private readonly Auth _authInfo;

  public UserController(ApplicationDbContext context, Cryptography cryptography, Auth authInfo)
  {
    _context = context;
    _cryptography = cryptography;
    _authInfo = authInfo;
  }

  // GET: User
  public async Task<IActionResult> Index()
  {
    return View(await _context.BlogUsers.ToListAsync());
  }

  // GET: User/Details/5
  public async Task<IActionResult> Details(string id)
  {
    var blogUser = await _context.BlogUsers
      .FirstOrDefaultAsync(m => m.Id == id);
    if (blogUser == null)
    {
      return NotFound();
    }

    return View(blogUser);
  }

  // GET: User/Create
  public IActionResult Create()
  {
    return View();
  }

  // POST: User/Create
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Create(
    [Bind("FirstName,LastName,Email,Password,ConfirmPassword")]
    UserRegister formData)
  {
    Console.WriteLine($"ModelState: {ModelState.IsValid}");
    if (ModelState.IsValid)
    {
      var user = new BlogUser
      {
        FirstName = formData.FirstName,
        LastName = formData.LastName,
        Email = formData.Email,
        Registered = DateTime.UtcNow
      };

      var passwordSalt = Guid.NewGuid().ToString();

      user.SecurityStamp = passwordSalt;
      user.PasswordHash = _cryptography.HashSHA256(formData.Password + passwordSalt);

      _context.Add(user);
      await _context.SaveChangesAsync();
      // return Json(formData);
      return RedirectToAction(nameof(Index));
    }

    // return Json(formData);
    return View(formData);
  }

  // GET: User/Edit/5
  public async Task<IActionResult> Edit(string id)
  {
    var blogUser = await _context.BlogUsers.FindAsync(id);
    if (blogUser == null)
    {
      return NotFound();
    }

    var user = new UserEdit
    {
      LastName = blogUser.LastName,
      FirstName = blogUser.FirstName,
      Email = blogUser.Email
    };

    return View(user);
  }

  // POST: User/Edit/5
  // To protect from overposting attacks, enable the specific properties you want to bind to.
  // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Edit(string id,
    [Bind("FirstName,LastName,Email")] UserEdit formData)
  {
    //
    // Console.WriteLine(id);
    // Console.WriteLine(blogUser.Email);

    if (ModelState.IsValid)
    {
      try
      {
        var blogUser = await GetUserById(id);
        // using (var memoryStream = new MemoryStream())
        if (id != blogUser?.Id)
        {
          return NotFound();
        }

        //   await formData.Avatar?.CopyToAsync(memoryStream);
        // blogUser.Avatar = formData.Avatar;
        blogUser.FirstName = formData.FirstName;
        blogUser.LastName = formData.LastName;
        blogUser.Email = formData.Email;

        blogUser.Updated = DateTime.Now;
        await TryUpdateModelAsync(blogUser);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BlogUserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToAction(nameof(Index));
    }

    GetErrors();
    return View(formData);
  }

  // GET: User/Delete/5
  public async Task<IActionResult> Delete(string id)
  {
    var blogUser = await GetUserById(id);
    if (blogUser == null)
    {
      return NotFound();
    }

    return View(blogUser);
  }

  private async Task<BlogUser?> GetUserById(string id)
  {
    var blogUser = await _context.BlogUsers
      .FirstOrDefaultAsync(m => m.Id == id);
    return blogUser;
  }

  // POST: User/Delete/5
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteConfirmed(string id)
  {
    var blogUser = await _context.BlogUsers.FindAsync(id);
    if (blogUser != null)
    {
      _context.BlogUsers.Remove(blogUser);
    }

    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
  }

  private bool BlogUserExists(string id)
  {
    return _context.BlogUsers.Any(e => e.Id == id);
  }

  private void GetErrors()
  {
    var message = string.Join(" | ", ModelState.Values
      .SelectMany(v => v.Errors)
      .Select(e => e.ErrorMessage));
    Console.WriteLine(message);
  }


  public async Task<bool> CheckEmailExists(string email)
  {
    var currentUser = _authInfo.ScopeAuthInfo;
    var user = await _context.BlogUsers.Where(u => u.Email == email).FirstOrDefaultAsync();
    if (currentUser?.Email == user?.Email) return true;
    return user?.Email != email;
  }


  public async Task<IActionResult> ChangePassword(string? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var user = await _context.BlogUsers.SingleOrDefaultAsync(m => m.Id == id);
    if (user == null)
    {
      return NotFound();
    }

    ViewData["User"] = user;
    return Json(user);
    // return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> ChangePassword(string id, UserChangePassword model)
  {
    if (ModelState.IsValid)
    {
      try
      {
        var userCredential = await _context.BlogUsers.SingleOrDefaultAsync(m => m.Id == id);
        var passwordSalt = Guid.NewGuid().ToString();
        if (userCredential != null)
        {
          userCredential.SecurityStamp = passwordSalt;
          userCredential.PasswordHash = _cryptography.HashSHA256(model.Password + passwordSalt);
        }

        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToAction("Index");
    }

    ViewData["User"] = await _context.BlogUsers.SingleOrDefaultAsync(m => m.Id == id);
    return Json(model);
    // return View(model);
  }


  private bool UserExists(string id)
  {
    return _context.BlogUsers.Any(e => e.Id == id);
  }
}