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
// ####        Préfixe "ML_" pour indiquer que c'est un modèle 
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables factures générées
// #### - - - - - -

namespace EuroDotnet.Model
{
    public class ML_DonetFactureGeneration
    {
        #region properties

        [JsonIgnore]
        public long Id { get; set; }
        public string Id_FactureGeneration { get; set; }
        public string NumeroFacture { get; set; }
        public string DescriptionFacture { get; set; }
        public DateTime DateFacture { get; set; }

        // > ID du collaborateur <
        public string FK_ID_Collaborateur { get; set; }
        // > ID du Numro de Société <
        public string FK_ID_Societe{ get; set; }

        // > ID Adresse de la société  <
        public string FK_ID_Adresse_Societe { get; set; }

        #endregion

    }

}
