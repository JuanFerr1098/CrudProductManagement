using Domain.Dtos;

namespace Domain.Interfaces.Application
{
    public interface IClimaBL
    {
        Task<ClimaDto?> ObtenerClimaMedellinAsync(string ciudad);
    }
}
