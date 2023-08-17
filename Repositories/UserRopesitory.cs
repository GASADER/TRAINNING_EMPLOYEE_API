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
    public List<User> GetAll()
    {
        return _userDBContext.users.ToList();
    }

    public void PostUser(User user)
    {
        _userDBContext.users.Add(user);
        _userDBContext.SaveChanges();
    }
}