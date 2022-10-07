using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Pour "DonetAdresse" 
using EuroDotnet.Model;

// > Pour "EntityTypeBuilder" <
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ####    !!!      Configuration Context  !!!

// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ######## --- Configuration (ou tuning) de la table des sociétés 
// ########      ( contient la description d'une société complète ) 
// ########   Préfixe "CFG_" pour indiquer que c'est une configuration
// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//  > On définit le nom physique de la table ( pas obligatoire, mais plus propre <
//  > On définie la clé primaire de la table <

// > IMPORTANT = déclarer cette classe dans la classe "DataContext <

namespace EuroDonetApi.Data.Configuration
{
    public class CFG_Societe : IEntityTypeConfiguration<ML_DonetSociete>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<ML_DonetSociete> builder)

        {
            // > Aura en base le nom pysique "DonetSociete" <
            builder.ToTable("DonetSociete");

            // > Définit la clé pour la table sociétés<
            builder.HasKey(item => item.Id_Societe);

            // > On définit la relation ici < 
            //  => Une SOCIETE ne peut être rattachée qu'à un COLLABORATEUR <
            //  => Un  COLLABORATEUR peut avoir plusieurs SOCIETES 
            builder.HasOne(item => item.OneCollab)
                   // ( pour récupérer la valeur de l'Item pour "WithMany",...
                   // ...le framework doit trouver la "List..." dans le modèle...
                   // ...déclaré dans "HasOne". )
                   .WithMany(item => item.ListSociete);
        }
        #endregion
    }
}

