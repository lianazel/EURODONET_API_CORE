using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

// > Pour l'injection de dépendance <
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// > Pour povour accéder au conexte <
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

            // > Création d'un objet "Host"  <
            var host = CreateHostBuilder(args).Build();

            // > Appelle la méthode "CreateDbIfNotExists" <
            CreateDbIfNotExists(host);

            // > Démarrage de l"application Web <
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

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Création de la BDD si elle n'est pas présente <
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                // > Tentative de création de la BDD <
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                }
                // > Quelquechose s'est mal passé...<
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "ERR-DB-01A -> Eerreur détectée à la création de la BDD.");
                }
            }
        }

    }
}


