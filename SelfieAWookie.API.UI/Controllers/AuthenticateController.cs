using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SelfieAWookie.API.UI.ExtensionMethod;
using SelfieAWookie.API.UI.Outil;
using SelfieAWookie.Core.Selfies.Application.Configuration;
using SelfieAWookie.Core.Selfies.Application.DTO;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors(SecurityCROSMethod.PolicyAll)]
    [ApiController]
    public class AuthenticateController : Controller
    {

        private readonly UserManager<AuthentificationUser> _userManager;
        //private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticateController> _logger;
        private readonly ElementConfigurationSecret _secret;

        public AuthenticateController(UserManager<AuthentificationUser> userManager, ILogger<AuthenticateController> logger, IOptions<ElementConfigurationSecret> options)
        {
            _userManager = userManager;
            //_configuration = configuration;
            _logger = logger;
            _secret = options.Value;
        }

        #region action public
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserAuthentificationDTO userDTO)
        {
            IActionResult result = this.BadRequest();
            AuthentificationUser? user =  await _userManager.FindByNameAsync(userDTO.Nom);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userDTO.Password) ) result = this.Ok( new UserAuthentificationDTO()
                {
                    Login = user.Email ?? "default",
                    Nom = user.UserName ?? "default",
                    Token = GenerateTokenJWT.GenerateTokenUserJwt(user, _secret),
                });

            }

            return result;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Create([FromBody]UserAuthentificationDTO userDTO)
        {
            IActionResult result;

            var user = new AuthentificationUser(userDTO.Login);
            user.Email = userDTO.Login; // le login et aussi le mail sinon il est a null
            user.UserName = userDTO.Nom;
            var identityResult =  await _userManager.CreateAsync(user);
            try
            {
                if (identityResult.Succeeded)
                {
                    // modification du mot de passe du compte
                    var retour = await _userManager.AddPasswordAsync(user, userDTO.Password);
                    if (retour.Succeeded)
                    {
                        userDTO.Token = GenerateTokenJWT.GenerateTokenUserJwt(user, _secret);
                        userDTO.Password = user.PasswordHash ?? "Default";
                        result = this.Ok(userDTO);
                    }
                    else
                    {
                        await _userManager.DeleteAsync(user); // on supprime l'uitlisateur si pas bon
                        result = this.BadRequest(retour); // retourne le message d'erreur lors de la création du compte
                    }

                }
                else
                {
                    result = this.BadRequest(identityResult.Errors);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("AuthenticateController\\Create \n" + ex.Message + "\n" + userDTO);
                result = this.Problem("Probleme interne au niveau de la création du compte.");
            }

            return result;
        }
        #endregion
    }
}
