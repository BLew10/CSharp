using System.ComponentModel.DataAnnotations;
namespace CSharpTest.Models;
#pragma warning disable CS8618


public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        if(DateTime.Compare((DateTime)value, DateTime.Now) < 0)
        {
            return new ValidationResult("The Date Submitted is Must Be In the Future");
        }
        else 
        {
            return ValidationResult.Success;
        }
    }
}
