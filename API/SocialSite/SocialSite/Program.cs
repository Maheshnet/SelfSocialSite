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

namespace WebApplication1
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
                    //webBuilder.UseSetting("https_port", "44303");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
