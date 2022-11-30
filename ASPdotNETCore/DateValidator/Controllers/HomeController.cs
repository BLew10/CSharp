using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public static User user;

    [HttpGet("")]
    public IActionResult Form()
    {
        return View();
    }
    
    [HttpGet("success")]
        public IActionResult Success()
    {
        return View();
    }

    [HttpPost("submit")]
    public IActionResult Submit(User NewUser)
    {
        if (ModelState.IsValid)
        {
            user = NewUser;

            return RedirectToAction("Success");
        }
        else
        {
            return View("Form");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
