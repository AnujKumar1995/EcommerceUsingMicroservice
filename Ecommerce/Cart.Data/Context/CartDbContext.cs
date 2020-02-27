
#region Import Packages

using Cart.Domain.Models;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Cart.Data.Context
{
    public class CartDbContext:DbContext
    {
        #region Constructor
        public CartDbContext(DbContextOptions options): base(options) 
        { }
        #endregion

        #region DbSet for Cart
        public DbSet<CartModel> CartModels { get; set; }
        #endregion

    }
}
