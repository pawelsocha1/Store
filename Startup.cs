
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Store.Controllers;
using Store.Filtrs;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
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


            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:Products:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();



            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration["Data:Products:ConnectionString"]));
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<ICRUDProductRepository, EFCRUDProductRepository>();
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddScoped<Seeder>();
          

            services.AddSingleton<BasicAuthorizationFilter>();
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService<BasicAuthorizationFilter>();
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=List}/{id?}");


            });
            IdentitySeedData.EnsurePopulated(app);
            app.UseMiddleware<MiddlewareCounter>();

        }
    }
    }


