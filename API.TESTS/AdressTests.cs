using EuroDonetApi.Controllers;
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

        [Fact]
        public void ListAdress()
        {

            var RepositoryMoq = new Mock<IEuroDonetRepository>();

            // #### Arrange ( Préparation ) ######
            RepositoryMoq.Setup(item => item.Repo_GetListAdresses()).Returns(new Dictionary<int, object>()
            {
                [1] = null,
                [2] = new List<ML_DonetAdresse>()
                { new ML_DonetAdresse() { NumVoie = 25, TypVoie = "Rue", CodePostal = 31000 } }
            });

            var controler = new ApTestController(RepositoryMoq.Object);

            // #### Act ( Traitement ) ######
            var Result = controler.GetListAdresses();

            // #### Assertion  ( Prouver que c'est OK  ) ######
            Assert.NotNull(Result);

            Assert.IsType<OkObjectResult>(Result);
            OkObjectResult OkRes = (OkObjectResult)Result;

        }
    }
}
