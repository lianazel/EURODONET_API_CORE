using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
// > Necessaire pour le claim <
using Microsoft.AspNetCore.Authentication;
// > Necessaire pour le claim <
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// N�cessaire pour le param�tre du constructeur ("Iconfiguration")
using Microsoft.Extensions.Configuration;

// > Pour "env.IsDevelopent" <
using Microsoft.Extensions.Hosting;

// > Pour la d�finition de la table <
using EuroDotnet.Model;

namespace pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {

        // > Bool�ean de test connextion <
        public bool BlnLogOk = true;

        // > Bool�ean mode d�veloppement  <
        public bool BlnModDev = false;

        
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Ajout d'un constructeur <
        //   ( On a optimis� le code en mettant le....
        //     ...login et mot de passe dans le fichier "appsettings" (json) )
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IndexModel(IConfiguration configuration, IWebHostEnvironment env)
        {

            // > Maintenant, on a acc�s � l'objet "Configuration" qui est d�clar�...
            //   ...dans la claees "Startup.cs" <
            this.Configuration = configuration;

            // > Si on est en mode d�veloppement, le bool�en "BlnModDev"...
            //   ...est positionn� � vrai <
            if (env.IsDevelopment())
            {
                BlnModDev = true;
            }


        }

        // > D�claration d'une variable "configuration" qui va recevoir le...
        //   ...param�tre du constructeur "constructeur" <
        // > Remarque : le "{get;}" permet de d�clarer la variable APRES le constructeur...
        //   ... Normalement, il faut la d�clarer AVANT le constructeur <

        IConfiguration Configuration { get; }



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Rappel = "OnGetXxx" => Le code est ex�cut� au moment du chargement de la page <
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult OnGet()
        {
            // > Si la variable "IsAthenticated" est � vrai, on renvoie....
            //   ...la page d'administration des pizzas <
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pi" +
                    "zzas");
            }

            // > Sinon, on rfenvoie la page d'authentification <
            return Page();
        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Rappel = "OnPostXxxx" => c'est pour intercepter une touche de validation <
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
        {
            // > Par d�faut, on consid�re que la connexion est  OK <
            BlnLogOk = true;

            // > On r�cup�re dans la variable "Vconfig" le contenu de la section "Auth"...
            //   ... d�fini dans le fichier "appsettings". <
            var AuthSection = Configuration.GetSection("Auth");
            // > On utilise ensuite "AuthSection" comme un dictionnaire <
            string AdminLogin = AuthSection["AdminLogin"];
            string AdminPassWord = AuthSection["AdminPassWord"];
            if ((username == AdminLogin) && (password == AdminPassWord))
            {
                // > Installation du claim pour le fonctionnement de l'authentification <
                var claims = new List<Claim>
                 {
                            // > cette est accept�e dans la connexion <
                   new Claim(ClaimTypes.Name, username)
                 };
                var claimsidentity = new ClaimsIdentity(claims, "Login");

                // > comme c'est une fonction asynchrone, il faut mettre "async" � la place "void" <
                // > une fonction asynchrone, �a retourne un "task" <
                // > comme on veut faire une re-direction , ou bien retourner la page courante...
                // > si on ne fait pas "task<iactionresult>", on retournera toujours...
                //   ...la page courante. or on veut pouvoir retourner la page...
                //   ...re�ue en param�tre. 

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                ClaimsPrincipal(claimsidentity));
                // > si la page re�u en param�rtre est null,...
                //   ...alors on est redirig� vers "/admin/pizzas", sinon on affiche la page re�ue...
                //   ... en param�tre <

                //return Redirect(ReturnUrl == null ? "/Admin/Pizzas" + "" : ReturnUrl);
                return Redirect("/Admin/Pizzas");
            }
            // > Return de la page courante <
            else
            {
                // > la connexion est n'est pas OK ! <
                BlnLogOk = false;

                //   ( L'identification a echou� ).
                return Page();
            }
        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // > Code du bouton "Se D�connecter" sur le Layout <
        //   ( On a mis ce code dans la classe "IndexModel"...
        //     ...de la page d'authentification )
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public async Task<IActionResult> OnGetLogOut()
        {
            // > C'est une m�thode asynchrone <
            await HttpContext.SignOutAsync();
            // > L'option "Se D�connecter" est dans la "NaviGation Bar" : donc elle...
            //   ...est accessible de partout : il faut donc renvoyer la...
            //   ...page d'authentification.

            // > Comme on renvoie une page, il faut mettre "<IactionResult>"
            return Redirect("/Admin");

        }
    }
}
