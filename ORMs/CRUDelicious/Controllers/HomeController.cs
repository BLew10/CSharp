using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult AllDishes()
    {
        ViewBag.AllDishes = _context.Dishes.Include(c => c.Chef).ToList();
        return View();
    }

    [HttpGet("chefs")]
    public IActionResult AllChefs()
    {
        ViewBag.AllChefs = _context.Chefs.Include(dishes => dishes.CreatedDishes).ToList();
        return View();
    }
    [HttpGet("dish/new")]
    public IActionResult CreateDishForm()
    {
        MyViewModel AllChefs = new MyViewModel
        {
            AllChefs = _context.Chefs.Include(d => d.CreatedDishes).ToList()
        };

        return View(AllChefs);
    }

        [HttpGet("chef/new")]
    public IActionResult CreateChefForm()
    {

        return View();
    }

    [HttpGet("dish/{DishId}")]
    public IActionResult SingleDish(int DishId)
    {
        Dish? displayDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);

        return View(displayDish);
    }

    [HttpGet("dish/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        Dish? updateDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);

        return View(updateDish);
    }

    [HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine(newDish.ChefId);
            Console.WriteLine(newDish.Name);
            Console.WriteLine(newDish.Description);
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("AllDishes");
        }

        else
        {
            MyViewModel AllChefs = new MyViewModel
            {
                AllChefs = _context.Chefs.ToList()
            };
            return View("CreateDishForm", AllChefs);
        }
    }

        [HttpPost("chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
           
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("AllChefs");
        }

        else
        {

            return View("CreateChefForm");
        }
    }

    [HttpPost("dish/{DishId}/delete")]
    public IActionResult DeleteDish(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);

        _context.Dishes.Remove(DishToDelete);

        _context.SaveChanges();

        return RedirectToAction("AllDishes");
    }

    [HttpPost("dish/{DishId}/update")]
    public IActionResult UpdateDish(Dish updateDish, int DishId)
    {

        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        if (ModelState.IsValid)
        {

            OldDish.Name = updateDish.Name;
            OldDish.Chef = updateDish.Chef;
            OldDish.Calories = updateDish.Calories;
            OldDish.Description = updateDish.Description;
            OldDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("AllDishes");
        }

        else
        {
            return View("EditDish", OldDish);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
