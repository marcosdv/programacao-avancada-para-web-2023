using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularController : Controller
    {
        [HttpGet("Somar")]
        //[Route("Somar")]
        public double Somar(double valor1, double valor2)
        {
            return valor1 + valor2;
        }

        [HttpPost("Subtrair/{valor1}/{valor2}")]
        //[Route("Subtrair/{valor1}/{valor2}")]
        public double Subtrair(double valor1, double valor2)
        {
            return valor1 - valor2;
        }

        [HttpPut("Multiplicar")]
        public IActionResult Multiplicar(Valores valores)
        {
            double resultado = valores.Valor1 * valores.Valor2;

            return Ok(resultado);
        }

        [HttpPut("Dividir")]
        public IActionResult Dividir(Valores valores)
        {
            try
            {
                if (valores.Valor2 == 0)
                    return BadRequest("O valor 2 não pode ser zero.");

                double resultado = valores.Valor1 / valores.Valor2;

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}