using Microsoft.EntityFrameworkCore;
using TRAINNING_EMPLOYEE_API.Models;
namespace TRAINNING_EMPLOYEE_API.Repositories;
public class UserRepository
{
    private readonly UserDBContext _userDBContext;
    public UserRepository(UserDBContext userDBContext)
    {
        _userDBContext = userDBContext;
    }
    public List<UserResponse> GetAll()
    {
        List<UserResponse> userResponses = new List<UserResponse>();
        List<User> dbUser = new List<User>();
        dbUser = _userDBContext.users.Include(e => e.Phones).ToList();
        foreach (User user in dbUser)
        {
            UserResponse userResponse = new UserResponse()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                YearOfBirth = user.YearOfBirth,
                Age = user.Age,
            };
            foreach (Phone phone in user.Phones)
            {
                userResponse.Phones.Add(phone.PhoneNumber);
            }
            userResponses.Add(userResponse);
        }
        return userResponses;
    }

    public void PostUser(User user)
    {
        _userDBContext.users.Add(user);
        _userDBContext.SaveChanges();
    }
}