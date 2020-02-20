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
using ApiGateway.AppExtensions;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddConsulConfig(Configuration);
            services.AddControllers();
            services.AddOcelot(Configuration);

          


            services.AddCacheManager<IServiceCollection>(options =>
            {
                options.WithDictionaryHandle();
            });
            services.AddCors();
             services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("TestKey",x =>
            {
                //x.Authority = "Admin";
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //var authenticationProviderKey = "TestKey";
            //Action<IdentityServerAuthenticationOptions> options = o =>
            //{
            //    o.Authority = "http://localhost:5001";
            //    o.ApiName = "User.Api";
            //    o.SupportedTokens = SupportedTokens.Both;
            //    o.RequireHttpsMetadata = false;
            //};

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //   .AddIdentityServerAuthentication(authenticationProviderKey, options);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
    }
}
