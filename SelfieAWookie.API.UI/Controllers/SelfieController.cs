using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private readonly ISelfieRepository _repository;
        private readonly IWebHostEnvironment _environment;

        //public SelfieController(ISelfieRepository repository, SelfieDbContext dbContext)
        public SelfieController(ISelfieRepository repository, IWebHostEnvironment environment )
        {
            _repository = repository;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            /*IEnumerable<Selfie> list = Enumerable.Range(1, 10).Select(index => new Selfie()
            {
                Id = Random.Shared.Next(1, 100),
            }).ToArray();

            //this.StatusCode(StatusCodes.Status400BadRequest);
            //IEnumerable<Selfie> list = _repository.GetAll(); // il va falloir faire un select avec un model dédié*/
            IActionResult result = BadRequest();
            try
            {
                IEnumerable<SelfieJson> list = _repository.GetAll().Select(x =>
                new SelfieJson()
                {
                    Id = x.Id,
                    //PathImage = x.ImagePath,
                    Title = x.Title,
                    WookieJson = x.Wookie is not null ? new WookieJson() { Id = x.Wookie.Id, Surname = x.Wookie.Surname } : null,
                }).ToList();
                result = this.Ok(list);
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
                    //ImagePath = selfie.PathImage,
                    Wookie = selfie.Wookie,
                    Image = null
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
                //result = this.BadRequest(ex);
                result = this.BadRequest();
            }

            return result;
        }

        [HttpGet("GetSelfieByWookieId")]
        public IActionResult ListeSelfieByOneWookie([FromQuery] int? wookieId = 0)
        {
            IActionResult result;
            //var param = this.Request.Query["WookieId"];

            try
            {
                var list = _repository.GetAllByWookie(wookieId);
                result = this.Ok(list);
            }
            catch {
                result = this.BadRequest();
            }

            return result;
        }

    /*    [Route("Photos")]
        [HttpPost()]
        public async Task<IActionResult> AddPictureSync( )
        {
            IActionResult result = this.BadRequest();
            using var bitImg = new MemoryStream();
            using Stream stream = this.Request.Body;

            if (this.Request.Body.CanRead)
            {
                string path = @"\img";
                await this.Request.Body.CopyToAsync(bitImg,this.Request.HttpContext.RequestAborted);
                var image = bitImg.ToArray();
                result = this.Ok(image);

            }
            return result;
        }*/

        [Route("Photos")]
        [HttpPost()]
        public async Task<IActionResult> AddPictureSync(IFormFile file, int selfieId)
        {
            IActionResult result = this.BadRequest();
            //string path = Path.Combine(_environment.ContentRootPath,@"images\selfies");
            string path = Path.Combine(_environment.WebRootPath, @"images\selfies");
            Selfie? selfie = _repository.GetById(selfieId);

            if (selfie is not null || selfieId != 0)
            {
                // enregistrement du fichier au niveau du serveur dans wwwRoot
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }
                path = Path.Combine(path, file.FileName);

                using FileStream fileStream = new(path, FileMode.OpenOrCreate);
                try
                {
                    fileStream.Seek(0, SeekOrigin.Begin);
                    await file.CopyToAsync(fileStream);

                    //var content = await stream.ReadToEndAsync();
                    //Image img = this._repository.AddImage("/images/selfies/" + file.FileName);
                    // création de l'object image
                    Image img = new () {
                        Id = 0,
                        Url = "/images/selfies/" + file.FileName,
                    };

                    // modfication de selfie et enregistrement de l'image dans la base
                    if(selfie is not null)
                    {
                        selfie.Image = img;

                        _repository.Update(selfie);

                        this._repository.SaveChanges();
                        result = this.Ok(img.Url);
                    }
                    
                }
                catch
                {
                    // il faudrait créer un model error à renvoyer
                    result = this.BadRequest();
                }
            }
            
            return result;
        }
    }
}
