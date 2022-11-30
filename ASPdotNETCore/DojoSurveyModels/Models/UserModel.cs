#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyModels.Models;
public class User
{


    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage = "Name must be longer than 2 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Favorite Language is required.")]
    public string FavLang { get; set; }

     [MinLength(20, ErrorMessage = "Comment must be at least 20 characters")]
    public string? Comment { get; set; }



}