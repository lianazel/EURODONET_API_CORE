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
// ####    --- Génération Facture : Données renvoyées en sortiee 
// #### - - - - - - - - - - - - - - -

//  #####    PAS UTILISE FINALEMENT..... 

namespace EuroDotnet.Model
{
    public class ML_Genere_Facture_OUT
    {
        #region properties
        // > Numéro Facture  <
        public string Numero { get; set; }
        // > date facture <
        public DateTime Date { get; set; }
        // > Adresse sociéte <
        public ML_DonetAdresse Adresse { get; set; }
        // > Uméro TBA intra Europ <
        public string NumTVAIntra { get; set; }

        // > Description Facture  <
        public string Description { get; set; }
        // > Message erreur Eventuel <
        public string ErrorMessage { get; set; }
        #endregion
    }

}
