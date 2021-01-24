using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GeneralHomework
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddScoped<IHumanRepository, HumanRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            services.AddDbContext<GeneralDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("GeneralDbConnection")).UseLazyLoadingProxies();
            });

            services.AddIdentity<CustomIdentityUser, IdentityRole>().AddEntityFrameworkStores<GeneralDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.Use(request => async context =>
            {
                Console.WriteLine($"Endpoint 1: {context.GetEndpoint()?.DisplayName ?? "null"}");
                await request(context);
                Console.WriteLine($"Endpoint 1 back: {context.GetEndpoint()?.DisplayName ?? "null"}");
            });

            app.UseRouting();

            app.Use(request => async context =>
            {
                Console.WriteLine($"Endpoint 2: {context.GetEndpoint()?.DisplayName ?? "null"}");
                await request(context);
                Console.WriteLine($"Endpoint 2 back: {context.GetEndpoint()?.DisplayName ?? "null"}");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
