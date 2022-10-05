using AmazonClone.BL.classes;
using AmazonClone.BL.interfaces;
using AmazonClone.DAL.AmazonContext;
using AmazonClone.DAL.Entites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonClone
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
            services.AddAuthorization(option => option.AddPolicy("age", policyBuilder => policyBuilder.RequireClaim("age","22")));
            services.AddMvc();
            services.AddScoped<IProductreo, ProductRepo>();
            services.AddScoped<Order>();
            services.AddScoped<Total>();
            services.AddScoped<CategoryRepo>();

            services.AddDbContext<AmazonContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("SharpDbConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AmazonContext>();
            //services.AddAuthorization();
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



            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //    endpoints.MapControllerRoute(
                //     name: "currency_by_code",
                //     pattern: "currency/{code}",
                //     defaults: new { controller = "Currencies", action = "View" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
