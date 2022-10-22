using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EuroDotNet.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EuroDonetApi.Data.Repositories;
using EuroDonetApi.Interface;

// > Extension methods <
using EuroDonetApi.ExtensionMethods;


namespace EuroDotNet
{
    public class Startup
    {
              
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {                 
            
            // ===> Connexion � la base locale SQLite avec injection du context <=====
            services.AddDbContext<DataContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnectionSqlite")));

            // ===> Connexion � la base SQLServer avec injection du context <=====
            // services.AddDbContext<DataContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // ####     *****   Injectoion de d�pendeances  *******                  ####
            // ####    Les injections sont d�port�es dans une m�thode d'extension    #### 
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=
            services.AddInjections();


            // > Pour la gestion des Razor Page ( pages Web ) <
            //   ( je l'utiliose pour afficher une page statique de l'API )
            services.AddRazorPages();

            // > Pour la gestion des contr�leur ( API ) <
            services.AddControllers(); 
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {                 

            // > En mode d�veloppement, on affiche les erreurs <
            //   ( Mais en mode production, on aura PAS les erreurs...
            //     ..du coup, on modifie le code avec "if (true)" ) 
            if (env.IsDevelopment())
                //  > on triche un peu on for�ant le bool�en � "true" <
                //  ( Comme �a en production, on aura les erreurs d�taill�es <
                if (true)
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
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // > Gestion des contr�leurs ( API ) <
                endpoints.MapControllers();
            });
        }

        

    }
}
