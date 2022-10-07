using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using EuroDotNet.Data;
using EuroDotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizza_mama.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        // > Création d'un membre qui va recevoir le parametre transmis par le constructeur <
        //     ( rappel : ce paramètre sera transmis via le processus de l'injection de dépendences )
        DataContext DcPizza;

        // =-=-=-=-=-=-=-=-=-=-=-=
        // > Constructeur <
        // =-=-=-=-=-=-=-=-=-=-=-=
        // > on injecte deux objets par injection de dépendance car la page de la classe "PrivacyModel"
        //    est exécuté sans passer par un "new" <
        //   Si on était passer par l'architecture MVC, ( via des contrôleurs )
        //   on aurait pu instancier l'objet dans le contrôleur qui affiche la vue ) <
        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext DcPizza)
        {
            _logger = logger;
            this.DcPizza = DcPizza;
        }

        public void OnGet()
        {
            // > Ce code est utilisé comme tests pour vérifier l'injection de dépendence de la classe "DataContextPizza"
            /* var pizza = new Pizza() { nom = "PizzaTomate, prox = 5" };
            DcPizza.Pizzas.Add(pizza);
            DcPizza.SaveChanges();*/

        }
    }
}
