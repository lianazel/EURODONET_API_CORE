using System;
using System.Collections.Generic;

using System.Linq;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour passage de paramètres  ----
// ####        Préfixe "ML_" pour indiquer que c'est un modèle 
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Génération Facture : Paramètres en ENTREE 
// #### - - - - - - - - - - - - - - -

namespace EuroDotnet.Model
{
    public class ML_Genere_Facture_IN
    {
        #region properties 
        // > ID du collaborateur <
        public string ID_Collaborateur { get; set; }
        // > ID du Numro de Société <
        public string ID_Societe_Collaborateur { get; set; }

        // > ID Adresse de la société  <
        public string ID_Adresse_Societe { get; set; }

        // > Descriptif Facture <
        public string DescriptionFacture { get; set; }

        #endregion
    }

}
