using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Pour "DonetSocAdr" 
using EuroDotnet.Model;

// > Pour "EntityTypeBuilder" <
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ######## --- Configuration (ou tuning) de la table des adresses d'une société
// ########      ( Liste des adresses pour une société ) 
// ########   Préfixe "CFG_" pour indiquer que c'est une configuration
// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//  > On définit le nom physique de la table ( pas obligatoire, mais plus propre < )
//  > On définie la clé primaire de la table <

// > IMPORTANT = déclarer cette classe dans la classe "DataContext <

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//   ****  Une société peut avoir plusieurs adresses ****
//    [ Mise en place realtion de tables ]
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

namespace EuroDonetApi.Data.Configuration
{
    public class CFG_SocAdr : IEntityTypeConfiguration<ML_DonetSocAdr>
    {
        #region public methods
        public void Configure(EntityTypeBuilder<ML_DonetSocAdr> builder)

        {
            // > Aura en base le nom pysique "DonetAdresse" <
            builder.ToTable("DonetSocAdr");

            // > Définit la clé pour la table des adresses pour une société  <
            builder.HasKey(item => item.Id_SocieteAdresse);
                
            
        }
        #endregion
    }
}
