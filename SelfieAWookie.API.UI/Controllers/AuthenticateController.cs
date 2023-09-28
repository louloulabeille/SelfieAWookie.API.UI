using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Outil;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticateController : Controller
    {

        private UserManager<AuthentificationUser> _userManager;
        private readonly IConfiguration _configuration; 

        public AuthenticateController(UserManager<AuthentificationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        #region action public
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserAuthentificationDTO userDTO)
        {
            IActionResult result = this.BadRequest();
            AuthentificationUser? user =  await _userManager.FindByNameAsync(userDTO.Nom);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userDTO.Password) ) return result = this.Ok( new UserAuthentificationDTO()
                {
                    Login = user.Email ?? "default",
                    Nom = user.UserName ?? "default",
                    Token = GenerateTokenJWT.GenerateTokenUserJwt(user, _configuration),
                });

            }

            return result;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create([FromBody]UserAuthentificationDTO userDTO)
        {
            IActionResult result = this.BadRequest(userDTO.Login);

            var user = new AuthentificationUser(userDTO.Login);
            user.Email = userDTO.Login; // le login et aussi le mail sinon il est a null
            user.UserName = userDTO.Nom;
            var identityResult =  await _userManager.CreateAsync(user);
            
            if ( identityResult.Succeeded )
            {
                // modification du mot de passe du compte
                var retour = await _userManager.AddPasswordAsync(user, userDTO.Password);
                if ( retour.Succeeded )
                {
                    userDTO.Token = GenerateTokenJWT.GenerateTokenUserJwt(user, _configuration);
                    userDTO.Password = user.PasswordHash ?? "Default";
                    result = this.Ok(userDTO);
                }else
                {
                    await _userManager.DeleteAsync(user); // on supprime l'uitlisateur si pas bon
                    result = this.BadRequest(retour);
                }
                
            }
            else
            {
                result = this.BadRequest(identityResult.Errors);
            }

            return result;
        }
        #endregion
    }
}
