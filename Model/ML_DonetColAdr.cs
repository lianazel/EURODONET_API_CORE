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
// ####   --- Un  collaborateur peut avoir plusieurs adresses 
// #### - - - - - - - - - - - - - - -


namespace EuroDotnet.Model
{
    public class ML_DonetColAdr
    {
        # region properties
        [JsonIgnore]
        public long Id { get; set; }
        // > ID recalculé par le code <
        public string Id_CollabAdresse { get; set; }
        // > Clé étrangère maitresse  : ID_ Collaborateur <
        public string Fk_Id_Collab{ get; set; }
        // > Clé étrangère associée  : ID_ Adresse  <
        public string Fk_Id_Adress { get; set; }

        #endregion
    }

}
