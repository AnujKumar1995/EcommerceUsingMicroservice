
#region Import Packages
using Cart.Data.Context;
using Ecommerce.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
#endregion

namespace Cart.Api
{
    public class Startup
    {
        #region Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Configuration's Property
        public IConfiguration Configuration { get; }
        #endregion

        #region This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();

            #region Add ConnectionString for CartDb
            services.AddDbContext<CartDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CartDBConnection"));
            });
            #endregion

            #region Add swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cart Microservice", Version = "v1" });
            });
            #endregion

            #region Add Dependency
            RegisterService(services);
            #endregion
        }
        #endregion

        #region Add Dependency Injection service
        private void RegisterService(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
        #endregion

        #region This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Add healthChecks
            app.UseHealthChecks("/cartHelath");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart Microservice V1");
            });
        }
        #endregion
    }
}
