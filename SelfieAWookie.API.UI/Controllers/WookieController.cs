using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;
using SelfieAWookie.Core.Selfies.Interface.Repository;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WookieController : ControllerBase
    {
        private readonly IWookieRepository _repository;
        private readonly SelfieDbContext _context;

        public WookieController(IWookieRepository repository, SelfieDbContext context) 
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public ICollection<Wookie> Get()
        {
            return _context.Wookies.ToList();
            //return _repository.GetAll();
        }
    }
}
