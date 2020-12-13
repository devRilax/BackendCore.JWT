using BackendCore.Business;
using BackendCore.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BackendCore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ComunaController : ControllerBase
    {
     
        private readonly ComunaBL blComuna;

        public ComunaController(IConfiguration config)
        {
            blComuna = new ComunaBL(config);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Comuna entity)
        {
            var result = await blComuna.Create(entity);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> All()
        {
            var ok = await blComuna.All();

            return Ok(ok);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> ById(long id)
        {
            var ok = await blComuna.ById(id);

            return Ok(ok);
        }
    }
}
