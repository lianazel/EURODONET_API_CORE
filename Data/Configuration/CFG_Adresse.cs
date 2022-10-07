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
// ######## --- Configuration (ou tuning) de la table des Adresses 
// ########      ( contient la description d'une adresse complète ) 
// ########   Préfixe "CFG_" pour indiquer que c'est une configuration
// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//  > On définit le nom physique de la table ( pas obligatoire, mais plus propre < )
//  > On définie la clé primaire de la table <

// > IMPORTANT = déclarer cette classe dans la classe "DataContext <

namespace EuroDonetApi.Data.Configuration
{
    public class CFG_Adresse : IEntityTypeConfiguration<ML_DonetAdresse>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<ML_DonetAdresse> builder)

        {
            // > Aura en base le nom pysique "DonetAdresse" <
            builder.ToTable("Adresse");

            // > Définit la clé pour la table des adresses  <
            builder.HasKey(item => item.Id_Adresse);

            // > On définit la relation ici < 
            //  => Une ADRESSE ne peut être rattachée qu'à une SOCIETE <
            //  => Une SOCIETE peut avoir plusieurs ADRESSES 
            builder.HasOne(item => item.OneSociety)
                   // ( pour récupérer la valeur de l'Item pour "WithMany",...
                   // ...le framework doit trouver la "List..." dans le modèle...
                   // ...déclaré dans "HasOne". )
                   .WithMany(item => item.ListAdress);

            // > On définit la relation ici < 
            //  => Une ADRESSE ne peut être rattachée qu'à un  COLLABORATEUR <
            //  => Une COLLABORATEUR peut avoir plusieurs ADRESSES 
            builder.HasOne(item => item.OneCollab)
                   // ( pour récupérer la valeur de l'Item pour "WithMany",...
                   // ...le framework doit trouver la "List..." dans le modèle...
                   // ...déclaré dans "HasOne". )
                   .WithMany(item => item.ListAdress);

        }

        #endregion
    }
}
