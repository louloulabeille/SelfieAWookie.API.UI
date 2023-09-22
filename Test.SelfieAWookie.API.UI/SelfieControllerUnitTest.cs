using Microsoft.AspNetCore.Mvc;
using Moq;
using SelfieAWookie.API.UI.Controllers;
using SelfieAWookie.Core.Selfies.Application.Repository;
using SelfieAWookie.Core.Selfies.Domain;
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
            var moqDataLayer = new Mock<ISelfieDataLayer>();

            moqDataLayer.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie() { Id = 1,Title="bien joué", Wookie = new Wookie(){Id=1,Surname="Toto" } },
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=1,Surname="Toto" } },
            });

            ISelfieRepository repository = new SelfieRepository(moqDataLayer.Object);
            SelfieController controller = new (repository);

            var result = controller.Index();

            moqDataLayer.VerifyAll();
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult? ok = result as OkObjectResult;
            Assert.NotNull(ok);
        }
    }
}