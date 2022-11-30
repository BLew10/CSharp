#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;
public class User
{


    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Birthday is required.")]
    [FutureDateAttribute]
    public DateTime Birthday { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Comment must be at least 20 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Favorite Odd Number is required")]
    [OddNumber]
    public int OddNum {get;set;}



}