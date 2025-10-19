using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace CrudProductManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimaControlador : ControllerBase
    {
        private readonly IClimaBL _climaBL;

        public ClimaControlador(IClimaBL climaBL)
        {
            _climaBL = climaBL;
        }

        [HttpGet("medellin")]
        public async Task<IActionResult> ObtenerClimaMedellin()
        {
            var resultado = await _climaBL.ObtenerClimaMedellinAsync();

            if (resultado == null)
                return NotFound("No se pudo obtener el clima de Medellín.");

            return Ok(resultado);
        }
    }
}
