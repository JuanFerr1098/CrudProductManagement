using Domain.Dtos;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudProductManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBL _productoBL;

        public ProductoController(IProductoBL productoBL)
        {
            _productoBL = productoBL;
        }

        /// <summary>
        /// Get Response Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<ObjectResult> GetResponseAsync<T>(HttpStatusCode statusCode, string message, T response)
        {
            return await Task.Run(() =>
            {
                var objectResult = new HttpResponse<T>((int)statusCode, message, response);
                return new ObjectResult(objectResult)
                {
                    StatusCode = (int)statusCode
                };
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("nombre/{NombreProducto}")]
        public async Task<IActionResult> GetByName([FromRoute] string NombreProducto)
        { 
            var result = await _productoBL.ObtenerProductoPorNombre(NombreProducto);
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("id/{IdProducto}")]
        public async Task<IActionResult> GetById([FromRoute] int IdProducto)
        {
            var result = await _productoBL.ObtenerProductoPorId(IdProducto);
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("borrar")]
        public async Task<IActionResult> Delete([FromBody] ProductoDto producto)
        {
            var result = await _productoBL.EliminarProducto(producto);
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> Insert([FromBody] ProductoDto producto)
        {
            var result = await _productoBL.CrearProducto(producto);
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> Update([FromBody] ProductoDto producto)
        {
            var result = await _productoBL.ActualizarProducto(producto);
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _productoBL.ObtenerTodosProductosAsync();
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }
    }
}
