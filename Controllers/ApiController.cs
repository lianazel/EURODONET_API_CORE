using Microsoft.AspNetCore.Mvc;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// > Pour StringBuilder <
using System.Text;

// > Pour DataControle <
using EuroDotNet_BusinessRules;

// For more information on enabling Web API for empty projects,
// visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EuroDotNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // > Le contrôleur s'appelle "Api" <

    // > La classe "Controller" permet la gestion du Json" <
    // ( Rappel : la classe "Controller" hérite de la classe "ControllerBase" )
    public class ApiController : Controller
    {
        // > On déclare un membre "_context"...
        //   ...qui pointe sur le DataContext <
        private readonly EuroDotNet.Data.DataContext _context;


        // > Le constructeur reçoit un paramètre "context" de type...
        // ...DataContext  <
        public ApiController(EuroDotNet.Data.DataContext context)
        {
            // > On charge le membre de la classe avec le paramètre...
            //   ...reçu par le constructeur <
            _context = context;
        }


        // > le string est immuable => on utilise un "StringBuilder" pour optimisation memmoire <
        private StringBuilder ResultAPIAction = new StringBuilder(1000);

        // > Constante de traitements <
        private const string ApiOK = "OK<-->";
        private const string ApiNOK = "NOK<=>";


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   ADRESSE => CREATE ou UPDATE                                    ###
        // ###   ( Analyse valeur de ID Adresse pour savoir si CREATE / UPDATE )### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -### 
        [HttpPost("{P}")]
        [Route("PostAdress/{P}")]
        public string
            PostAdress(DonetAdresse _ObjAdress)
        {
            // > Par défaut, optimiste <
            ResultAPIAction.Append(ApiOK);


            // > On a lancé la recherche dans la base pour vérifier que la société existe  < 
            var ObjAdresseLU = _context.Adresse.FirstOrDefault(f => f.Id_Adresse ==
            _ObjAdress.Id_Adresse);

            // - - - - - - - - -
            // > == CREATION ( La lecture de l'enregistrement n'RIEN RENVOYE  ) <
            // - - - - - - - - -
            if (ObjAdresseLU == null)
            {

                // > (1A) ==> On crée un nouvel objet BDD pour recevoir les data's du paramètre <
                var NewAdress = new DonetAdresse();

                //  ==> Chargement des data's  <
                NewAdress.Adresse_1 = _ObjAdress.Adresse_1;
                NewAdress.Adresse_2 = _ObjAdress.Adresse_2;
                NewAdress.CodePostal = _ObjAdress.CodePostal;
                NewAdress.NumVoie = _ObjAdress.NumVoie;
                NewAdress.TypVoie = _ObjAdress.TypVoie;
                NewAdress.Region = _ObjAdress.Region;
                NewAdress.Pays = _ObjAdress.Pays;


                // > (1B) ==>Création d'un ID et chargement des data's  <
                //     ==> Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                Guid IDGuid = Guid.NewGuid();

                // > Génération de l'ID  par programme <
                NewAdress.Id_Adresse = IDGuid.ToString();

                // > On renvoie l'ID calculé <
                //   ( On l'ajoute à OK<--> )
                ResultAPIAction.Append(NewAdress.Id_Adresse);

                try
                {

                    // >  (1C) ==> En CREATION ==> Ajout dans le contexte <  <
                    _context.Adresse.Add(NewAdress);

                }

                // > Une erreur est détectée <
                catch (Exception E)
                {

                    // > On intialise le string <
                    ResultAPIAction.Remove(0, 5);

                    ResultAPIAction.Append(E.Message);

                }

                finally
                {


                }
            }

            // - - - - - - - - -
            // > == UPDATE  ( La lecture de l'enregistrement A RENVOYE UN RECORD  ) <
            // - - - - - - - - -
            else

            {
                //  ==> Chargement des data's  <
                ObjAdresseLU.Adresse_1 = _ObjAdress.Adresse_1;
                ObjAdresseLU.Adresse_2 = _ObjAdress.Adresse_2;
                ObjAdresseLU.CodePostal = _ObjAdress.CodePostal;
                ObjAdresseLU.NumVoie = _ObjAdress.NumVoie;
                ObjAdresseLU.TypVoie = _ObjAdress.TypVoie;
                ObjAdresseLU.Region = _ObjAdress.Region;
                ObjAdresseLU.Pays = _ObjAdress.Pays;

            }

            try
            {
                // >  (2) ==> En CREATE/UPDATE ==> confirme changement <  <
                _context.SaveChanges();
            }

            // > Une erreur est détectée <
            catch (Exception E)
            {

                // > On intialise le string <
                ResultAPIAction.Remove(0, 5);

                ResultAPIAction.Append(E.Message);
            }

            finally
            {


            }


            // > On renvoie un résultat <
            return ResultAPIAction.ToString();

        }


        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        // ###   SOCIETE => CREATE ou UPDATE                                                  ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -      ###
        [HttpPost("{P}")]
        [Route("PostSociete/{P}")]
        public string PostSociete(DonetSociete _ObjSociete)
        {

            // > Mémorisation ID Société <
            //   ( Pour mise à jour des adresses d'une société <
            string ID_Societe_ME;

            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            // ==== CTL VALIDITE ADRESSE de la SOCIETE       ====
            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            var ObjDataCtl = new DataControl(_context);
            // > On appelle la méthode "ChkAdresse()" et on récupère le resultat dans "ResultAPIAction" <
            ResultAPIAction.Append(ObjDataCtl.ChkAdresse(_ObjSociete.FK_ID_Adresse));
            // > Si le controle de validité de l'adresse est OK, on continue <
            //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )

            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            // ==== CREATE/UPDATE de la SOCIETE              ====
            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            if (ResultAPIAction.ToString() == ApiOK)
            {

                // > On a lancé la recherche dans la base pour vérifier que la société existe  < 
                var ObjSocieteLU = _context.Societe.FirstOrDefault(f => f.Id_Societe ==
                _ObjSociete.Id_Societe);

                // - - - - - - - - -
                // > == CREATION ( La lecture de l'enregistrement n'RIEN RENVOYE  ) <
                // - - - - - - - - -
                if (ObjSocieteLU == null)
                {
                    // > (1A) ==> On crée un nouvel objet BDD pour recevoir les data's du paramètre <
                    var NewSociete = new DonetSociete();

                    //  ==> Chargement des data's  <
                    NewSociete.NumSiren = _ObjSociete.NumSiren;
                    NewSociete.RaisonSociale = _ObjSociete.RaisonSociale;
                    NewSociete.NumSiren = _ObjSociete.NumSiren;
                    NewSociete.NumTVAIntra = _ObjSociete.NumTVAIntra;
                    NewSociete.CapitalSocial = _ObjSociete.CapitalSocial;
                    NewSociete.ChiffreAffaire = _ObjSociete.ChiffreAffaire;

                    // > (1B) ==>Création d'un ID et chargement des data's  <
                    //     ==> Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                    Guid IDGuid = Guid.NewGuid();

                    // > Mémorisation ID Société qui vient d'être Crée <
                    ID_Societe_ME = IDGuid.ToString();

                    // > Génération de l'ID  par programme <
                    NewSociete.Id_Societe = ID_Societe_ME;

                    // > Calcul du n° de société <

                    // > On a lanccé la recherche dans la base pour récupérer le N° de la société  < 
                    var ObjRecupNumSoc = _context.Societe.OrderByDescending(F => F.NumSociete).FirstOrDefault();
                    if (ObjRecupNumSoc != null)
                    {

                        NewSociete.NumSociete = (ObjRecupNumSoc.NumSociete) + 1;

                    }
                    else { NewSociete.NumSociete = 1; }

                    // > On renvoie le N° de société initialisé  <
                    ResultAPIAction.Append(NewSociete.Id_Societe);
                    try
                    {

                        // >  (1C) ==> En CREATION ==> Ajout dans le contexte <  <
                        _context.Societe.Add(NewSociete);

                    }

                    // > Une erreur est détectée <
                    catch (Exception E)
                    {

                        // > On intialise le string <
                        ResultAPIAction.Remove(0, 5);

                        ResultAPIAction.Append(E.Message);

                    }

                    finally
                    {


                    }

                }

                // - - - - - - - - -
                // > == UPDATE  ( La lecture de l'enregistrement A RENVOYE UN RECORD  ) <
                // - - - - - - - - -
                else

                {
                    //  ==> Chargement des data's  <
                    ObjSocieteLU.NumSiren = _ObjSociete.NumSiren;
                    ObjSocieteLU.RaisonSociale = _ObjSociete.RaisonSociale;
                    ObjSocieteLU.NumSiren = _ObjSociete.NumSiren;
                    ObjSocieteLU.NumTVAIntra = _ObjSociete.NumTVAIntra;

                    // >  // > Mémorisation ID Société qui vient d'être LU  <
                    ID_Societe_ME = ObjSocieteLU.Id_Societe;

                }

                try
                {
                    // >  (2) ==> En CREATE/UPDATE ==> confirme changement <  <
                    _context.SaveChanges();


                    // ==== - - - - - - - - - - - - - - - - - - - - - - - - - -
                    // ==== (3) Une société peut AVOIR PLUSIEURS ADRESSES  ====
                    // ====     Ajoute l'ID adresse à la société           ====
                    // ==== - - - - - - - - - - - - - - - - - - - - - - - - - - 
                    var ObjDataProcess = new DataProcess(_context);
                    ResultAPIAction.Append(ObjDataProcess.SocieteAddAdress(ID_Societe_ME, _ObjSociete.FK_ID_Adresse));
                    //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )

                }

                // > Une erreur est détectée <
                catch (Exception E)
                {

                    // > On intialise le string <
                    ResultAPIAction.Remove(0, 5);

                    ResultAPIAction.Append(E.Message);

                }

                finally
                {


                }

            }


            // > On renvoie un résultat <
            return ResultAPIAction.ToString();

        }

        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   COLLABORATEUR => CREATE ou UPDATE                                            ###
        // ###   ( Analyse état objet renvoyé par lecture  pour savoir si CREATE / UPDATE )   ### 
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpPost("{P}")]
        [Route("PostCollab/{P}")]
        public string PostCollab(DonetCollab _ObjCollab)
        {

            // > Mémorisation ID Collaborateur <
            //   ( Pour mise à jour des adresses & des sociétés d'un collaborateur <
            string ID_Collab_ME;

            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            // ==== CTL VALIDITE ADRESSE de COLLABORATEUR       ====
            // ==== - - - - - - - - - - - - - - - - - - - - - - -
            var ObjDataCtl = new DataControl(_context);
            // > On appelle la méthode "ChkAdresse()" et on récupère le resultat dans "ResultAPIAction" <
            ResultAPIAction.Append(ObjDataCtl.ChkAdresse(_ObjCollab.FK_ID_Adresse));
            // > Si le controle de validité de l'adresse est OK, on continue <
            //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )


            if (ResultAPIAction.ToString() == ApiOK)

            {
                // ==== - - - - - - - - - - - - - - - - - - - - - - -
                // ==== CTL VALIDITE SOCIETE de COLLABORATEUR       ====
                // ==== - - - - - - - - - - - - - - - - - - - - - - -
                // > On intialise le string <
                try
                {
                    ResultAPIAction.Remove(0, 6);
                }
                catch
                {

                }
                // > On appelle la méthode "ChkSociete()" et on récupère le resultat dans "ResultAPIAction" <
                ResultAPIAction.Append(ObjDataCtl.ChkSociete(_ObjCollab.FK_ID_Societe));
                // > Si le controle de validité de l'adresse est OK, on continue <
                //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )


                // ==== - - - - - - - - - - - - - - - - - - - - - - -
                // ==== CREATE/UPDATE de COLLABORATEUR              ====
                // ==== - - - - - - - - - - - - - - - - - - - - - - -
                if (ResultAPIAction.ToString() == ApiOK)
                {

                    // > On a lancé la recherche dans la base pour vérifier que la société existe  < 
                    var ObjCollabLU = _context.Collab.FirstOrDefault(f => f.Id_Collaborateur ==
                    _ObjCollab.Id_Collaborateur);

                    // - - - - - - - - -
                    // > == CREATION ( La lecture de l'enregistrement n'RIEN RENVOYE  ) <
                    // - - - - - - - - -
                    if (ObjCollabLU == null)
                    {
                        // > (1A) ==> On crée un nouvel objet BDD pour recevoir les data's du paramètre <
                        var NewCollab = new DonetCollab();

                        //  ==> Chargement des data's  <
                        NewCollab.Nom = _ObjCollab.Nom;
                        NewCollab.Prenom = _ObjCollab.Prenom;
                        NewCollab.NumInsee = _ObjCollab.NumInsee;

                        // > (1B) ==>Création d'un ID et chargement des data's  <
                        //     ==> Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                        Guid IDGuid = Guid.NewGuid();

                        // > Mémorisation ID Collaborateur qui vient d'être Crée <
                        ID_Collab_ME = IDGuid.ToString();

                        // > Génération de l'ID  par programme <
                        NewCollab.Id_Collaborateur = ID_Collab_ME;

                        // > On renvoie l'ID calculé <
                        //   ( On l'ajoute à OK<--> )
                        ResultAPIAction.Append(NewCollab.Id_Collaborateur);

                        try
                        {

                            // >  (1C) ==> En CREATION ==> Ajout dans le contexte <  <
                            _context.Collab.Add(NewCollab);

                        }

                        // > Une erreur est détectée <
                        catch (Exception E)
                        {

                            // > On intialise le string <
                            ResultAPIAction.Remove(0, 5);

                            ResultAPIAction.Append("ERR_AJOUTCOLLAB_1A__" + E.Message);

                        }

                        finally
                        {


                        }

                    }

                    // - - - - - - - - -
                    // > == UPDATE  ( La lecture de l'enregistrement A RENVOYE UN RECORD  ) <
                    // - - - - - - - - -
                    else

                    {
                        //  ==> Chargement des data's  <
                        ObjCollabLU.Nom = _ObjCollab.Nom;
                        ObjCollabLU.Prenom = _ObjCollab.Prenom;
                        ObjCollabLU.NumInsee = _ObjCollab.NumInsee;

                        // >  // > Mémorisation ID Société qui vient d'être LU  <
                        ID_Collab_ME = ObjCollabLU.Id_Collaborateur;

                    }

                    try
                    {
                        // >  (2) ==> En CREATE/UPDATE ==> confirme changement <  <
                        _context.SaveChanges();


                        // ==== - - - - - - - - - - - - - - - - - - - - - - - - - -
                        // ==== (3A) Un Collaborateur peut AVOIR PLUSIEURS ADRESSES  ====
                        // ====     Ajoute l'ID adresse à un collaborateur           ====
                        // ==== - - - - - - - - - - - - - - - - - - - - - - - - - - 
                        // > On intialise le string <
                        try
                        {
                            ResultAPIAction.Remove(0, 6);
                        }
                        catch
                        {

                        }
                        var ObjDataProcess = new DataProcess(_context);
                        ResultAPIAction.Append(ObjDataProcess.CollabAddAdress(ID_Collab_ME, _ObjCollab.FK_ID_Adresse));
                        //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )

                        if (ResultAPIAction.ToString() == ApiOK)
                        {
                            // ==== - - - - - - - - - - - - - - - - - - - - - - - - - -
                            // ==== (3B) Une Collaborateur peut AVOIR PLUSIEURS SOCIETES ====
                            // ====     Ajoute l'ID societe à un collaborateur          ====
                            // ==== - - - - - - - - - - - - - - - - - - - - - - - - - - 
                            // > On intialise le string <
                            try
                            {
                                ResultAPIAction.Remove(0, 6);
                            }
                            catch
                            {

                            }
                            ResultAPIAction.Append(ObjDataProcess.CollabAddSociete(ID_Collab_ME, _ObjCollab.FK_ID_Societe));
                            //    (  Voir valeur de "ResultAPIAction" au retour de l'appel de la méthode )
                        }

                    }

                    // > Une erreur est détectée <
                    catch (Exception E)
                    {

                        // > On intialise le string <
                        ResultAPIAction.Remove(0, 5);

                        ResultAPIAction.Append("ERR_AJOUTCOLLAB_2A__" + E.Message);

                    }

                    finally
                    {


                    }

                }

            }

            // > On renvoie un résultat <
            return ResultAPIAction.ToString();

        }

        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        // ###   Facture : Génération                                                         ###
        // ### - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  ### 
        [HttpGet("{P}")]
        [Route("GetFacture/{P}")]
        public IActionResult GetFacture(Genere_Facture_IN _ObjGenereFacture)
        {
            // > Objet  pour le renvoie sous Json <
            var JsonFacture = new Genere_Facture_OUT();

            // > Réception de l'adresse LU <
            var ObjAdresseLu = new DonetAdresse();

            // > Réception de la socioété LU <
            var ObjSocieteLu = new DonetSociete();

            // > Génération d'une facture en Base de données <
            var NewFacture = new DonetFactureGeneration();

            // > String qui va recevoir le N° unique de facture <
            string NumFacCalcule;
            NumFacCalcule = "";

            // > Démarre generation facture si paramètres transmis NON NULL <
            if (_ObjGenereFacture != null)
            {

                // =-=-=-=-=-=-=-=-=-=-=-=-=
                //  ### Calcul N° facture 
                // =-=-=-=-=-=-=-=-=-=-=-=-=
                var ObjDataProcess = new DataProcess(_context);
                // ==> Correction 7/6/2022 : je me suis trompé dans l'ID. J'ai corrigé avec "_ObjGenereFacture.ID_Societe". <
                NumFacCalcule = ObjDataProcess.FactureCalculerNumero(_ObjGenereFacture.ID_Societe);
                if (NumFacCalcule==null)
                {
                    JsonFacture.ErrorMessage = "ERR_CALFAC_1A_" + "Numéro de facture null. Traitememt impossible";
                    // > Utilise le module Json .Net Core <
                    return Json(JsonFacture);
                }


                //=-=-=-=-=-=-=-=-=-=-=
                // ### Extraction Infos Société & Adresse Societe 
                //=-=-=-=-=-=-=-=-=-=-=
                // > Extraction Societe <
                ObjSocieteLu = _context.Societe.Where(F => F.Id_Societe == _ObjGenereFacture.ID_Societe)
                   .FirstOrDefault();

                // > Extraction Adresse <
                ObjAdresseLu = _context.Adresse.Where(F => F.Id_Adresse == _ObjGenereFacture.ID_Adresse_Societe)
                     .FirstOrDefault();

                //=-=-=-=-=-=-=-=-=-=-=
                // ### Generation Enregistrement Facture 
                //=-=-=-=-=-=-=-=-=-=-=

                // > Data facture <
                NewFacture.DateFacture = DateTime.Now;
                // > N° Facture <
                NewFacture.NumeroFacture = NumFacCalcule;
                // > ID Société facture <
                NewFacture.FK_ID_Societe = _ObjGenereFacture.ID_Societe;
                // > ID Adresse société  facture <
                NewFacture.FK_ID_Adresse_Societe = _ObjGenereFacture.ID_Adresse_Societe;
                // > Description Facture  <
                NewFacture.DescriptionFacture = _ObjGenereFacture.DescriptionFacture;

                // > (1B) ==>Création d'un ID et chargement des data's  <
                //     ==> Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                Guid IDGuid = Guid.NewGuid();

                // > Génération de l'ID  par programme <
                NewFacture.Id_FactureGeneration = IDGuid.ToString();

                try
                {

                    // >  En CREATION ==> Ajout dans le contexte < 
                    _context.FactureGeneration.Add(NewFacture);
                    _context.SaveChanges();
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {

                    JsonFacture.ErrorMessage = "ERR_GENFAC_1A_" + E.Message;

                }

                finally
                {
                }
            }


            else
            { JsonFacture.ErrorMessage = "ERR_GENFAC_2A_" + "Traitement impossible => paramètres reçus invalides"; }

            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=
            // ### Construction de l'objet Json 
            // =-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=
            //   > Pas d'erreur détectée => On geneère un objet Json <
            if (JsonFacture.ErrorMessage == null)
            {
                // > N° facture  <
                JsonFacture.Numero = NewFacture.NumeroFacture;

                // > Adresse la société <
                JsonFacture.Adresse = ObjAdresseLu;

                // > Date Facture  <
                JsonFacture.Date = NewFacture.DateFacture;

                // > Description facture  <
                JsonFacture.Description = NewFacture.DescriptionFacture;

                // > N° TVA Intra Communautaire <
                JsonFacture.NumTVAIntra = ObjSocieteLu.NumTVAIntra;

            }

            // > Utilise le module Json .Net Core <
            return Json(JsonFacture);

        }

    }

}







