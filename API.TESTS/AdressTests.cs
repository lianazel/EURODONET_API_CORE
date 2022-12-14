using EuroDonetApi.Applications.DTOs;
using EuroDonetApi.Interface;
using EuroDotnet.Model;
using EuroDotNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace API.TESTS
{
    public class AdressTests
    {

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ## Mise en place selon 3 actes 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Récupérer la liste des adresses 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void ShouldGet_ListAdress()
        {

            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_GetListAdresses()).Returns(new Dictionary<int, object>()
            {
                [1] = null,
                [2] = new List<ML_DonetAdresse>()
                { new ML_DonetAdresse() { NumVoie = 25, TypVoie = "Rue", CodePostal = 31000 } }
            });

            var controler = new ApiController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.GetListAdresses();

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Récupérer la Drop Down List des adresses  
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void ShouldGet_DropDownList()
        {
            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_GetDDLAdresses()).Returns(new Dictionary<int, object>()
            {
                [1] = null,
                [2] = new List<ML_DonetAdresseDropDownItem>()
                { new ML_DonetAdresseDropDownItem() { Id_Adresse = "12a8541e89741dqaze874", LibelleAdresse="AIRBUS SITE 1" } }
            });

            var controler = new ApiController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.GetDropDownListAdresse();

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }

        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Sauver/Mettre à jour une adresse 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void ShouldPost_Adress()
         {

            // *** Rappel : en mode TEST, lors d'un ADD ou UPDATE, la BDD n'est PAS impactée *** 
            //     ( ==> Pas la peine de rechercher k'enrgistrement dans la base ! )

            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            var ad = new AdresseDto()
            {
                Adresse_1 = "Allées des peupliers",
                Adresse_2 = "",
                NumVoie= 25,
                TypVoie = "RUE",
            };

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_PostAdresse(ad));


            // > On passe au contrôleur notre configuration Mocq <
            var controler = new ApiController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.PostAdress(ad);

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }

    }
}
