#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CSharpTest.Models;
public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public User? Creator { get; set; }
    [Required]
    public int UserId { get; set; }


    [Required]
    public string Title { get; set; }

    [Required]
    [MinLength(20, ErrorMessage = "Description must be at least 20 characters")]
    public string Description { get; set; }

    [Required]
    [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]  
    [FutureDateAttribute]

    public DateTime EndDate { get; set; }

    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "Goal must be a positive value")]
    public int Goal { get; set; }

    [Required]
    public int Total { get; set; }

    [Required]
    public int Supporters { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}