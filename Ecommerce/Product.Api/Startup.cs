#region All Packages
using Ecommerce.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Product.Data.Context;
#endregion

namespace Product.Api
{
    public class Startup
    {
        #region Constructor 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Property for Configuration
        public IConfiguration Configuration { get; }
        #endregion

        #region This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();

            #region ConnectionString for DB
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProductDBConnection"));
            });
            #endregion

            #region Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Microservice", Version = "v1" });
            });
            #endregion

            #region Add Dependency Injection
            RegisterService(services);
            #endregion

        }
        #endregion

        #region Register Dependency 
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

            //Add HealthChecks
            app.UseHealthChecks("/productHealth");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Create a swagger pipeline
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Microservice V1");
            });
            #endregion
        }
        #endregion
    }
}
