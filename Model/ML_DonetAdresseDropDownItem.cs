using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// ####    ---  Modèle de données rempiir une DropDownList ( ou combo ) ----
// ####        Préfixe "ML_" pour indiquer que c'est un modèle 
// ####=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// #### - - - - - - - - - - - - - - -
// ####   --- Element ( ligne ) d'une dropDownList ---
// #### - - - - - - - - - - - - - - -



namespace EuroDotnet.Model
{
    public class ML_DonetAdresseDropDownItem
    {
        # region properties
        public string Id_Adresse { get; set; }

        public string LibelleAdresse { get; set; }
        #endregion
    }
}
