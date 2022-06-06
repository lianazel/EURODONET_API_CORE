using Microsoft.EntityFrameworkCore;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // > Table des adresses <
        public DbSet<DonetAdresse> Adresse { get; set; }

        // > Table des sociétes  <
        public DbSet<DonetSociete> Societe { get; set; }

        // > Table des coallaborateurs   <
        public DbSet<DonetCollab> Collab { get; set; }

        // > Table des Adresses de société   <
        //    ( Une SOCIETE  peut avoir PLUSIEURS Adresses )
        public DbSet<DonetSocAdr> SocAdr { get; set; }

        // > Table des Adresses de collaborateurs   <
        //    ( Un  COLLABORATEUR peut avoir PLUSIEURS Adresses )
        public DbSet<DonetColAdr> ColAdr { get; set; }

        // > Table des sociétées  de collaborateurs   <
        //    ( Un  COLLABORATEUR peut avoir PLUSIEURS sociétes  )
        public DbSet<DonetColSoc> ColSoc { get; set; }

        // > Table des Numéros de facture (calcul N° de facture )  <
        public DbSet<DonetFactureCalculNum> FactureCalculNum { get; set; }

        // > Table des  de facture   <
        public DbSet<DonetFactureGeneration> FactureGeneration{ get; set; }




    }
}
