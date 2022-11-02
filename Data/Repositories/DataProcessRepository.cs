using API.Core.Framework;
using EuroDonetApi.Interface;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroDonetApi.Data.Repositories
{
    public class DataProcessRepository : IDataProcessRepository
    {

        // > On déclare un membre "_context"...
        //   ...qui pointe sur le DataContext <
        private readonly EuroDotNet.Data.DataContext _context;


        // > le string est immuable => on utilise un "StringBuilder" pour optimisation memmoire <
        private StringBuilder ResultAction = new StringBuilder(1000);

        // > Constante de traitements <
        private const string CtlDataOK = "OK<-->";
        private const string CtlDataNOK = "NOK<=>";

        public IUnitOfWork UnitOfWork => this._context;


        // > Constructeur avec paramètre du contexte <
        public DataProcessRepository(EuroDotNet.Data.DataContext context)
        {
            // > On charge le membre de la classe avec le paramètre...
            //   ...reçu par le constructeur <
            _context = context;

        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une adresse à une societe  
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string SocieteAddAdress(string _Id_Key_Master, string _Id_Key_Slave)
        {
            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultAction.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, positionner à "optimiste" < 
            ResultAction.Append(CtlDataOK);

            // > Construit nouvel objet pour insertion en base <
            var NewSocAdr = new ML_DonetSocAdr();

            // > On a lancer la recherche dans la base pour savoir si il faut ajouter une adresse à la société < 
            var ObjSocAdress = _context.SocAdr.Where(f => f.Fk_Id_Societe == _Id_Key_Master &&
            f.Fk_Id_Adress == _Id_Key_Slave).FirstOrDefault();

            // > L'enregistrement n'est pas trouvé <
            if (ObjSocAdress == null)
            {
                NewSocAdr.Fk_Id_Societe = _Id_Key_Master;
                NewSocAdr.Fk_Id_Adress = _Id_Key_Slave;

                // => Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                Guid IDGuid = Guid.NewGuid();
                NewSocAdr.Id_SocieteAdresse = IDGuid.ToString();


                try
                {
                    // > On AJOUTE un enrereistrement COUPLE "SOCIETE/ADRESSE" <
                    _context.SocAdr.Add(NewSocAdr);

                }

                // > Une erreur est détectée <
                catch (Exception E)
                {

                    // > On intialise le string <
                    ResultAction.Remove(0, 5);

                    ResultAction.Append("ERR_SOCADR_1A__" + E.Message);

                }

                finally
                {


                }


                // ==> En CREATE/UPDATE ==> confirme changement <  
                try
                {
                    // >  (2) ==> En CREATE/UPDATE ==> confirme changement <  <
                    _context.SaveChanges();
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {

                    // > On intialise le string <
                    ResultAction.Remove(0, 5);

                    ResultAction.Append("ERR_SOCADR_2A__" + E.Message);

                }

                finally
                {


                }
            }



            return ResultAction.ToString();

        }



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une adresse à un COLLABORATEUR
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string CollabAddAdress(string _Id_Key_Master, string _Id_Key_Slave)
        {
            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultAction.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, positionner à "optimiste" < 
            ResultAction.Append(CtlDataOK);

            // > Construit nouvel objet pour insertion en base <
            var NewColAdr = new ML_DonetColAdr();

            // > On a lancer la recherche dans la base pour savoir si il faut ajouter une adresse un collaborateur  < 
            var ObjCollabAdress = _context.ColAdr.Where(f => f.Fk_Id_Collab == _Id_Key_Master &&
            f.Fk_Id_Adress == _Id_Key_Slave).FirstOrDefault();

            // > L'enregistrement n'est pas trouvé <
            if (ObjCollabAdress == null)
            {
                NewColAdr.Fk_Id_Collab = _Id_Key_Master;
                NewColAdr.Fk_Id_Adress = _Id_Key_Slave;

                // => Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                Guid IDGuid = Guid.NewGuid();
                NewColAdr.Id_CollabAdresse = IDGuid.ToString();

                try
                {
                    // > On AJOUTE un enrereistrement COUPLE "COLLABORATEUR/ADRESSE" <
                    _context.ColAdr.Add(NewColAdr);
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {
                    // > On intialise le string <
                    ResultAction.Remove(0, 5);
                    ResultAction.Append("ERR_COLLABADR_1A__" + E.Message);
                }

                finally
                {

                }


                // ==> En CREATE/UPDATE ==> confirme changement <  
                try
                {
                    _context.SaveChanges();
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {
                    // > On intialise le string <
                    ResultAction.Remove(0, 5);
                    ResultAction.Append("ERR_COLLABADR_2A__" + E.Message);
                }

                finally
                {

                }
            }

            return ResultAction.ToString();

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajouter une SOCIETE  à un COLLABORATEUR
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string CollabAddSociete(string _Id_Key_Master, string _Id_Key_Slave)
        {
            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultAction.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, positionner à "optimiste" < 
            ResultAction.Append(CtlDataOK);

            // > Construit nouvel objet pour insertion en base <
            var NewColSoc = new ML_DonetColSoc();

            // > On a lancer la recherche dans la base pour savoir si il faut ajouter une adresse un collaborateur  < 
            var ObjCollabSociete = _context.ColSoc.Where(f => f.Fk_Id_Collaborateur == _Id_Key_Master &&
            f.Fk_Id_Societe == _Id_Key_Slave).FirstOrDefault();

            // > L'enregistrement n'est pas trouvé <
            if (ObjCollabSociete == null)
            {
                NewColSoc.Fk_Id_Collaborateur = _Id_Key_Master;
                NewColSoc.Fk_Id_Societe = _Id_Key_Slave;

                // => Création d'un nouveau Guid Unique pour le futur ID calculé par le code <
                Guid IDGuid = Guid.NewGuid();
                NewColSoc.Id_CollaborateurSociete = IDGuid.ToString();

                try
                {
                    // > On AJOUTE un enrereistrement COUPLE "COLLABORATEUR/SOCIETE" <
                    _context.ColSoc.Add(NewColSoc);
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {
                    // > On intialise le string <
                    ResultAction.Remove(0, 5);
                    ResultAction.Append("ERR_COLLABSOC_1A__" + E.Message);
                }

                finally
                {

                }

                // ==> En CREATE/UPDATE ==> confirme changement <  
                try
                {
                    _context.SaveChanges();
                }

                // > Une erreur est détectée <
                catch (Exception E)
                {
                    // > On intialise le string <
                    ResultAction.Remove(0, 5);
                    ResultAction.Append("ERR_COLLABSOC_2A__" + E.Message);
                }

                finally
                {
                }
            }

            return ResultAction.ToString();

        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Calculer N° Facture 
        //    Le n° de facture est construit avec : 
        //     -> Le n° de société,
        //     -> Un compteur propre à la société incrémenté
        //        => On obtient alors un numéro unique. 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string FactureCalculerNumero(string _Id_Societe)
        {

            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultAction.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, positionner à "optimiste" < 
            ResultAction.Append(CtlDataOK);

            // > Pour construction du n° de facture final <
            StringBuilder NumFac = new StringBuilder(10);

            // > Extraction du compteur de facture <
            long CptNumFac;

            // > Le paramètre rçu est-il valide ? <
            if (_Id_Societe == null)
            {
                NumFac = null;
                return NumFac.ToString();
            }

            else
            {

                // - - - - - - - - - - - - - - - - - - - - 
                // ### Phase 1 - Extraction du n° de société 
                // - - - - - - - - - - - - - - - - - - - - 
                // > On a lancé la recherche dans la base pour lire une societe avec l'ID transmis  < 
                var ObjSocieteLU = _context.Societe.Where(F => F.Id_Societe == _Id_Societe).FirstOrDefault();
                if (ObjSocieteLU != null)
                {
                    // > On récupère le n° de société  pour l'ID société transmis <
                    NumFac.Append(ObjSocieteLU.NumSociete.ToString());
                }
                else
                {
                    NumFac = null;
                    return NumFac.ToString();
                }


                // - - - - - - - - - - - - - - - - - - - - 
                // ### Phase 2 - Incrémentation compteur pour la société dont l'ID a été transmis 
                // - - - - - - - - - - - - - - - - - - - - 
                // > On a lance la recherche pour extraire le dernier NUmédo de facture calculé <
                var ObjDernierNumFacture = _context.FactureCalculNum.Where(E => E.FK_ID_Societe == _Id_Societe)
                    .OrderByDescending(F => F.SocCompteur).FirstOrDefault();
                // > La lecture a abouti ==> on incrémente le n° de facture <
                if (ObjDernierNumFacture != null)
                {
                    ObjDernierNumFacture.SocCompteur = (ObjDernierNumFacture.SocCompteur) + 1;
                    CptNumFac = ObjDernierNumFacture.SocCompteur;
                }

                // > La lecture n'a PAS abouti ==> on initialise le n° de facture <
                //   ( On créé un enregistrement pour la société dont on a reçu l'ID )
                else
                {
                    // > => On crée un nouvel objet BDD pour initialiser le n° de facture <
                    var NewNumFacture = new ML_DonetFactureCalculNum();
                    //  > Init du compteur pour la société <
                    NewNumFacture.SocCompteur = 1;
                    //  > Installation de la clé étrangère ( ID de la société ) <
                    NewNumFacture.FK_ID_Societe = _Id_Societe;

                    // > Ajout enregistrement dans contexte <
                    _context.FactureCalculNum.Add(NewNumFacture);

                    // > Recupération compteur calculé <
                    CptNumFac = NewNumFacture.SocCompteur;

                }

                // > On confirme les modifications 
                _context.SaveChanges();

                // - - - - - - - - - - - - - - - - - - - - 
                // ### Phase 3 - Création du n° de facture UNIQUE 
                // - - - - - - - - - - - - - - - - - - - - 
                //   > On concatene le N° de société +"."+Le compteur
                NumFac.Append(".");
                NumFac.Append(CptNumFac.ToString());


                return NumFac.ToString();

            }
        }

    }


}

