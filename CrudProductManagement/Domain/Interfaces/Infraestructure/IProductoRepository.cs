using Domain.Entities;

namespace Domain.Interfaces.Infraestructure
{
    public interface IProductoRepository
    {
        Task<IReadOnlyList<Producto>> ObtenerTodosProductosAsync();
        Task<Producto> ObtenerProductoPorId(int id);
        Task<IReadOnlyList<Producto>> ObtenerProductoPorNombre(string nombre);
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto> ActualizarProducto(Producto producto);
        Task<Producto> EliminarProducto(Producto producto);
    }
}