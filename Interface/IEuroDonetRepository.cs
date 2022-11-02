
using API.Core.Framawork;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDonetApi.Interface
{
    /// <summary>
    /// Interface for "DefaultEuroDonetRepository" (Inherited from "IRepository")
    /// </summary>

    public interface IEuroDonetRepository : IRepository
    {
        #region méthods 
        // *****    Adresse  **** 
        // > Renoyer Liste des adresses <
        Dictionary<int, object> Repo_GetListAdresses();

        // *****    Adresse  **** 
        // > Renoyer Drop Down List <
        //   ( Equivalent Combo )
        Dictionary<int, object> Repo_GetDDLAdresses();

        // *****    Adresse  **** 
        // > INSERER ou Màj une adresse  <
        string Repo_PostAdresse(ML_DonetAdresse Adresse);


        // *****    Adresse  **** 
        // > RENVOYER une adresse  <
        ML_DonetAdresse Repo_GetAdresse(string _IDAdress);


        // ***    Société   ****
        // > RENVOYER  liste des sociétées <
        Dictionary<int, object> Repo_GetListSocietes();

        // ***    Société   ****
        // > INSERER ou Màj une société <
        string Repo_PostSociete(ML_DonetSociete _ObjSociete);

        // ***    Société   ****
        // > RENVOYER  une société <
        ML_DonetSociete Repo_GetSociete(string _IDSociete);



        // ***    Collaborateurs   ****
        // > RENVOYER  liste des collaborateurs <
        Dictionary<int, object> Repo_GetListCollabs();

        // ***    Collaborateurs   ****
        // > INSERER ou Màj un collaborateur  <
        string Repo_PostCollab(ML_DonetCollab _ObjCollab);


        // ***    Facture   ****
        // > Générer une facture   <
        ML_Genere_Facture_OUT Repo_GetFacture(ML_Genere_Facture_IN _ObjGenereFacture);

        #endregion

    }
}
