using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

// > Pour l'injection de d�pendance <
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// > Pour povour acc�der au conexte <
using EuroDotNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDotNet
{
    public class Program
    {
        public static void  Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            // > Cr�ation d'un objet "Host"  <
            var host = CreateHostBuilder(args).Build();

            // > Appelle la m�thode "CreateDbIfNotExists" <
            CreateDbIfNotExists(host);

            // > D�marrage de l"application Web <
            // ( The Run method starts the web app
            //   ...and blocks the calling thread until the host is shut down )
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

    }
}


