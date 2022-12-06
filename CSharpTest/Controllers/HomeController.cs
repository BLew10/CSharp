
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using CSharpTest.Models;
using Microsoft.AspNetCore.Identity;
namespace CSharpTest.Controllers;


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
    [HttpGet("start")]
    public IActionResult PlanProject()
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
            return RedirectToAction("AllProjects");
        }

        else
        {
            return View("LoginRegister");
        }
    }

    [SessionCheck]
    [HttpPost("project/create")]
    public IActionResult CreateProject(Project newProject)
    {

        if (ModelState.IsValid)
        {
            _context.Projects.Add(newProject);
            _context.SaveChanges();
            return Redirect($"/project/{newProject.ProjectId}");
        }

        else
        {
            return View("PlanProject");
        }
    }



    [SessionCheck]
    [HttpGet("projects")]
    public IActionResult AllProjects()
    {
        _context.Projects.Include(p => p.Creator).ToList();
        MyViewModel AllProjectInfo = new MyViewModel
        {
            TotalSupporters = _context.Projects.Sum(p => p.Supporters),
            AllFundsRaised = _context.Projects.Sum(p => p.Total),
            CompletelyFunded = _context.Projects.Where(p => p.Total > p.Goal).ToList().Count,
            AllProjects = _context.Projects.Include(p => p.Creator).ToList(),
        };
        foreach(Project project in AllProjectInfo.AllProjects)
        {
            Console.WriteLine((int)project.Total);
            Console.WriteLine(project.Goal);
            decimal percent = Math.Floor(((decimal)project.Total/(decimal)project.Goal) * 100);
            Console.WriteLine(percent);
        }

        return View(AllProjectInfo);
    }


    [SessionCheck]
    [HttpGet("project/{ProjectId}")]
    public IActionResult DisplayProject(int ProjectId)
    {
        //grabs users associated with object : change guest list
        Project? DisplayProject = _context.Projects.Include(a => a.Creator).FirstOrDefault(c => c.ProjectId == ProjectId);

        if((DisplayProject.EndDate - DateTime.Now).Days > 0)
        {
            Console.WriteLine("Days");
        ViewBag.TimeTil = $"{(DisplayProject.EndDate - DateTime.Now).Days} Days";

        }
        else if((DisplayProject.EndDate - DateTime.Now).Days <= 0 && (DisplayProject.EndDate - DateTime.Now).Hours > 0)
        {
            Console.WriteLine("Hours");
            ViewBag.TimeTil = $"{(DisplayProject.EndDate - DateTime.Now).Hours} Hours";
        } else {
            Console.WriteLine("Minutes");
            ViewBag.TimeTil = $"{(DisplayProject.EndDate - DateTime.Now).Minutes} Minutes";
        }

        

        return View(DisplayProject);
    }

    [SessionCheck]
    [HttpPost("project/{ProjectId}/delete")]
    public IActionResult DeleteProject(int ProjectId)
    {
        Project? ProjectToDelete = _context.Projects.FirstOrDefault(w => w.ProjectId == ProjectId);

        _context.Projects.Remove(ProjectToDelete);

        _context.SaveChanges();

        return RedirectToAction("AllProjects");
    }

    [HttpPost("project/{ProjectId}/update")]
    public IActionResult UpdateProject(Project updateProject, int ProjectId)
    {

        Project? OldProject = _context.Projects.FirstOrDefault(d => d.ProjectId == ProjectId);

            OldProject.Total += updateProject.Total;
            OldProject.Supporters += 1;
            OldProject.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("AllProjects");

    }


    [HttpPost("login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine("here");
            // If initial ModelState is valid, query for a user with the provided email        
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LogEmail);
            // If no user exists with the provided email        
            if (userInDb == null)
            {
                Console.WriteLine("here");
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
                ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                return View("LoginRegister");// Handle failure (this should be similar to how "existing email" is handled)        
            }

            // Surrounding registration code
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("AllProjects");
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