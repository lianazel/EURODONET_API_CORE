using System;
using System.Collections.Generic;

using System.Linq;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// > Pour "[NotMapped]" <
using System.ComponentModel.DataAnnotations.Schema;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des sociétés
// #### - - - - - -

namespace EuroDotnet.Model
{
    public class DonetSociete
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Id_Societe { get; set; }
        public string RaisonSociale { get; set; }
        public int NumSiren { get; set; }
        public decimal CapitalSocial { get; set; }
        public decimal ChiffreAffaire { get; set; }
        public string NumTVAIntra { get; set; }

        [JsonIgnore]
        // > Servira à rendre le n° de facture unique  < 
        public int NumSociete { get; set; }

        // > Non Mappé en Base de données  < 
        //   ( On ne s'en sert que lorsque l'API reçoit les infos )
        [NotMapped]
        public string FK_ID_Adresse { get; set; }
    }

}
