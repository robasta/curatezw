using System;
using Curate.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Curate.Data.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Curate.Web.ViewModels;
using Curate.Web.Identity;
using Curate.Data.ViewModels.Identity;

namespace Curate.Web
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
          
            var curateApiBaseUrl = Configuration.GetValue<string>("CURATEAPI");
            
            services.AddAutoMapper(typeof(Startup),typeof(Post));
            services.AddHttpClient("curate", c => { c.BaseAddress = new Uri(curateApiBaseUrl); });
            services.AddDatabase(Configuration);
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
               {
                   options.Password.RequiredLength = 8;
                   options.Lockout.MaxFailedAccessAttempts = 5;
                   options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<curatedbContext>();
            
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            services.AddRepositories();
            services.AddServices();
            services.AddControllers().AddRazorRuntimeCompilation();
            services.AddMvc();
           // services.AddRazorPages();
           
          

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
