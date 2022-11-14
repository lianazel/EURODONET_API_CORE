using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EuroDonetApi.Applications.DTOs
{
    public class CollabDto
    {
        #region properties
        // > Non serialisable < 
        [JsonIgnore]
        public long Id { get; set; }
        public string Id_Collaborateur { get; set; }
        public int NumInsee { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

      
        public string FK_ID_Adresse { get; set; }

       
        public string FK_ID_Societe { get; set; }

        // > Message d'erreur <
        public string ErrorMessage { get; set; }

        #endregion

    }
}
