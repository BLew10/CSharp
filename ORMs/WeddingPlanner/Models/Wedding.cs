#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class Wedding
{    
    [Key]    
    public int WeddingId { get; set; }

    [Required]
    public int Creator { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]    
    public string WedderOne { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]        
    public string WedderTwo { get; set; }     
    
    [Required (ErrorMessage = "This is not a valid date")]
    public DateTime Date { get; set; }    
    
    [Required]
    public string Address { get; set; } 
    
    public List <Association> GuestList { get; set; }  = new List<Association>();
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}