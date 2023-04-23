using BookStoreWeb.Claims;
using BookStoreWeb.Data;
using BookStoreWeb.Models;
using BookStoreWeb.Repository;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb
{
    public class Startup
    {
        private readonly IConfiguration _config = null;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //....run timr compliation for just development environmet
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions(option =>
            {
                option.HtmlHelperOptions.ClientValidationEnabled = true; //for Dev disable false/enable true client-side-validation
            });
#endif
            services.AddDbContext<BookStoreWebContext>(
                options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            //...config Identity for security
            //..
            //...the standard is IdentityUser
            //..the custom on identity is ApplicationUser
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreWebContext>();

            //...config identity for test
            //...try on password
            //services.Configure<IdentityOptions>(option =>
            //{
            //    option.Password.RequiredLength = 6;
            //    option.Password.RequiredUniqueChars = 1;
            //    option.Password.RequireDigit = false;
            //    option.Password.RequireLowercase = false;
            //    option.Password.RequireNonAlphanumeric = false;
            //    option.Password.RequireUppercase = false;
            //});

            //...redirect user to signin page
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = _config["LogInPath"];
            });

            //...depandancy injection
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, SignInUserClaimsPrincipalFactory>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            //..for smtp bint to model
            services.Configure<SmtpConfigVM>(_config.GetSection("SmtpConfig"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
