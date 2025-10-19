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
        public async Task<IActionResult> GetAll() {
            var result = await _productoBL.ObtenerTodosProductosAsync();
            if (result != null)
                return await GetResponseAsync(HttpStatusCode.OK, "Ejecución correcta", result);
            return await GetResponseAsync<ProductoDto>(HttpStatusCode.BadRequest, "Error en la consulta", null);
        }
    }
}
