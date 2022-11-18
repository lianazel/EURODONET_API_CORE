using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Génération Facture : Données renvoyées en sortie 
/// //   ( Dto => Data Transfert Object )
/// </summary>

namespace EuroDonetApi.Applications.DTOs
{
    public class FactureGenereDto
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
