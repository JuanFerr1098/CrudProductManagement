using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Config
{
    public class MappingProfile : Profile
    {
      public MappingProfile() { 
        CreateMap<Producto, ProductoDto>();
        CreateMap<ProductoDto, Producto>();

        CreateMap<Clima, ClimaDto>()
            .ForMember(dest => dest.Temperatura, opt => opt.MapFrom(src => $"{src.Temperatura} °C"))
            .ForMember(dest => dest.Humedad, opt => opt.MapFrom(src => $"{src.Humedad}%"))
            .ForMember(dest => dest.Viento, opt => opt.MapFrom(src => $"{src.VelocidadViento} m/s"))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.FechaConsulta.ToString("dd/MM/yyyy HH:mm")));
        }
    }
}
