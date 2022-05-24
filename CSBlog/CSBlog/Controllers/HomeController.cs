using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSBlog.Models;

namespace CSBlog.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
    _logger.LogDebug(1, "NLog injected into HomeController");
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Privacy()
  {
    _logger.LogInformation("Hello, this is Privacy page!");
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}