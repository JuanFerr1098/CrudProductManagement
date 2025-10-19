using Domain.Entities;

namespace Domain.Interfaces.Infraestructure
{
    public interface IClimaRepository
    {
        Task<Clima?> ObtenerClimaAsync(string ciudad);
    }
}
