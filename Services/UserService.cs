using TRAINNING_EMPLOYEE_API.Models;
using TRAINNING_EMPLOYEE_API.Repositories;

namespace TRAINNING_EMPLOYEE_API.Services;
public class UserService
{

    private readonly UserDBContext _userDBContext;

    public UserService(UserDBContext userDBContext)
    {
        _userDBContext = userDBContext;
    }
    public int CalculateAge(int YearOfBirth)
    {
        return 2023 - YearOfBirth;
    }

    public List<User> GetAll()
    {
        UserRepository userRepository = new UserRepository(_userDBContext);
        List<User> users = userRepository.GetAll();
        return users;
    }

    public void PostUser(User newUser)
    {

        UserRepository userRepository = new UserRepository(_userDBContext);

        User user = new User()
        {
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            YearOfBirth = newUser.YearOfBirth,
        };
        user.Age = CalculateAge(user.YearOfBirth);
        userRepository.PostUser(user);
    }
}
