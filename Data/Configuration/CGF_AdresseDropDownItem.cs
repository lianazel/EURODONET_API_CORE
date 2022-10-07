using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Pour "EntityTypeBuilder" <
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// > Pour "DonetAdresseDropDownItem" 
using EuroDotnet.Model;


// ####    !!!      Configuration Context  !!!

// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
// ######## --- Configuration (ou tuning) de la table "DonetAdresseDropDownItem"
// ########      ( Cette table ne sert qu'a alimenter une dropDownList  ) 
// ########        ( Une liste d'adresse est renvoyé au site pour alimenter une combo ( dropdownlist )
// ########   Préfixe "CFG_" pour indiquer que c'est une configuration*
// ########=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=
//  > On définit le nom physique de la table ( pas obligatoire, mais plus propre <
//  > On définie la clé primaire de la table <

// > IMPORTANT = déclarer cette classe dans la classe "DataContext <

namespace EuroDonetApi.Data.Configuration
{
    public class CGF_AdresseDropDownItem : IEntityTypeConfiguration<ML_DonetAdresseDropDownItem>
    {
        public void Configure(EntityTypeBuilder<ML_DonetAdresseDropDownItem> builder)

        {
            // > Aura en base le nom pysique "DonetAdresseDropDownItem" <
            builder.ToTable("DonetAdresseDropDownItem");

            // > Définit la clé pour la table des adresses  <
            builder.HasKey(item => item.Id_Adresse);
        }
    }
}

