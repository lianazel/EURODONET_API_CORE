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
// ####   --- Tables des sociétés
// #### - - - - - -

namespace EuroDotnet.Model
{
    public class ML_DonetSociete
    {
        #region properties
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
                
        public string FK_ID_Adresse { get; set; }

        [JsonIgnore]
        //    ***** Configuration du Context ****
        // > On crée une rubrique "ListAdress" pour...
        //   ...la mise en place de la liaison dans le...
        //   ...fichier de configuration "CFG_Adresse" <
        public List<ML_DonetAdresse> ListAdress { get; set; }

        [JsonIgnore]
        //    ***** Configuration du Context ****
        // > On crée une rubrique "OneCollab" pour...
        //   ...la mise en place de la liaison dans le...
        //   ...fichier de configuration "CFG_Societe" <
        public ML_DonetCollab OneCollab { get; set; }

        // > Message d'erreur <
        public string ErrorMessage { get; set; }

        #endregion
    }

}
