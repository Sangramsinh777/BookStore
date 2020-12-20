using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MyBooksStore.Data;
using MyBooksStore.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore
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
            services.AddControllersWithViews();
            services.AddDbContext<BookStoreContext>(options=> 
                options.UseSqlServer("Server=.;DataBase=BookStore;Integrated Security=True;")
            //Data Source = SANGRAMSINH; Initial Catalog = DBEmployee; Integrated Security = True
            );
            services.AddScoped<BookRepository, BookRepository>();
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

            //app.UseStaticFiles(new StaticFileOptions() { 
            //    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyResources")),
            //    RequestPath= "/MyResources"
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "Default",
            //        pattern: "bookApp/{controller=Home}/{action=Index}/{id?}"
            //        );
            //});


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.UseEndpoints(endpoints=> {
            //    endpoints.MapGet("/", async context =>
            //    {

            //        if (env.IsDevelopment())
            //        {
            //            await context.Response.WriteAsync($"Hello From:{env.EnvironmentName}");
            //        }
            //        else {
            //            await context.Response.WriteAsync($"Hello From:{env.EnvironmentName}");
            //        }

            //    });
            //});
        }
    }
}
