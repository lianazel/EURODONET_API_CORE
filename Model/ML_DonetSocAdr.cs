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
// ####   --- Une société peut avoir plusieurs adresses 
// #### - - - - - - - - - - - - - - -


namespace EuroDotnet.Model
{
    public class ML_DonetSocAdr
    {
        #region properties
        [JsonIgnore]
        public long Id { get; set; }
        // > ID recalculé par le code <
        public string Id_SocieteAdresse { get; set; }
        // > Clé étrangère maitresse  : ID_ société  <
        public string Fk_Id_Societe { get; set; }
        // > Clé étrangère associée  : ID_ Adresse  <
        public string Fk_Id_Adress { get; set; }
        

        public ML_DonetSociete Societe { get; set; }
        #endregion
    }

}
