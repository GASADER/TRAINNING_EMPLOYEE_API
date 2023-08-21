using TRAINNING_EMPLOYEE_API.Controllers;
using TRAINNING_EMPLOYEE_API.Services;
using Xunit;

namespace TRAINNING_EMPLOYEE_API.Tests
{
    public class UnitTest
    {
        // [Fact]
        // public void ReturnGetAll()
        // {
        //     List<UserResponse> expect  = new List<UserResponse>(){

        //     };
        //     UserController userController = new UserController();

        //     List<UserResponse> result = userController.GetAllUsers();

        //     Assert.Equal(expect,result);
        // }

        // [Fact]
        // public void Given_2000_Return_23_CalculateAge()
        // {
            
        //     UserService userService = new UserService();
        //     int YearOfBirth = 2000;
        //     int expect = 23;
        //     int result = userService.CalculateAge(YearOfBirth);

        //     Assert.Equal(expect,result);
        // }

        [Fact]
        public void Given_2and4_Return_6_Add()
        {
            int expect = 6;
            int result = Add(2,4);
            Assert.Equal(expect,result);
        }

        int Add(int x ,int y){
            return x + y;
        }
    }
}