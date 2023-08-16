using Microsoft.AspNetCore.Mvc;

namespace TRAINNING_EMPLOYEE_API.Controllers; //บอกว่าอยู่ภายใต้โฟลเดอร์อะไร

[ApiController]         //ทางเข้า api
[Route("api/users")]    //สร้างpath
public class UserController: ControllerBase { //สรา้งclass

    [HttpGet("")]
    public IActionResult GetAllUser(){
        return Ok(new {
            FirstName = "josave" //.net จะเปลี่ยนให้camelcsae
        });
    }
}