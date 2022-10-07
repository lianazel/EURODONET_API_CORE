using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDonetApi.Interface
{
    public interface IProcessRepository

    {
        #region Methods

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une adresse à une societe  
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        string SocieteAddAdress(string _Id_Key_Master, string _Id_Key_Slave);



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une adresse à un COLLABORATEUR
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string CollabAddAdress(string _Id_Key_Master, string _Id_Key_Slave);


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une SOCIETE  à un COLLABORATEUR
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string CollabAddSociete(string _Id_Key_Master, string _Id_Key_Slave);


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Calculer N° Facture 
        //    Le n° de facture est construit avec : 
        //     -> Le n° de société,
        //     -> Un compteur propre à la société incrémenté
        //        => On obtient alors un numéro unique. 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string FactureCalculerNumero(string _Id_Societe);

        #endregion


    }
}
