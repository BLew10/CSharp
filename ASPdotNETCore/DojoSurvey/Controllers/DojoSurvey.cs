// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurvey.Controllers;
public class DojoSurvey : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public IActionResult Form()
    {
        return View("Form");
    }



    // [HttpGet("results")]
    // public IActionResult Results(string Name, string Location, string FavLang, string Comment = "")
    // {
    //     @ViewBag.Name = Name;
    //     @ViewBag.Location = Location;
    //     @ViewBag.FavLang = FavLang;
    //     @ViewBag.Comment = Comment;

    //     return View("Results");
    // }

    [HttpPost("results")]
    public IActionResult Results(string Name, string Location, string FavLang, string Comment = "")
    {
        @ViewBag.Name = Name;
        @ViewBag.Location = Location;
        @ViewBag.FavLang = FavLang;
        @ViewBag.Comment = Comment;

        return View("Results");
    }

}

