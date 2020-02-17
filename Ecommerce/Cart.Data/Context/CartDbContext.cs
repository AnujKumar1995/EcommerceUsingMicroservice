using Cart.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart.Data.Context
{
    public class CartDbContext:DbContext
    {
        public CartDbContext(DbContextOptions options): base(options) 
        { }
        
        public DbSet<CartModel> CartModels { get; set; } 
        
    }
}
