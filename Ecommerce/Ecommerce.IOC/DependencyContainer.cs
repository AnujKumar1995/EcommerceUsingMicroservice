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

            //Application 
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IProductServices, ProductService>();

            //ContextDB
            services.AddTransient<UserDbContext>();
            services.AddTransient<ProductDbContext>();
        }


    }
}
