using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiService.Configuration;
using ApiService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ApiService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly TaxaJurosSettings _taxaJurosSettings;
        public CalculaJurosController(IOptions<TaxaJurosSettings> taxaJurosSettings)
        {
            _taxaJurosSettings = taxaJurosSettings.Value;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(double valorInicial, int meses)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(_taxaJurosSettings.BaseAddress);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("taxajuros");
                var result = await response.Content.ReadAsStringAsync();
                var responseDto = JsonConvert.DeserializeObject<TaxaJurosDto>(result);

                var valorFinal = valorInicial * Math.Pow((1 + responseDto.Juros), meses);
                valorFinal = Math.Truncate(valorFinal * 100) / 100;

                if (response.IsSuccessStatusCode)
                    return Ok(new ValorCalculadoDto
                    {
                        ValorCalculado = valorFinal
                    });
                else
                    return BadRequest("Erro ao tentar obter a taxa de juros");
            }
            catch
            {
                return BadRequest("Erro ao tentar obter a taxa de juros");
            }
        }
    }
}
