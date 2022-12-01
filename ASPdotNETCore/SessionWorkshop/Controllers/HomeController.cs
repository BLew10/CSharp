using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {

        return View();
    }

    [HttpGet("game")]
    public IActionResult Game()
    {
        HttpContext.Session.SetInt32("total", 22);
        return View();
    }

    [HttpPost("operation")]
    public IActionResult Operation(string op)
    {

        int? NewTotal = HttpContext.Session.GetInt32("total");
        if (op == "add")
        {
            NewTotal += 1;
        }
        else if (op == "minus")
        {
            NewTotal -= 1;
        }
        else if (op == "multiply")
        {
            NewTotal *= 2;
        }
        else
        {
            Random rand = new Random();
            int randNum = rand.Next(1, 11);
            NewTotal += randNum;
        }
        HttpContext.Session.SetInt32("total", (int)NewTotal);
        return View("Game");
    }



    [HttpPost("login")]
    public IActionResult Submit(string name)
    {
        Console.WriteLine(name);
        HttpContext.Session.SetString("Name", name);
        HttpContext.Session.SetInt32("total", 22);
        Console.WriteLine(HttpContext.Session.GetString("Name"));

        return View("Game");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

    void AddOne(Object sender, EventArgs e)
    {

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
