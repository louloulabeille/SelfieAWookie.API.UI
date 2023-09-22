using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Models;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {

        [HttpGet("404")]
        public Error Error404()
        {
            return Error.Error404;
        }
    }
}
