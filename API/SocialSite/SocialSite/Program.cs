using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SDATA;

namespace SocialSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //CreateHostBuilder(args).Build().Run();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider ;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();

                }
                catch (Exception ex)
                {
                    var Logger = services.GetRequiredService<ILogger<Program>>();
                    Logger.LogError(ex, "An error occured during Migration");
                }

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Add the following line:
                    webBuilder.UseSentry("https://ad4d74fd87084314aea4cca7262c01fc@o407788.ingest.sentry.io/5278731");
                    //webBuilder.UseSetting("https_port", "44303");
                    webBuilder.UseStartup<Startup>();                   
                });
    }
}
