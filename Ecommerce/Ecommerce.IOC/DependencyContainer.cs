using Cart.Application.Interfaces;
using Cart.Application.Service;
using Cart.Data;
using Cart.Data.Context;
using Cart.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interfaces;
using Product.Application.Service;
using Product.Data.Context;
using Product.Data.Repository;
using Product.Domain.Interfaces;
using User.Application.Interfaces;
using User.Application.Services;
using User.Data.Context;
using User.Data.Repository;
using User.Domain.Interfaces;

namespace Ecommerce.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Data
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();

            //Application 
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IProductServices, ProductService>();
            services.AddTransient<ICartService, CartService>();

            //ContextDB
            services.AddTransient<UserDbContext>();
            services.AddTransient<ProductDbContext>();
            services.AddTransient<CartDbContext>();
        }


    }
}
