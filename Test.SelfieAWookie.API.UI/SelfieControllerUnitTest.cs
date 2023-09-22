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
        private readonly SelfieDbContext _context;

        public SelfieControllerUnitTest()
        {
            var builder = new DbContextOptionsBuilder<SelfieDbContext>();
            builder.UseInMemoryDatabase("Selfie-Dev");
            var options = builder.Options;

            _context = new SelfieDbContext(options);

            var data = new List<Selfie>()
            {
                new Selfie(){Id = 1,Title="bien jou�", Wookie = new Wookie(){Id=1,Surname="Toto" }},
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=3,Surname="Tata" } },

            };

            _context.Selfies.AddRange(data);
            _context.Wookies.AddRange(data.Select(item => item.Wookie));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

        }

        [Fact]
        public void ShouldAddOneSelfie()
        {
            // Arrange

            // Act
            ISelfieDataLayer dataLayer = new SqlServerSelfieDataLayer(_context);
            ISelfieRepository repository = new SelfieRepository(dataLayer);
            SelfieController controller = new(repository);
            SelfieDTOAddOne selfieAdd = new() {
                Id= 0,
                Title = "j'aime les frittes",
                PathImage = null,
                Wookie = new Wookie() { Id = 1, Surname = "Toto" },
            };

            var result = controller.AddOneSelfie(selfieAdd);
            // Assert

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var value = (result as OkObjectResult)?.Value as SelfieDTOAddOne;
            Assert.NotNull(value);
            Assert.IsType<SelfieDTOAddOne>(value);
            Assert.Equal(selfieAdd.Title, value.Title);
            Assert.Equal(selfieAdd, value);

            _context.Selfies.ToList();
        }

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            /*var builder = new DbContextOptionsBuilder<SelfieDbContext>();
            builder.UseInMemoryDatabase("Selfie-Dev");
            var options = builder.Options;

            using var context = new SelfieDbContext(options);
            // pas utilise d'utiliser le mock, il est possible de faire une base inmemory
            var moqDataLayer = new Mock<ISelfieDataLayer>();

            moqDataLayer.Setup(item => item.GetAll()).Returns(new List<Selfie>()
            {
                new Selfie() { Id = 1,Title="bien jou�", Wookie = new Wookie(){Id=1,Surname="Toto" } },
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=1,Surname="Toto" } },
            });

            ISelfieRepository repository = new SelfieRepository(moqDataLayer.Object);

            var data = new List<Selfie>()
            {
                new Selfie(){Id = 1,Title="bien jou�", Wookie = new Wookie(){Id=1,Surname="Toto" }},
                new Selfie() { Id = 2,Title="3ieme", Wookie = new Wookie(){Id=2,Surname="Titi" } },
                new Selfie() { Id = 3,Title="Encore toi", Wookie = new Wookie(){Id=3,Surname="Toto" } },

            };

            context.Selfies.AddRange(data);
            context.Wookies.AddRange(data.Select(item => item.Wookie));
            context.SaveChanges();*/


            ISelfieDataLayer dataLayer = new SqlServerSelfieDataLayer(_context);
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