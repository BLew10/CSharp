// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace ExampleProject.Controllers;   
public class HelloController : Controller   // Remember inheritance?    
{      
    [HttpGet] // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public ViewResult Index()        
    {            
    	return View();        
    }    

    [HttpGet("greet/{name}")]

    public string Greet(string name)
    {
        return $"Hello {name}";
    }
}

