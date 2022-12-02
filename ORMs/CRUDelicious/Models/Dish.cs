#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;

public class Dish 
{
    [Key]
    
    public int DishId { get; set; }
    
    public int ChefId{ get; set; }

    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; } 



    [Required]
    public int Calories { get; set; }
    [Required]
    public string Description { get; set; }

    public Chef? Chef { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



}