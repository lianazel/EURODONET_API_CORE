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
using EuroDonetApi.Applications.DTOs;

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

        // > On déclare une Instance "_DonetRepository"  de type "IEuroDonetRepository".
        // > C'est le fichier "Startup" qui fera le lien entre l'interface et la classe.
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
        public IActionResult GetListAdresses()
        {
            // > On déclare un LIST<T> de "DonetAdresse" <
            List<ML_DonetAdresse> adresses = new List<ML_DonetAdresse>();

            // > Initiamisation de la liste <
            adresses = null;

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=
            // ####    Récupération du tableau des adresses                                  ###
            // ####    ( Rappel : la méthode " _DonetRepository.Repo_GetListAdresses()...    ###                        
            // ####     ...renvoie un dictionnaire )                                         ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=
            var Dadr = _DonetRepository.Repo_GetListAdresses();
            string Msge = (string)Dadr[1];
            adresses = (List<ML_DonetAdresse>)Dadr[2];

            if (Msge != null)
            { // > On revnoie un status erreur 204 => Pas de données à renvoyer <
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            // > Serialiez la liste d'objets <
            var JsonResult = JsonConvert.SerializeObject(adresses);

            return this.Ok(JsonResult);
            //return (JsonResult);
        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    ### 
        // ###         ADRESSE => DropDowmList ( alimentation Combo )             ###
        // ###             ( Renvoie deux colonnes )                              ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     -### 
        [HttpGet()]
        [Route("GetDropDownListAdresse")]
        public IActionResult GetDropDownListAdresse()
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

            if (Msge != null)
            { // > On revnoie un status erreur 204 => Pas de données à renvoyer <
                return this.StatusCode(StatusCodes.Status204NoContent);
            }
        
          // > Serialiez la liste d'objets <
           var JsonResult = JsonConvert.SerializeObject(DropDownList);
           return this.Ok(JsonResult);
                   
        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - --    ### 
        // ###   ADRESSE => READ                                       ###
        // ###   ( Renvoie une ADRESSE à partir de l'ID Adresse)       ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - -  - - -### 
        [HttpPost("{P}")]
        [Route("GetAdress/{P}")]
        public string   GetAdress([FromQuery]string _IDAdress)
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
        public IActionResult PostAdress([FromBody] AdresseDto _ObjAdress)
        {
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour une adresse                                                             ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_ObjAdress) renvoie  un "AdresseDto"   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            _ObjAdress = _DonetRepository.Repo_PostAdresse(_ObjAdress);

            // > On renvoie un résultat <
            //    ( L'objet de type "AdresseDto" contient l'ID généré ( si création ) 
            //    ( L'objet de type "AdresseDto" contient un message d'erreur si une erreur est détectée )
            return this.Ok(_ObjAdress);
        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // ###   SOCIETE = Liste des sociétés                                                 ###
        // ###   ( Renvoie liste des sociétes )                                               ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // Voir Lien Stack :
        //   https://stackoverflow.com/questions/9110724/serializing-a-list-to-json
        [HttpGet()]
        [Route("GetListSocietes")]
        public IActionResult GetListSocietes()
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

            if (Msge != null)
            { // > On revnoie un status erreur 204 => Pas de données à renvoyer <
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            // > Serialiez la liste des sociétes  <
            var JsonResult = JsonConvert.SerializeObject(societes);
            return this.Ok(JsonResult);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -    ### 
        // ###   SOCIETE => READ                                                              ###
        // ###   ( Renvoie une SOCIETE à partir de l'ID SOCIETE)                              ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -### 
        [HttpPost("{P}")]
        [Route("GetSociete/{P}")]
        public IActionResult GetSociete([FromQuery] string _IDSociete)
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
            return this.Ok(JsonResult);

        }



        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // ###   SOCIETE => CREATE ou UPDATE                                                  ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        [HttpPost("{P}")]
        [Route("PostSociete/{P}")]
        public IActionResult PostSociete([FromBody] SocieteDto _ObjSociete)
        {

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour une société                                                            ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_PostSociete(_ObjSociete) renvoie un SocieteDto   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            _ObjSociete = _DonetRepository.Repo_PostSociete(_ObjSociete);

            // > On renvoie un résultat <
            //    ( L'objet de type "SocieteDto" contient l'ID généré ( si création ) 
            //    ( L'objet de type "SocieteDto" contient un message d'erreur si une erreur est détectée )
            return this.Ok(_ObjSociete);

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ###
        // ###   COLLABORATEUR = Liste des collaborateurs                                 ###
        // ###   ( Renvoie liste des collaborateurs )                                     ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ###
        [HttpGet()]
        [Route("GetListSCollabs")]
        public IActionResult GetListSCollabs()
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


            if (Msge != null)
            { // > On revnoie un status erreur 204 => Pas de données à renvoyer <
                return this.StatusCode(StatusCodes.Status204NoContent);
            }

            // > Serialiez la liste d'objets <
            var JsonResult = JsonConvert.SerializeObject(collabs);
            return this.Ok(JsonResult);

        }



        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   COLLABORATEUR => CREATE ou UPDATE                                            ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpPost("{P}")]
        [Route("PostCollab/{P}")]
        public IActionResult PostCollab([FromBody] CollabDto _ObjCollab)
        {

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Insérer/Mettre à jour d'un collaborateur                                                     ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_PostSociete(_ObjSociete) renvoie CollabDto       ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            _ObjCollab = _DonetRepository.Repo_PostCollab(_ObjCollab);

            // > On renvoie un résultat <
            //    ( L'objet de type "SocieteDto" contient l'ID généré ( si création ) 
            //    ( L'objet de type "SocieteDto" contient un message d'erreur si une erreur est détectée )
            return this.Ok(_ObjCollab);

        }

        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   Facture : Génération                                                         ###
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpGet("{P}")]
        [Route("GetFacture/{P}")]
        public IActionResult GetFacture([FromBody] FactureDto _DtoIn)
        {

            // > Objet  pour le renvoie sous Json <
            var JsonFacture = new FactureGenereDto();

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=
            // ####  Récupération d'une société                                                                    ###
            // #### ( Rappel : la méthode "_DonetRepository.Repo_GetAdresse(_IDAdress) renvoie un enregistrement   ###
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--==-=-=
            JsonFacture = _DonetRepository.Repo_GetFacture(_DtoIn);

            // > Utilise le module Json .Net Core <
            return this.Ok(Json(JsonFacture));

        }
     }

    #endregion

}







