using EuroDonetApi.Data.Repositories;
using EuroDonetApi.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDonetApi.ExtensionMethods
{
    public static class ExtMethods
    {
        #region méthods
        /// <summary>
        /// Prepare customs dependancy injection.
        /// </summary>
        /// <param name="services"></param>

        public static void AddInjections(this IServiceCollection services)
         {
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            // ####     *****   Injectoion de dépendeances  *******           ####
            // ####  > Injection de la classe "DefaultEuroDonetRepository"    ####
            // ####  > Injection de la classe "DataControlRepository"         ####
            // ####  > Injection de la classe "DataProcessRepository"         ####
            // ####                                                           #### 
            // ####    Le Framework crée ici les lien entre les interfaces    #### 
            // ####    ....et les classes qui utilise ces interface.          #### 
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            services.AddScoped<IEuroDonetRepository, DefaultEuroDonetRepository>();
            services.AddScoped<IDataControlRepository, DataControlRepository>();
            services.AddScoped<IDataProcessRepository, DataProcessRepository>();
        }

        #endregion
    }
}
