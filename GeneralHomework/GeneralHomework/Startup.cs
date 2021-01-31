using GeneralHomework.Configurations;
using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddScoped<MessageSenderFactory>();
            services.AddSingleton<IRestApiExampleClient, RestApiExampleClient>();
            services.AddSingleton<ILoadFile, LoadFile>();
            services.AddSingleton<FileProcessingChannel>();

            services.AddMemoryCache();

            services.AddHostedService<LoadFileHostedService>();
            services.AddHostedService<UploadFileHostedService>();


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

            services.Configure<GeneralAppConfiguration.Email>(_configuration.GetSection("GeneralHomework:Email"));
            services.Configure<GeneralAppConfiguration.Sms>(_configuration.GetSection("GeneralHomework:Sms"));
            services.Configure<GeneralAppConfiguration.LoadFile>(_configuration.GetSection("LoadFile"));

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<WriteToConsoleMiddleware>("test string");
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("Before");
            //});

            //app.Map("/Account", AccountHandling);

            //app.Run(async context =>
            //{
            //    Console.WriteLine("Run middleware");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private void AccountHandling(IApplicationBuilder app)
        //{
        //    //Console.WriteLine("Map is working");

        //    app.Run(async context =>
        //    {
        //        Console.WriteLine("Map is working");
        //    });
        //}
    }
}
