namespace TRAINNING_EMPLOYEE_API.Models;
public class UserResponse
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int YearOfBirth { get; set; }
    public int Age {get; set;}
    public List<string> Phones { get; set; } = new List<string>();
}