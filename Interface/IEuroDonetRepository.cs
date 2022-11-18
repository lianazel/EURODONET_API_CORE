
using API.Core.Framawork;
using EuroDonetApi.Applications.DTOs;
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
        AdresseDto Repo_PostAdresse(AdresseDto Adresse);


        // *****    Adresse  **** 
        // > RENVOYER une adresse  <
        ML_DonetAdresse Repo_GetAdresse(string _IDAdress);


        // ***    Société   ****
        // > RENVOYER  liste des sociétées <
        Dictionary<int, object> Repo_GetListSocietes();

        // ***    Société   ****
        // > INSERER ou Màj une société <
        SocieteDto Repo_PostSociete(SocieteDto _ObjSociete);

        // ***    Société   ****
        // > RENVOYER  une société <
        ML_DonetSociete Repo_GetSociete(string _IDSociete);



        // ***    Collaborateurs   ****
        // > RENVOYER  liste des collaborateurs <
        Dictionary<int, object> Repo_GetListCollabs();

        // ***    Collaborateurs   ****
        // > INSERER ou Màj un collaborateur  <
        CollabDto Repo_PostCollab(CollabDto _ObjCollab);


        // ***    Facture   ****
        // > Générer une facture   <
        FactureGenereDto Repo_GetFacture(FactureDto _DtoIn);

        #endregion

    }
}
