using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Repository;
using SelfieAWookie.Core.Selfies.Interface.UnitOfWork;

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

        [HttpGet]
        public IActionResult Index()
        {
            /*IEnumerable<Selfie> list = Enumerable.Range(1, 10).Select(index => new Selfie()
            {
                Id = Random.Shared.Next(1, 100),
            }).ToArray();*/

            //this.StatusCode(StatusCodes.Status400BadRequest);
            //IEnumerable<Selfie> list = _repository.GetAll(); // il va falloir faire un select avec un model dédié
            IActionResult result = BadRequest();
            try
            {
                IEnumerable<SelfieJson> list = _repository.GetAll().Select(x =>
                new SelfieJson()
                {
                    Id = x.Id,
                    PathImage = x.ImagePath,
                    Title = x.Title,
                    WookieJson = x.Wookie is not null? new WookieJson() { Id = x.Wookie.Id , Surname = x.Wookie.Surname }:null,
                }).ToList();
                result =  this.Ok(list);
            }
            catch
            {
                result = this.BadRequest();
            }
            return result;
        }

        [HttpPost]
        public IActionResult AddOneSelfie(SelfieDTOAddOne selfie)
        {
            IActionResult result = this.BadRequest();
            try
            {
                #region Ajout et enregistrement
                Selfie addSelfie = _repository.Add(new Selfie
                {
                    Id = selfie.Id,
                    Title = selfie.Title,
                    ImagePath = selfie.PathImage,
                    Wookie = selfie.Wookie
                });

                _repository.SaveChanges();
                #endregion

                if (addSelfie is not null)
                {
                    selfie.Id = addSelfie.Id;
                    result = this.Ok(selfie);
                }
            }
            catch
            {
                result = this.BadRequest();
            }

            return result;
        }


    }
}
