using System;
using System.Collections.Generic;

using System.Linq;

// > Pour "[NotMapped]" <
using System.ComponentModel.DataAnnotations.Schema;

// > Pour le [JsonIgnore]
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données pour l'écriture en Base de données ----
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Tables des Collaobrateurs 
// #### - - - - - -

namespace EuroDotnet.Model
{
    public class DonetCollab
    {
        // > Non serialisable < 
        [JsonIgnore]
        public long Id { get; set; }
        public string Id_Collaborateur { get; set; }
        public int NumInsee { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // > Non Mappé en Base de données  < 
        //   ( On ne s'en sert que lorsque l'API reçoit les infos )
        [NotMapped]
        public string FK_ID_Adresse { get; set; }

        // > Non Mappé en Base de données  < 
        //   ( On ne s'en sert que lorsque l'API reçoit les infos )
        [NotMapped]
        public string FK_ID_Societe { get; set; }

    }

}
