#pragma warning disable CS8618
namespace CSharpTest.Models;
public class MyViewModel
{    
    public LoginUser LoginUser {get;set;}    
    public User User {get;set;}
    public Project Project {get;set;}

    public int AllFundsRaised {get;set;}

    public int CompletelyFunded {get;set;}

    public int TotalSupporters {get;set;}
    public List<User> AllUsers {get;set;}
    public List<Project> AllProjects {get;set;}


    
}
