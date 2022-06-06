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
// ####   --- Tables incrémentation compteur par société 
// #### - - - - - - - - - - - - - - -

namespace EuroDotnet.Model
{
    public class DonetFactureCalculNum
    {
        [JsonIgnore]
        public long Id { get; set; }

        // > ID N° de société <
        public string FK_ID_Societe { get; set; }

        // > Compteur pour la société  <
        public long SocCompteur { get; set; }


        
     }

}
