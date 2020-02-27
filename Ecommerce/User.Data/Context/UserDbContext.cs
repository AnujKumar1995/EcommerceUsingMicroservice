
#region Import Packages
using Microsoft.EntityFrameworkCore;
using User.Domain.Models;
#endregion

namespace User.Data.Context
{
    public class UserDbContext:DbContext
    {
        #region Constructor
        public UserDbContext(DbContextOptions options): base(options)
        {
        }
        #endregion

        #region DbSet for User Models
        public DbSet<UserModel> UserModels { get; set; }
        #endregion
    }
}
