// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Countdown.Controllers;
public class Countdown : Controller   // Remember inheritance?    
{
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public ViewResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        DateTime Christmas = new DateTime(2022, 12, 25, 7, 0, 0, DateTimeKind.Local);
        ViewBag.DaysDifference = (Christmas - CurrentTime).Days;
        ViewBag.HoursDifference = (Christmas - CurrentTime).Hours;
        ViewBag.MinutesDifference = (Christmas - CurrentTime).Minutes;
        ViewBag.Date = CurrentTime;
        ViewBag.Christmas = Christmas;

        return View("Index");
    }

}

