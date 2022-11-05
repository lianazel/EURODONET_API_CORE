using EuroDonetApi.Interface;
using EuroDotnet.Model;
using EuroDotNet.Controllers;
using Microsoft.AspNetCore.Mvc;

// > Moq <
using Moq;
using System;
using System.Collections.Generic;

// > Xunit <
using Xunit;

namespace API.TESTS
{
    public class AdressTests
    {

        //- - - - - - - - - - - - - - - - - - - - - - - -
        // ## Mise en place selon 3 actes 
        //- - - - - - - - - - - - - - - - - - - - - - - -
        // 1/ Arrange    ( Préparation )
        // 2/ Act        ( Traitement ) 
        // 3/ Assertion  ( Prouver que c'est OK  )


        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        // ### Récupérer la liste des adresses 
        // =-=-=-=-=-=-=-=-=-=-=-=-=-=
        [Fact]
        public void Get_ListAdress()
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
        public void Get_DropDownList()
        {
            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_GetDDLAdresses()).Returns(new Dictionary<int, object>()
            {
                [1] = null,
                [2] = new List<ML_DonetAdresseDropDownItem>()
                { new ML_DonetAdresseDropDownItem() { Id_Adresse = "12a8541e89741dqaze874",
                    LibelleAdresse="AIRBUS SITE 1" } }
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
        public void Post_Adress()
        {
            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            var ad = new ML_DonetAdresse()
            {
                Adresse_1 = "Allées des peupliers",
                Adresse_2 = "",
                NumVoie= 25,
                TypVoie = "RUE",
            };

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_PostAdresse(ad));
            

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
