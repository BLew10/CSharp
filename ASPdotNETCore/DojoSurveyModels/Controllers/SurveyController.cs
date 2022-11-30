using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModels.Models;

namespace DojoSurveyModels.Controllers;

public class SurveyController : Controller
{
    private readonly ILogger<SurveyController> _logger;

    public SurveyController(ILogger<SurveyController> logger)
    {
        _logger = logger;
    }

[HttpGet("")]
    public IActionResult Form()
    {
        return View();
    }

[HttpGet("/result")]
    public IActionResult Result(User user)
    {
        // Dictionary<string, string> UserInfo = new Dictionary<string,string>{{"Name", Name}, {"Location", Location}, {"Favorite Language", FavLang}, {"Comment", Comment}};
        Console.WriteLine(user);

        return View(user);
    }


    [HttpPost("/user/create")]
    public IActionResult Create(User user)
    {

        if(ModelState.IsValid)
        {
            return View("Result", user);
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
