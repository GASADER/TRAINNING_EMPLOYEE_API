namespace TRAINNING_EMPLOYEE_API.Models;
public class Phone
{
    public int PhoneId { get; set; }
    public string PhoneNumber { get; set; } = "";
    public int UserId { get; set; }
    public User User { get; set; } = new User();
}