using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Rauthor
{
    public class Startup
    {
//'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'	Rauthor C:\Users\BearPro\source\Workspaces\Rauthor\Rauthor\Startup.cs	74	Active

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            Contract.Assert(env != null);
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json",
                             optional: false,
                             reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }
            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("Local MySQL");

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services
                .AddDistributedMemoryCache()
                .AddSession()
                .AddLogging()
                .AddDbContext<Models.DatabaseContext>(options => options.UseMySQL(connection))
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Account/Login");
                        options.Cookie.Name = "ssid";
                    })
                    ;
            services
                .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddMvcOptions(options => options.EnableEndpointRouting = false);

        }
#pragma warning disable CA1822 // Member Configure does not access instance data and can be marked as static
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
#pragma warning restore CA1922 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseCookiePolicy()
               .UseSession()
               .UseAuthentication()
               .UseMiddleware<Services.SessionRestore>()
               .UseMvc(routes =>
               {
                   routes.MapRoute(
                       name: "guid",
                       template: "{controller}/{action}/{guid}",
                       defaults: default,
                       constraints: new { guid = new GuidRouteConstraint() }
                       );
                   routes.MapRoute(
                       name: "default",
                       template: "{controller=Home}/{action=Index}/{id?}");
               });
            
        }
    }
}
