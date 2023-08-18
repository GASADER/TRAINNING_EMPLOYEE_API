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

    public List<UserResponse> GetAll()
    {
        UserRepository userRepository = new UserRepository(_userDBContext);
        List<UserResponse> userResponses = new List<UserResponse> ();
        List<User> users = userRepository.GetAll();

        foreach (User user in users)
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

    public void PostUser(UserRequest newUser)
    {

        UserRepository userRepository = new UserRepository(_userDBContext);

        User user = new User()
        {
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            YearOfBirth = newUser.YearOfBirth,
        };
        user.Age = CalculateAge(user.YearOfBirth);
        for (int i = 0; i < newUser.Phones.Count; i++)
        {
            Phone phone = new Phone();
            phone.PhoneNumber = newUser.Phones[i];
            user.Phones.Add(phone);
        };
        userRepository.PostUser(user);
    }
}
