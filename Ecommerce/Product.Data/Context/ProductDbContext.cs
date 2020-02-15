using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;

namespace Product.Data.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<ProductModel> ProductModels { get; set; }

    }
}
