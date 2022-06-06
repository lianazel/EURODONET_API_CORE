using System;
using System.Collections.Generic;

using System.Linq;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Un  collaborateur peut avoir plusieurs Sociétés 
// #### - - - - - - - - - - - - - - -


namespace EuroDotnet.Model
{
    public class DonetColSoc
    {
        [JsonIgnore]
        public long Id { get; set; }
        // > ID recalculé par le code <

        // > ID Calcué par code <
        public string Id_CollaborateurSociete { get; set; }

        // > ID Clé étrangère maitraisse : ID Collaborateur <
        public string Fk_Id_Collaborateur { get; set; }

        // > ID Clé étrangère Secondaire  : ID Société  <
        public string Fk_Id_Societe { get; set; }
    }

}
