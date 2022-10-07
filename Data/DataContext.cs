using Microsoft.EntityFrameworkCore;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EuroDonetApi.Data.Configuration;

namespace EuroDotNet.Data
{
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=
    // ### On déclare tous les modèles de données qui seton pris en charge par le context 
    // ###       ( Context géré par l'ORM => Object Relational Manager )
    // ###       ( ici l'ORM              => entity Framework          )
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=

    public class DataContext : DbContext
    {
        // > Constructeur <
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // #####=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ##### -- Installe les configurations pour les tables 
        // #####=-=-=-=-=-=-=-=-=-=-=-=-=-=
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // > On déclare la classe de configuration pour la table des Adresses <
            modelBuilder.ApplyConfiguration(new CFG_Adresse());

            // > On déclare la classe de configuration pour la table des adresses ( pour alimenter une dropdownlist ) <
            modelBuilder.ApplyConfiguration(new CGF_AdresseDropDownItem());
        }


        // > Table des adresses <
        public DbSet<ML_DonetAdresse> Adresse { get; set; }

        // > Table des adresses : pour alimenter une DropDownList <
        public DbSet<ML_DonetAdresseDropDownItem> AdresseDropDownList { get; set; }

        // > Table des sociétes  <
        public DbSet<ML_DonetSociete> Societe { get; set; }

        // > Table des coallaborateurs   <
        public DbSet<ML_DonetCollab> Collab { get; set; }

        // > Table des Adresses de société   <
        //    ( Une SOCIETE  peut avoir PLUSIEURS Adresses )
        public DbSet<ML_DonetSocAdr> SocAdr { get; set; }

        // > Table des Adresses de collaborateurs   <
        //    ( Un  COLLABORATEUR peut avoir PLUSIEURS Adresses )
        public DbSet<ML_DonetColAdr> ColAdr { get; set; }

        // > Table des sociétées  de collaborateurs   <
        //    ( Un  COLLABORATEUR peut avoir PLUSIEURS sociétes  )
        public DbSet<ML_DonetColSoc> ColSoc { get; set; }

        // > Table des Numéros de facture (calcul N° de facture )  <
        public DbSet<ML_DonetFactureCalculNum> FactureCalculNum { get; set; }

        // > Table des  de facture   <
        public DbSet<ML_DonetFactureGeneration> FactureGeneration{ get; set; }

    }
}
