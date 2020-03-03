
#region Import Packages

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

#endregion

namespace Ecommerce.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Data Module Dependency 
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            #endregion

            #region Application Module Dependency
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IProductServices, ProductService>();
            services.AddTransient<ICartService, CartService>();
            #endregion

            #region ContextDB dependency
            services.AddTransient<UserDbContext>();
            services.AddTransient<ProductDbContext>();
            services.AddTransient<CartDbContext>();
            #endregion

            #region TokenDependency 
            services.AddTransient<User.Application.Helper.JwtAuthentication, User.Application.Helper.TokenManager>();
            #endregion
        }


    }
}
