using EuroDonetApi.Interface;
using EuroDotnet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroDonetApi.Controllers
{
    /// <summary>
    ///  Controler for TDD ( Tests ) . Not for Prod 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApTestController : ControllerBase
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
        public ApTestController(IEuroDonetRepository donetrepository)
        {
            // > On charge le membre _DonetRepository avec l'objet injecté <
            _DonetRepository = donetrepository;
        }

        // ### - - - - - - - - - - - - - - - - - -- - - - - - - - - - - - - - -      ###
        // ###                       ***** TDD ****                                  ###
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


            return this.Ok(adresses);
        }

        #endregion

    }

}
