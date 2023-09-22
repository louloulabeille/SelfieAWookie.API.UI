using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Application.Repository;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Infrastructure.DataLayers;
using SelfieAWookie.Core.Selfies.Interface.Infrastructure;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace Test.SelfieAWookie.API.UI
{
    public class SelfieControllerUnitTest
    {

        /*[Fact]
        public void ShouldReturnSelfie()
        {
            var moqRepository = new Mock<ISelfieRepository>();

            SelfieController controller = new(moqRepository.Object);

            var result = controller.Index();
            var selfi = result.First();

            Assert.NotNull(selfi);
            Assert.True(selfi is Selfie);
            Assert.NotNull(selfi.Wookie);
            Assert.True(selfi.Wookie is Wookie);
        }*/

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            var builder = new DbContextOptionsBuilder<SelfieDbContext>();
            builder.UseInMemoryDatabase("Selfie-Dev");
            var options = builder.Options;

            using var context = new SelfieDbContext(options);
            // pas utilise d'utiliser le mock, il est possible de faire une base inmemory
            /*var moqDataLayer = new Mock<ISelfieDataLayer>();

            moqDataLayer.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie() { Id = 1,Title="bien joué", Wookie = new Wookie(){Id=1,Surname="Toto" } },
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=1,Surname="Toto" } },
            });

            ISelfieRepository repository = new SelfieRepository(moqDataLayer.Object);*/

            var data = new List<Selfie>()
            {
                new Selfie(){Id = 1,Title="bien joué", Wookie = new Wookie(){Id=1,Surname="Toto" }},
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=3,Surname="Toto" } },

            };

            context.Selfies.AddRange(data);
            context.Wookies.AddRange(data.Select(item=>item.Wookie));
            context.SaveChanges();


            ISelfieDataLayer dataLayer = new SqlServerSelfieDataLayer(context);
            ISelfieRepository repository = new SelfieRepository(dataLayer);
            SelfieController controller = new (repository);

            var result = controller.Index();

            //moqDataLayer.VerifyAll();
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult? ok = result as OkObjectResult;
            Assert.NotNull(ok);
            Assert.NotNull(ok.Value);
            List<SelfieJson>? selfie = ok.Value as List<SelfieJson>;
            Assert.IsType<List<SelfieJson>>(selfie);
            Assert.Equal(3, selfie.Count);
            
        }
    }
}