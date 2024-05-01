using ApiExerc.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiExerc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContasController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Conta>> GetContas()
        {
            return Ok();
        }
    }
}
