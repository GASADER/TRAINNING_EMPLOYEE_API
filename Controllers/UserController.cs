using Microsoft.AspNetCore.Mvc;
using TRAINNING_EMPLOYEE_API.Models;
using TRAINNING_EMPLOYEE_API.Services;
using TRAINNING_EMPLOYEE_API.Repositories;

namespace TRAINNING_EMPLOYEE_API.Controllers; //บอกว่าไฟล์นี้มาจากfolderอะไร

[ApiController]
[Route("api/users")] //เรียกใช้งาน api ที่pathไหน
public class UserController : ControllerBase
{
    private readonly UserDBContext _userDBContext;

    public UserController(UserDBContext dBContext)
    {
        _userDBContext = dBContext;
    }
    // https://localhost:5299/api/users
    [HttpGet("help")] //ใช้งาน method get ที่ path
    public IActionResult GetHelp()
    {

        User user = new User();
        UserService userService = new UserService(_userDBContext);


        user.FirstName = "Josave";
        user.LastName = "SEC";
        user.YearOfBirth = 1990;
        user.Age = userService.CalculateAge(user.YearOfBirth);
        return Ok(user);
    }

    [HttpGet("")]
    public IActionResult GetAllUsers() 
    {
        UserService userService = new UserService(_userDBContext);
        List<User> user = userService.GetAll();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userDBContext.users.FirstOrDefault(u => u.UserId == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost("")]

    public IActionResult PostUser([FromBody] User userInput)
    {
        if (userInput == null)
        {
            return BadRequest("Invalid Data");
        }
        UserService userService = new UserService(_userDBContext);
        userService.PostUser(userInput);

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult EditUser(int id, [FromBody] User userInput)
    {
        if (userInput == null)
        {
            return BadRequest("Invalid Data");
        }

        var editingUser = _userDBContext.users.FirstOrDefault(u => u.UserId == id);
        if (editingUser == null)
        {
            return NotFound();
        }

        editingUser.FirstName = userInput.FirstName;
        editingUser.LastName = userInput.LastName;
        editingUser.YearOfBirth = userInput.YearOfBirth;

        _userDBContext.SaveChanges();

        UserService userService = new UserService(_userDBContext);
        editingUser.Age = userService.CalculateAge(editingUser.YearOfBirth);
        _userDBContext.SaveChanges();

        return Ok(editingUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {

        var deletedUser = _userDBContext.users.FirstOrDefault(u => u.UserId == id);
        if (deletedUser == null)
        {
            return NotFound();
        }
        _userDBContext.users.Remove(deletedUser);
        _userDBContext.SaveChanges();

        return NoContent();
    }
}