using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxaJurosApi.Dtos;

namespace TaxaJurosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = new TaxaJurosDto { Juros = 0.01 };

            return Ok(result);
        }
    }
}
