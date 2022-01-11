using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace RepositorySample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myDependency = services.GetRequiredService<IRepository<SimpleClassObject>>();

                    var item = new SimpleClassObject()
                    {
                        Name = "Name",
                        Value = 1
                    };

                    myDependency.AddItem(item);
                    var results = myDependency.All();

                    foreach (var itemValue in results)
                    {
                        Console.WriteLine(itemValue.Name + ": " + itemValue.Value);
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json",
                    optional: true,
                    reloadOnChange: true);
            })
            .ConfigureServices(services =>
            {
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                });
            });


    }
}
