using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seterator.Services;

namespace Seterator
{
    public class Startup
    {
        private static readonly NLog.Logger _httpRqsLogger = _httpRqsLogger = Logger.Default;
        public IConfiguration Configuration { get; }
        string Connection => Configuration.GetConnectionString("Local MySQL");

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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
            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .AddDistributedMemoryCache()
                .AddSession()
                .AddLogging()
                .AddPrimitiveMemoryCache()
                .AddFoulLanguageFilter("*")
                .AddDbContext<DatabaseContext>(options => options.UseMySQL(Connection)
                                                                         .EnableDetailedErrors()
                                                                         .EnableSensitiveDataLogging())
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Account/Main");
                        options.Cookie.Name = "ssid";
                    })
                    ;
            services
                .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddMvcOptions(options => options.EnableEndpointRouting = false);

        }
#pragma warning disable CA1822 // Member Configure does not access instance data and can be marked as static
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
#pragma warning restore CA1922 
        {
            // Добавляем логирование URL.
            // Логирование реализовано в пайплайне обработке запросов 
            // MVC, это позволит логировать все запросы, а не только
            // те, которые были смаршрутизированы в action(в сравнении c ActionFilter).
            app.Use(async (context, next) =>
            {
                await next.Invoke().ConfigureAwait(false);
                _httpRqsLogger.Trace("Requesting resource: {0}", context.Request.Path);
            });

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
                       name: "Guid parameter",
                       template: "{controller}/{action}/{guid}",
                       defaults: new { controller="Home", action="Index" },
                       constraints: new { guid = new GuidRouteConstraint() });
                   routes.MapRoute(
                       name: "Only action",
                       template: "{controller=Home}/{action=Index}");
               });

        }
    }
}
