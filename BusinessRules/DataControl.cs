using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// > Accès aux données <
using EuroDotNet.Data;

namespace EuroDotNet_BusinessRules
{
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    // > Cette classe effectue les controles divers <
    //   => Le contrôleur reçoit un ID 
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    public class DataControl
    {

        // > On déclare un membre "_context"...
        //   ...qui pointe sur le DataContext <
        private readonly EuroDotNet.Data.DataContext _context;


        // > le string est immuable => on utilise un "StringBuilder" pour optimisation memmoire <
        private StringBuilder ResultCtl = new StringBuilder(1000);

        // > Constante de traitements <
        private const string CtlDataOK = "OK<-->";
        private const string CtlDataNOK = "NOK<=>";

        // > Constructeur <
        public DataControl(EuroDotNet.Data.DataContext context)
        {
            // > On charge le membre de la classe avec le paramètre...
            //   ...reçu par le constructeur <
            _context = context;

        }


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Cette adresse existe-t-elle ? 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string ChkAdresse(string _Id_Key)
        {
            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultCtl.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, positionner à "optimiste" < 
            ResultCtl.Append(CtlDataOK);

            // > On a lancer la recherche dans la base pour vérifier que l'ADRESSE existe bien  < 
            var ObjAdress = _context.Adresse.FirstOrDefault(f => f.Id_Adresse ==
            _Id_Key);

            // > L'enregistrement n'est pas trouvé <
            if (ObjAdress == null)
            {
                // > On intialise le string <
                ResultCtl.Remove(0, 5);
                // > On renvopie un message d'erreur  <
                ResultCtl.Append(CtlDataNOK + " Addresse non trouvée...");
            }


            return ResultCtl.ToString();

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Cette société  existe-t-elle ? 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public string ChkSociete(string _Id_Key)
        {
            // > On intialise le string <
            //   ( obligatoire si l'objet est utilisé plusieurs fois )
            try
            {
                ResultCtl.Remove(0, 6);
            }
            catch
            {

            }

            // > Par défaut, optimiste <
            ResultCtl.Append(CtlDataOK);

            // > On a lancer la recherche dans la base pour vérifier que la société existe bien  existe bien  < 
            var ObjSociete = _context.Societe.FirstOrDefault(f => f.Id_Societe ==
                _Id_Key);

            // > L'enregistrement n'est pas trouvé <
            if (ObjSociete == null)
            {
                // > On intialise le string <
                ResultCtl.Remove(0, 5);
                // > On renvopie un message d'erreur  <
                ResultCtl.Append(CtlDataNOK + " Société non trouvée...");
            }



            return ResultCtl.ToString();

        }

    }
}
