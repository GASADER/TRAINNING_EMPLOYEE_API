using Microsoft.EntityFrameworkCore;
using TRAINNING_EMPLOYEE_API.Models;


namespace TRAINNING_EMPLOYEE_API.Repositories
{

    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        public DbSet<User> users { get; set; }

        public DbSet<Phone> phones { get; set; }

    }
}