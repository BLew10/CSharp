using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelFun.Models;

namespace ModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Message()
    {
        string message = "Hello, I hope this works";
        return View("Message",message);
    }

    [HttpGet("/numbers")]
    public IActionResult Numbers()
    {
        List<int> numbers = new List<int>{1,2,3,4,5};
        return View(numbers);
    }
    [HttpGet("/user")]
    public IActionResult User()
    {
        string user = "Brandon Lewis";
        return View("User",user);
    }
    [HttpGet("/users")]
    public IActionResult Users()
    {
        List<string> users = new List<string>{"Kylie", "des", "tevenn"};
        return View(users);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
