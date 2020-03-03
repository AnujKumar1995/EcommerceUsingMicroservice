
#region Import Packages

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

#endregion

namespace ApiGateway
{
    public class Startup
    {
        #region Constructor and Configuration Property
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        #endregion

        #region This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddHealthChecks();

            //Add Service Discovery 
            //services.AddOcelot(Configuration).AddConsul().AddCacheManager(options =>
            //{
            //    options.WithDictionaryHandle();
            //});

            #region Add Ocelot 
            services.AddOcelot(Configuration);
            services.AddCacheManager<IServiceCollection>(options =>
            {
                options.WithDictionaryHandle();
            });
            #endregion

            #region Add Authentication JWT
            services.AddCors();
            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
            .AddJwtBearer("Bearer", jwt =>
             {
                 //jwt.Authority = Configuration["App:Authority"];
                 //jwt.Audience = Configuration["App:Audience"];
                 jwt.RequireHttpsMetadata = false;
                 jwt.SaveToken = true;
                 jwt.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==")),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });
            #endregion

        }
        #endregion

        #region This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseConsul();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseOcelot().Wait();

            //Add Health Checks
            app.UseHealthChecks("/health");
          
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
