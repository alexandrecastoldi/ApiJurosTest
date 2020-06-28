using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = new GitHubUrlDto { URL = "https://github.com/alexandrecastoldi/ApiJurosTest" };
            return Ok(result);

        }
    }
}
