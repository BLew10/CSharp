#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Chef
{    
    [Key]    
    public int ChefId { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]    
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]        
    public string LastName { get; set; }     
    
    [Required]
    public DateTime Birthday {get;set;}

    public List<Dish> CreatedDishes {get; set;} = new List<Dish>();
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}
