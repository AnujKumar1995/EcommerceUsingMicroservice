
#region Import Packages
using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;
#endregion

namespace Product.Data.Context
{
    public class ProductDbContext:DbContext
    {
        #region Constructor
        public ProductDbContext(DbContextOptions options):base(options)
        {
        }
        #endregion

        #region DbSet for Product
        public DbSet<ProductModel> ProductModels { get; set; }
        #endregion

    }
}
