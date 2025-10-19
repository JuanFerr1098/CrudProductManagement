using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Implements
{
    public class ProductoBL :IProductoBL
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepository _repository;

        public ProductoBL(IMapper mapper, IProductoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<ProductoDto> ActualizarProducto(ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> CrearProducto(ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> EliminarProducto(ProductoDto producto)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> ObtenerProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que obtiene todos los productos
        /// </summary>
        /// <returns>Una lista con todos los productos</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<IReadOnlyList<ProductoDto>> ObtenerTodosProductosAsync()
        {
            var resultDB = await _repository.ObtenerTodosProductosAsync();
            if (resultDB != null && resultDB.Count > 0) { 
                return _mapper.Map<List<ProductoDto>>(resultDB);
            }
            return null;
        }
    }
}
