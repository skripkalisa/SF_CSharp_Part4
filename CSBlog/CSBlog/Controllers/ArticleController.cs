using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSBlog.Data;
using CSBlog.Models.Blog;


namespace CSBlog.Controllers
{
  public class ArticleController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ArticleController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Article
    public async Task<IActionResult> Index()
    {
      return View(await _context.Articles.ToListAsync());
    }

    // GET: Article/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var article = await _context.Articles
        .FirstOrDefaultAsync(m => m.Id == id);
      if (article == null)
      {
        return NotFound();
      }

      return View(article);
    }

    // GET: Article/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Article/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Text")] Article article)
    {
      // return Json(article);
      var currentUser = GetUser(out var currentUserId);

      if (ModelState.IsValid)
      {
        article.UserId = Guid.Parse(currentUserId ?? string.Empty);
        article.Author = currentUser.FindFirst(ClaimTypes.Name)?.Value;
        article.Id = Guid.NewGuid();
        article.Published = DateTime.Now;
        article.Comments = new List<Comment>();
        article.Tags = new List<Tag>();
        _context.Add(article);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        // return Json(article);
      }

      GetErrors();
      // return new StatusCodeResult(500);

      return View(article);
    }

    private void GetErrors()
    {
      var message = string.Join(" | ", ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
      Console.WriteLine(message);
    }

    private ClaimsPrincipal GetUser(out string? currentUserId)
    {
      ClaimsPrincipal currentUser = User;
      currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      Console.WriteLine($"currentUserID: {currentUserId}");
      return currentUser;
    }

    // GET: Article/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var article = await _context.Articles.FindAsync(id);
      if (article == null)
      {
        return NotFound();
      }

      return View(article);
    }

    // POST: Article/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Title,Text")] Article data)
    {
      var article = await _context.Articles.FindAsync(id);
      if (ModelState.IsValid)
      {
        Debug.Assert(article != null, nameof(article) + " != null");
        article.Edited = DateTime.Now;
        article.Title = data.Title;
        article.Text = data.Text;
        _context.Update(article);
        await _context.SaveChangesAsync();
        GetErrors();

        return RedirectToAction(nameof(Index));
      }

      return View(article);
    }

    // GET: Article/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var article = await _context.Articles
        .FirstOrDefaultAsync(m => m.Id == id);
      if (article == null)
      {
        return NotFound();
      }

      return View(article);
    }

    // POST: Article/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      var article = await _context.Articles.FindAsync(id);
      if (article != null)
      {
        _context.Articles.Remove(article);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ArticleExists(Guid id)
    {
      return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}