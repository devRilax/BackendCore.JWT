using BackendCore.Api.Helpers;
using BackendCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackendCore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpPost]
        public ActionResult Auth(LoginModel login)
        {
            //Usuario valido para pruebas de JWT
            var user = new Usuario();
            user.Id = 213;
            user.Name = "Danilo";
            user.LastName = "Caro Aparicio";
            user.Email = "asas@mail.com";
            user.Profile = "MV";

            var token = TokenGeneratorHelper.CreateToken(user, _config);
        
            return Ok(new {  token = token });
        }

       
    }
}
