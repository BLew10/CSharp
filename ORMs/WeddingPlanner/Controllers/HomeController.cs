
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
namespace WeddingPlanner.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;
    }


    [HttpGet("")]
    public IActionResult LoginRegister()
    {
        return View();
    }

    [SessionCheck]
    [HttpGet("plan")]
    public IActionResult PlanWedding()
    {
        return View();
    }


    [HttpPost("user/create")]
    public IActionResult Register(User newUser)
    {

        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            // Updating our newUser's password to a hashed version         
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("AllWeddings");
        }

        else
        {
            Console.WriteLine("Invalid");
            return View("LoginRegister");
        }
    }

    [SessionCheck]
    [HttpPost("wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {

        if (ModelState.IsValid)
        {

            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return Redirect($"/wedding/{newWedding.WeddingId}");
        }

        else
        {
            return View("PlanWedding");
        }
    }



    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult AllWeddings()
    {

        MyViewModel AllWeddingInfo = new MyViewModel
        {
            AllWeddings = _context.Weddings.Include(a => a.GuestList).ToList(),
        };

        return View(AllWeddingInfo);
    }

    [SessionCheck]
    [HttpPost("association/{AssociationId}/delete")]
    public IActionResult DeleteAssociation(int AssociationId)
    {
        Association? AssociationToDelete = _context.Associations.FirstOrDefault(a => a.AssociationId == AssociationId);

        _context.Associations.Remove(AssociationToDelete);

        _context.SaveChanges();

        return RedirectToAction("AllWeddings");
    }

    [SessionCheck]
    [HttpPost("association/create")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if (ModelState.IsValid)
        {
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("AllWeddings");
        }

        else
        {
            return View("AllWeddings");
        }

    }

    [SessionCheck]
    [HttpGet("wedding/{WeddingId}")]
    public IActionResult DisplayWedding(int WeddingId)
    {

        Wedding? DisplayWedding = _context.Weddings.Include(a => a.GuestList).ThenInclude(a => a.User).FirstOrDefault(c => c.WeddingId == WeddingId);

        MyViewModel CurrentWedding = new MyViewModel
        {
            GuestList = DisplayWedding.GuestList.ToList(),
            Wedding = DisplayWedding
        };

        return View(CurrentWedding);
    }

    [SessionCheck]
    [HttpPost("wedding/{WeddingId}/delete")]
    public IActionResult DeleteWedding(int WeddingId)
    {
        Wedding? WeddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId);

        _context.Weddings.Remove(WeddingToDelete);

        _context.SaveChanges();

        return RedirectToAction("AllWeddings");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            // If initial ModelState is valid, query for a user with the provided email        
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
            // If no user exists with the provided email        
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!            
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return View("LoginRegister");
            }
            // Otherwise, we have a user, now we need to check their password                 
            // Initialize hasher object        
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            // Verify provided password against hash stored in db        
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LogPassword);                                    // Result can be compared to 0 for failure        
            if (result == 0)
            {
                ModelState.AddModelError("LogPassword", "Invalid Email/Password");
                return View("LoginRegister");// Handle failure (this should be similar to how "existing email" is handled)        
            }

            // Surrounding registration code
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("AllWeddings");
            // Surrounding registration code

            // Handle success (this should route to an internal page)  
        }
        else
        {
            // Handle else
            return View("LoginRegister");
        }
    }



    [HttpPost("logout")]
    public IActionResult Logout()
    {

        // Handle else
        HttpContext.Session.Clear();
        return View("LoginRegister");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        // Check to see if we got back null
        if (userId == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("LoginRegister", "Home", null);
        }
    }
}