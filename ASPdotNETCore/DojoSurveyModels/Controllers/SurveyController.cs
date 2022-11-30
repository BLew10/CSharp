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

    public static User user;

[HttpGet("")]
    public IActionResult Form()
    {
        return View();
    }

[HttpGet("/result")]
    public IActionResult Result()
    {
        return View(user);
    }


    [HttpPost("/user/create")]
    public IActionResult Create(User NewUser)
    {

        if(ModelState.IsValid)
        {
            user = NewUser;
        
            return RedirectToAction("Result");
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
