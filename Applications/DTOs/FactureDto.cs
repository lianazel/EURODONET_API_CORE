using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Génération Facture : Paramètres en ENTREE 
///   ( Dto => Data Transfert Object )
/// </summary>

namespace EuroDonetApi.Applications.DTOs
{
    public class FactureDto
    {
        #region properties 
        // > ID du collaborateur <
        public string ID_Collaborateur { get; set; }
        // > ID du Numro de Société <
        public string ID_Societe_Collaborateur { get; set; }

        // > ID Adresse de la société  <
        public string ID_Adresse_Societe { get; set; }

        // > Descriptif Facture <
        public string DescriptionFacture { get; set; }

        #endregion

    }
}
