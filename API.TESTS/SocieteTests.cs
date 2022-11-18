using EuroDonetApi.Applications.DTOs;
using EuroDonetApi.Interface;
using EuroDotnet.Model;
using EuroDotNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace API.TESTS
{
    public class SocieteTests
    {

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Sauver/Mettre à jour une societe 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void ShouldPost_Societe()
        {
            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            var St = new SocieteDto()
            {
                RaisonSociale = "Airbus SAS",
               NumSiren        = 785412,
                CapitalSocial  = 7845152,
                ChiffreAffaire = 1236474,
                NumTVAIntra    = "TVA_EUR7852",
                FK_ID_Adresse  = "ead1258741263zza",
            };

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_PostSociete(St));

            // > On passe au contrôleur notre configuration Mocq <
            var controler = new ApiController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.PostSociete(St);

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }



        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Récupérer la liste des societes 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void ShouldGet_ListSociete()
        {

            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_GetListSocietes()).Returns(new Dictionary<int, object>()
            {
                [1] = null,
                [2] = new List<ML_DonetSociete>()
                { 
                    
                new ML_DonetSociete() { Id_Societe = "6fe8329d-8f75-47b9-8d7a-097c0e27838b", CapitalSocial = 78541,
                    ChiffreAffaire = 987452, FK_ID_Adresse = "64525247-515b-4b25-8f6d-4c90469bbd82" },

                new ML_DonetSociete() { Id_Societe = "6fe8329d-8f75-47b9-8d7a-09778952", CapitalSocial = 987452,
                    ChiffreAffaire = 45213, FK_ID_Adresse = "64525247-515b-4b25-8f6d-4c90469bbd82" }

                }

            }
           
            
            );

            var controler = new ApiController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.GetListSocietes();

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }

    }
}
