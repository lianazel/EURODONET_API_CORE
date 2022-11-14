using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EuroDonetApi.Applications.DTOs
{
    public class SocieteDto
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

        // > Adresse de la societe sélectionnée <
        public string FK_ID_Adresse { get; set; }


        // > Message d'erreur <
        public string ErrorMessage { get; set; }

        #endregion

    }
}
