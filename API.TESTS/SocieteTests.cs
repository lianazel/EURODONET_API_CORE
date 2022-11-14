using EuroDonetApi.Applications.DTOs;
using EuroDonetApi.Interface;
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
        // ### Sauver/Mettre à jour une adresse 
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


    }
}
