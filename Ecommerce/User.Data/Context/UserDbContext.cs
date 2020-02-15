using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.Data.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
