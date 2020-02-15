using Microsoft.Extensions.DependencyInjection;
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

            //ContextDB
            services.AddTransient<UserDbContext>();
        }


    }
}
