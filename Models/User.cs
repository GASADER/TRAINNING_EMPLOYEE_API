using Microsoft.EntityFrameworkCore;

namespace TRAINNING_EMPLOYEE_API.Models;

public class User{
    public string FirstName {get; set;} ="" ;
    public string LastName {get; set;} ="" ;
    public int YearOfBirth {get; set;}
    public int Age {get; set;}

}

public class UserDB : DbContext
{
    public UserDB(DbContextOptions<UserDB> options) : base (options) {}

    public DbSet<User> Users {get; set;}
}