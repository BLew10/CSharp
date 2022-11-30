using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;
#pragma warning disable CS8618


public class OddNumber : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        if((int)value % 2 == 0)
        {
            return new ValidationResult("This number is even you dimwit");
        }
        else 
        {
            return ValidationResult.Success;
        }
    }
}