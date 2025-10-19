using Domain.Dtos;

namespace Domain.Interfaces.Application
{
    public interface IProductoBL
    {
        Task<IReadOnlyList<ProductoDto>> ObtenerTodosProductosAsync();
        Task<ProductoDto> ObtenerProductoPorId(int id);
        Task<ProductoDto> CrearProducto(ProductoDto producto);
        Task<ProductoDto> ActualizarProducto(ProductoDto producto);
        Task<ProductoDto> EliminarProducto(ProductoDto producto);
    }
}
