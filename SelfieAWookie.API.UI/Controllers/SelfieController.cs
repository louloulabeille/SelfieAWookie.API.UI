using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private readonly ISelfieRepository _repository;

        //public SelfieController(ISelfieRepository repository, SelfieDbContext dbContext)
        public SelfieController(ISelfieRepository repository)
        {
            _repository = repository;
        }

        /*[HttpGet]
        public IEnumerable<Selfie> Index()
        {
            *//*return Enumerable.Range(1, 10).Select(index => new Selfie()
            {
                Id = Random.Shared.Next(1, 100),
                Title = "Title"+Random.Shared.Next(1, 100).ToString(),
                Wookie = new Wookie() { Surname ="toto",Id=1},
            }).ToArray();*//*
            return _repository.GetAll().ToList();
        }*/

        [HttpGet]
        public IActionResult Index()
        {
            /*IEnumerable<Selfie> list = Enumerable.Range(1, 10).Select(index => new Selfie()
            {
                Id = Random.Shared.Next(1, 100),
            }).ToArray();*/

            //this.StatusCode(StatusCodes.Status400BadRequest);
            //IEnumerable<Selfie> list = _repository.GetAll(); // il va falloir faire un select avec un model dédié
            IEnumerable<SelfieJson> list;
            try
            {
                list = _repository.GetAll().Select(x =>
                new SelfieJson()
                {
                    Id = x.Id,
                    PathImage = x.ImagePath,
                    Title = x.Title,
                    WookieJson = x.Wookie is not null? new WookieJson() { Id = x.Wookie.Id , Surname = x.Wookie.Surname }:null,
                }).ToList();
                return this.Ok(list);
            }
            catch
            {
                return this.BadRequest();
            }
        }

    }
}
