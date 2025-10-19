using Domain.Entities;
using Domain.Interfaces.Infraestructure;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace Infraestrutcure.SQLServer
{
    public class ClimaRepository :IClimaRepository
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "3271a5b91a6c3cd677d173d47287a078"; 

        public ClimaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Clima?> ObtenerClimaAsync(string ciudad)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad},CO&appid={ApiKey}&units=metric&lang=es";

            var respuesta = await _httpClient.GetAsync(url);

            if (!respuesta.IsSuccessStatusCode)
                return null;

            var datos = await respuesta.Content.ReadFromJsonAsync<ClimaResponse>();

            return new Clima
            {
                Ciudad = datos.Name,
                Descripcion = datos.Weather[0].Description,
                Temperatura = datos.Main.Temp,
                SensacionTermica = datos.Main.Feels_Like,
                Humedad = datos.Main.Humidity,
                VelocidadViento = datos.Wind.Speed,
                FechaConsulta = DateTime.UtcNow
            };
        }
    }
}
