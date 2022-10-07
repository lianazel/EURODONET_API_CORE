using System;
using System.Collections.Generic;

using System.Linq;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####        Préfixe "ML_" pour indiquer que c'est un modèle 
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des adresses 
// #### - - - - - - - - - - - - - - -

namespace EuroDotnet.Model
{
    public class ML_DonetAdresse
    {
        #region properties

        [JsonIgnore]
        public long Id { get; set; }
        public string Id_Adresse { get; set; }
        public Nullable<int> NumVoie { get; set; }
        public string TypVoie { get; set; }
        public string Adresse_1 { get; set; }
        public string Adresse_2 { get; set; }
        public int CodePostal { get; set; }
        public string Region { get; set; }
        public string Pays { get; set; }
        public string LibelleAdresse { get; set; }

        [JsonIgnore]
        //    ***** Configuration du Context ****
        // > On crée une rubrique "OneSociety" pour...
        //   ...la mise en place de la liaison dans le...
        //   ...fichier de configuration "CFG_Adresse" <
        public ML_DonetSociete OneSociety { get; set; }

        [JsonIgnore]
        //    ***** Configuration du Context ****
        // > On crée une rubrique "OneCollab" pour...
        //   ...la mise en place de la liaison dans le...
        //   ...fichier de configuration "CFG_Adresse" <
        public ML_DonetCollab OneCollab { get; set; }

        // > Message d'erreur <
        public string ErrorMessage { get; set; }


        #endregion


    }

}
