using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Seterator
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("NLogger initialized");
                CreateWebHostBuilder(args).Build().Run();
            } catch(Exception e) {
                logger.Error(e, "Unrecoverable exception while running the app");
                throw;
            } finally {
                LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((loggerBuilder) => {
                    loggerBuilder.ClearProviders();
                    loggerBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                })
                .UseNLog()
                .UseKestrel()
                .UseUrls("http://*:5000/", "https://*:5001/")
                .UseStartup<Startup>();
    }
}
