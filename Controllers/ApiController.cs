using Microsoft.AspNetCore.Mvc;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Pour StringBuilder <
using System.Text;

using System.Text.Json;


// > Pour DataControle <
using EuroDotNet_BusinessRules;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using EuroDonetApi.Interface;

// ### =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=
// ###              Employee management by company                               ####  
// ### ----      (This code is the property of J.C CHERID)  ----                 ####
// ### =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=
/// <summary>
/// 
///  20/10/2022 - J.C CHERID : Instal repository to deconect _context from Controler 
/// </summary>


// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EuroDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // > Le contrôleur s'appelle "Api" <

    public class ApiController : Controller
    {
        #region properties

        // > On déclare un membre "_context"...
        //   ...qui pointe sur le DataContext <
        // private readonly EuroDotNet.Data.DataContext _context;

        // On déclare un membre prive QUE personne ne peut modifier 
        private readonly IEuroDonetRepository _DonetRepository;


        // > le string est immuable => on utilise un "StringBuilder" pour optimisation memmoire <
        private StringBuilder ResultAPIAction = new StringBuilder(1000);

        // > Constante de traitements <
        private const string ApiOK = "OK<-->";
        private const string ApiNOK = "NOK<=>";

        #endregion


        #region public methods 

        // Le constructeur reçoit par injection de dépendance une instance qui sera...
        // ... construite dans la classe "Startup.cs" 
        public ApiController(IEuroDonetRepository donetrepository)
        {
            // > On charge le membre _DonetRepository avec l'objet injecté <
            _DonetRepository = donetrepository;
        }




        // ### - - - - - - - - - - - - - - - - - -- - - - - - - - - - - - - - -      ###
        // ###   ADRESSE = Liste des adresses                                        ###
        // ###   ( Renvoie liste des adresses )                                      ### 
        // ### - - - - - - - - - - - - - - - - - -  - - - - - - - - - - - - - -      ###
        [HttpGet()]
        [Route("GetListAdresses")]
        public string
            GetListAdresses()
        {

            // > On déclare un LIST<T> de "DonetAdresse" <
            List<ML_DonetAdresse> adresses = new List<ML_DonetAdresse>();

            // > Initiamisation de la liste <
            adresses = null;

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####    Récupération du tableau des adresses                                                         ###
            // ####    ( Rappel : la méthode " _DonetRepository.Repo_GetListAdresses() renvoie un dictionnaire )    ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            var Dadr = _DonetRepository.Repo_GetListAdresses();
            string Msge = (string)Dadr[1];
            adresses = (List<ML_DonetAdresse>)Dadr[2];


            // > Serialiez la liste d'objets <
            var JsonResult = JsonConvert.SerializeObject(adresses);
            return (JsonResult);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    ### 
        // ###         ADRESSE => DropDowmList ( alimentation Combo )             ###
        // ###             ( Renvoie deux colonnes )                              ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     -### 
        [HttpGet()]
        [Route("GetDropDownListAdresse")]
        public string GetDropDownListAdresse()
        {
            // > Selection de colonnes dans une requête "Linq" : <
            // https://stackoverflow.com/questions/20069154/how-can-i-select-just-two-columns-from-a-list-using-linq

            // > On déclare un LIST<T> de "DonetAdresseDropDownItem" <
            List<ML_DonetAdresseDropDownItem> DropDownList = new List<ML_DonetAdresseDropDownItem>();




            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-===--=-=-=
            // ####  Récupération de la Drop DownList                                                           ###
            // ####  ( Rappel : la méthode " _DonetRepository.Repo_GetDDLAdresses() renvoie un dictionnaire )   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            var DDdl = _DonetRepository.Repo_GetDDLAdresses();
            string Msge = (string)DDdl[1];
            DropDownList = (List<ML_DonetAdresseDropDownItem>)DDdl[2];


            // > Serialiez la liste d'objets <
            var JsonResult = JsonConvert.SerializeObject(DropDownList);
            return (JsonResult);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - --    ### 
        // ###   ADRESSE => READ                                       ###
        // ###   ( Renvoie une ADRESSE à partir de l'ID Adresse)       ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - -  - - -### 
        [HttpPost("{P}")]
        [Route("GetAdress/{P}")]
        public string
        GetAdress(string _IDAdress)
        {
            // > String pour renvoi au format Json <
            string JsonResult;
            JsonResult = null;

            // > Instancie un objet modèle "Adresse" <
            var AD = new ML_DonetAdresse();

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Récupération d'une adresse                                                                    ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_IDAdress) renvoie un enregistrement   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            AD = _DonetRepository.Repo_GetAdresse(_IDAdress);

            // > Serialiez l'enregistrement  <
            JsonResult = JsonConvert.SerializeObject(AD);

            // > Renvoi de l'enregistrement <
            return (JsonResult);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    ### 
        // ###   ADRESSE => CREATE ou UPDATE                                                  ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -### 
        [HttpPost("{P}")]
        [Route("PostAdress/{P}")]
        public string PostAdress(ML_DonetAdresse _ObjAdress)
        {


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour une adresse                                                             ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_IDAdress) renvoie  un string          ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            string Msge = _DonetRepository.Repo_PostAdresse(_ObjAdress);

            // > On renvoie un résultat <
            return this.Ok(Msge).ToString();

        }

        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // ###   SOCIETE = Liste des sociétés                                                 ###
        // ###   ( Renvoie liste des sociétes )                                               ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // Voir Lien Stack :
        //   https://stackoverflow.com/questions/9110724/serializing-a-list-to-json
        [HttpGet()]
        [Route("GetListSocietes")]
        public string GetListSocietes()
        {

            // > On déclare un LIST<T> de "DonetSociete" <
            List<ML_DonetSociete> societes = new List<ML_DonetSociete>();

            // > Initiamisation de la liste <
            societes = null;


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####    Récupération du tableau des sociétés                                                         ###
            // ####    ( Rappel : la méthode " _DonetRepository.Repo_GetListSocietes() renvoie un dictionnaire )    ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            var DSocr = _DonetRepository.Repo_GetListSocietes();
            string Msge = (string)DSocr[1];
            societes = (List<ML_DonetSociete>)DSocr[2];


            // > Serialiez la liste des sociétes  <
            var JsonResult = JsonConvert.SerializeObject(societes);
            return (JsonResult);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    ### 
        // ###   SOCIETE => READ                                                              ###
        // ###   ( Renvoie une SOCIETE à partir de l'ID SOCIETE)                              ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -### 
        [HttpPost("{P}")]
        [Route("GetSociete/{P}")]
        public string
        GetSociete(string _IDSociete)
        {
            // > String pour renvoi au format Json <
            string JsonResult;
            JsonResult = null;

            // > Instancie un objet modèle "Societe" <
            var AS = new ML_DonetSociete();



            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Récupération d'une société                                                                    ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_IDAdress) renvoie un enregistrement   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            AS = _DonetRepository.Repo_GetSociete(_IDSociete);

            // > Serialiez l'enregistrement de la société <
            JsonResult = JsonConvert.SerializeObject(AS);

            // > Renvoi de l'enregistrement <
            return (JsonResult);

        }



        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // ###   SOCIETE => CREATE ou UPDATE                                                  ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        [HttpPost("{P}")]
        [Route("PostSociete/{P}")]
        public string PostSociete(ML_DonetSociete _ObjSociete)
        {

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour une société                                                            ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_PostSociete(_ObjSociete) renvoie un string       ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            string Msge = _DonetRepository.Repo_PostSociete(_ObjSociete);
            // > On renvoie un résultat <
            return this.Ok(Msge).ToString();

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ###
        // ###   COLLABORATEUR = Liste des collaborateurs                                 ###
        // ###   ( Renvoie liste des collaborateurs )                                     ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ###
        [HttpGet()]
        [Route("GetListSCollabs")]
        public string GetListSCollabs()
        {

            // > On déclare un LIST<T> de "DonetCollab" <
            List<ML_DonetCollab> collabs = new List<ML_DonetCollab>();

            // > Initiamisation de la liste <
            collabs = null;

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####    Récupération du tableau des collaborateurs                                                    ###
            // ####    ( Rappel : la méthode " _DonetRepository.Repo_GetListCollabs() renvoie un dictionnaire )      ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            var DCol = _DonetRepository.Repo_GetListCollabs();
            string Msge = (string)DCol[1];
            collabs = (List<ML_DonetCollab>)DCol[2];


            // > Serialiez la liste d'objets <
            var JsonResult = JsonConvert.SerializeObject(collabs);
            return (JsonResult);

        }



        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   COLLABORATEUR => CREATE ou UPDATE                                            ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpPost("{P}")]
        [Route("PostCollab/{P}")]
        public string PostCollab(ML_DonetCollab _ObjCollab)
        {


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour d'un collaborateur                                                     ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_PostSociete(_ObjSociete) renvoie string          ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            string Msge = _DonetRepository.Repo_PostCollab(_ObjCollab);

            // > On renvoie un résultat <
            return this.Ok(Msge).ToString();



        }

        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   Facture : Génération                                                         ###
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpGet("{P}")]
        [Route("GetFacture/{P}")]
        public IActionResult GetFacture(ML_Genere_Facture_IN _ObjGenereFacture)
        {

            // > Objet  pour le renvoie sous Json <
            var JsonFacture = new ML_Genere_Facture_OUT();


            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Récupération d'une société                                                                    ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_IDAdress) renvoie un enregistrement   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            JsonFacture = _DonetRepository.Repo_GetFacture(_ObjGenereFacture);


            // > Utilise le module Json .Net Core <
            return Json(JsonFacture);

        }

    }

    #endregion

}







