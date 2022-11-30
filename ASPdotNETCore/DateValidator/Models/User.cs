#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class User
{


    [FutureDateAttribute]
    public DateTime date { get; set; }



}