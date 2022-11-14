using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EuroDonetApi.Applications.DTOs
{
    public class AdresseDto
    {
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

        // > Message d'erreur <
        public string ErrorMessage { get; set; }


    }
}
