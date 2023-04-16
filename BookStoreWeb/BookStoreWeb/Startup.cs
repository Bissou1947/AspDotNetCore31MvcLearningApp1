using BookStoreWeb.Data;
using BookStoreWeb.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
                options => options.UseSqlServer("Server=DESKTOP-LUQVALN;DataBase=BookStoreWeb;Integrated Security=True;"));

            //...depandancy injection
            services.AddScoped<BookRepository, BookRepository>();
            services.AddScoped<LanguageRepository, LanguageRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
