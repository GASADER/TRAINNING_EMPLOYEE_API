using Microsoft.AspNetCore.Mvc;
using TRAINNING_EMPLOYEE_API.Models;
using TRAINNING_EMPLOYEE_API.Services;

namespace TRAINNING_EMPLOYEE_API.Controllers; //บอกว่าไฟล์นี้มาจากfolderอะไร

[ApiController]
[Route("api/users")] //เรียกใช้งาน api ที่pathไหน
public class UserController : ControllerBase
{
    // https://localhost:5299/api/users
    [HttpGet("")] //ใช้งาน method get ที่ path
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
}