using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;
#pragma warning disable CS8618


public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        if(DateTime.Compare((DateTime)value, DateTime.Now) > 0)
        {
            return new ValidationResult(" Birthdate Submitted is Past the Current Date");
        }
        else 
        {
            return ValidationResult.Success;
        }
    }
}
