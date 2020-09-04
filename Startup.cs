using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnOnline.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace LearnOnline
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddScoped<ICategoryRepo, MockCategoryRepo>();
            //services.AddScoped<ICourseRepo, MockCourseRepo>();
            services.AddDbContext<AppsContext>(options => options.UseSqlServer(_configuration.GetConnectionString("APPsConnection")));
            services.AddScoped<ICategoryRepo, EFCategoryRepo>();
            services.AddScoped<ICourseRepo, EFCourseRepo>();

            services.AddScoped<EFShoppingCartRepo>(s => EFShoppingCartRepo.GetShoppingCart(s));
            services.AddHttpContextAccessor();
            services.AddSession();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
