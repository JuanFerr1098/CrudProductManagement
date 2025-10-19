using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Application;
using Domain.Interfaces.Infraestructure;

namespace Application.Implements
{
    public class ProductoBL : IProductoBL
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepository _repository;

        public ProductoBL(IMapper mapper, IProductoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Método que actualiza la información de un producto
        /// </summary>
        /// <returns>El producto actualizado</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<ProductoDto> ActualizarProducto(ProductoDto producto)
        {
            var productoEntity = _mapper.Map<Producto>(producto);
            var resultDB = await _repository.ActualizarProducto(productoEntity);
            return _mapper.Map<ProductoDto>(resultDB);
        }

        /// <summary>
        /// Método que crea un producto nuevo
        /// </summary>
        /// <returns>El producto nuevo</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<ProductoDto> CrearProducto(ProductoDto producto)
        {
            var productoEntity = _mapper.Map<Producto>(producto);
            var resultDB = await _repository.CrearProducto(productoEntity);
            return _mapper.Map<ProductoDto>(resultDB);
        }

        /// <summary>
        /// Método que elimina lógicamente un producto
        /// </summary>
        /// <returns>El productro eliminado</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<ProductoDto> EliminarProducto(ProductoDto producto)
        {
            var productoEntity = _mapper.Map<Producto>(producto);
            var resultDB = await _repository.ActualizarProducto(productoEntity);
            return _mapper.Map<ProductoDto>(resultDB);
        }

        /// <summary>
        /// Método que obtiene un producto por id
        /// </summary>
        /// <returns>El producto si lo encuentra</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<ProductoDto> ObtenerProductoPorId(int id)
        {
            var resultDB = await _repository.ObtenerProductoPorId(id);
            return _mapper.Map<ProductoDto>(resultDB);
        }

        /// <summary>
        /// Método que obtiene todos los productos filtrados por el nombre
        /// </summary>
        /// <returns>Una lista de objetos filtrados por el nombre</returns>
        /// <author>Juan Tamayo</author>
        /// <date>18/10/2025</date>
        public async Task<IReadOnlyList<ProductoDto>> ObtenerProductoPorNombre(string nombre)
        {
            var resultDB = await _repository.ObtenerProductoPorNombre(nombre.ToUpper());
            if (resultDB != null && resultDB.Count > 0)
            {
                return _mapper.Map<List<ProductoDto>>(resultDB);
            }
            return null;
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
