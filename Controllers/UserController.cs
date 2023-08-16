using Microsoft.AspNetCore.Mvc;
using TRAINNING_EMPLOYEE_API.Models;
using TRAINNING_EMPLOYEE_API.Services;

namespace TRAINNING_EMPLOYEE_API.Controllers; //บอกว่าไฟล์นี้มาจากfolderอะไร

[ApiController]
[Route("api/users")] //เรียกใช้งาน api ที่pathไหน
public class UserController : ControllerBase
{
    private readonly UserDBContext _dbContext;

    public UserController(UserDBContext dBContext)
    {
        _dbContext= dBContext;
    }
    // https://localhost:5299/api/users
    [HttpGet("help")] //ใช้งาน method get ที่ path
    public IActionResult GetAllUser()
    {

        User user = new User();
        UserService userService = new UserService();


        user.FirstName = "Josave";
        user.LastName = "SEC";
        user.YearOfBirth = 1990;
        user.Age = userService.CalculateAge(user.YearOfBirth);
        return Ok(user);
    }

    [HttpGet("")]
    public IActionResult GetHelp()
    {
        List<User> user = _dbContext.users.ToList();
        return Ok(user);
    }
    
    [HttpPost("")]

    public IActionResult PostUser([FromBody] User userInput)
    {
        if (userInput == null)
        {
            return BadRequest("Invalid Data");
        }
        UserService userService = new UserService();

        User newUser = new User()
        {
            FirstName = userInput.FirstName,
            LastName = userInput.LastName,
            YearOfBirth = userInput.YearOfBirth,
            Age = userService.CalculateAge(userInput.YearOfBirth)
        };

        _dbContext.users.Add(newUser);
        _dbContext.SaveChanges();

        return Ok();
    }
}