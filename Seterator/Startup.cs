using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Seterator.Services;

namespace Seterator
{
    public class Startup
    {
        private readonly ILogger<Startup> logger;
        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// <para>Возвращает строку подключения к БД.</para>
        /// <para>Имя используемой строки подключения определяется параметром конфигурации "UseConnectionString".</para>
        /// </summary>
        string ConnectionString {
            get
            {
                string connectionStringName = Configuration.GetValue<string>("UseConnectionString");
                return Configuration.GetConnectionString(connectionStringName);
            }
        }

        public Startup(IWebHostEnvironment env, ILogger<Startup> logger)
        {
            Contract.Assert(env != null);
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Startup>();
            Configuration = builder.Build();
            this.logger = logger;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddPrimitiveMemoryCache();
            services.AddFoulLanguageFilter("*");
            services.AddDbContext<DatabaseContext>(dbContext =>
            {
                dbContext.UseMySql(ConnectionString);
                dbContext.EnableDetailedErrors();
                dbContext.EnableSensitiveDataLogging();
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/Account/Main");
                        options.Cookie.Name = "ssid";
                    });
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddMvcOptions(options => options.EnableEndpointRouting = false);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMiddleware<SessionRestore>();
            app.UseMvc(routes =>
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

            app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/html";

                StringBuilder responseBody = new StringBuilder(2048);

                responseBody.Append("<html lang=\"ru\"><body>\r\n")
                            .Append("Something unexpected bla-bla-bla happened... Please try refreshing the page.<br><br>\r\n");

                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                Exception unhandledException = exceptionHandlerPathFeature.Error;
                if (unhandledException != null)
                {
                    if (env.IsDevelopment())
                    {
                        responseBody.Append("</br>")
                                    .Append("Unhandled exception: " + unhandledException.ToString());
                    }
                    logger.LogError(unhandledException, "Unhandled exception while accessing resource {0}:", context.Request.Path);
                }

                responseBody.Append("<a href=\"/\">Home</a><br>\r\n")
                            .Append("</body></html>\r\n");
                await context.Response.WriteAsync(responseBody.ToString()).ConfigureAwait(false);
            }));
        }
    }
}
