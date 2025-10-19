using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Implements
{
    public class ClimaBL : IClimaBL
    {
        private readonly IClimaRepository _repository;
        private readonly IMapper _mapper;

        public ClimaBL(IClimaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClimaDto?> ObtenerClimaMedellinAsync(string ciudad)
        {
            var entidad = await _repository.ObtenerClimaAsync(ciudad);
            if (entidad == null) return null;

            return _mapper.Map<ClimaDto>(entidad);
        }
    }
}
