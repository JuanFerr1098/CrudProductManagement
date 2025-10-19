using Dapper;
using Domain.Entities;
using Domain.Interfaces.Infraestructure;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infraestrutcure.SQLServer
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string? _dataBase;
        public ProductoRepository(IConfiguration configuration) {
            _dataBase = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            var values = new { producto.Id, producto.Nombre, producto.Descripcion, producto.Precio, producto.Estado };
            using var conn = new SqlConnection(_dataBase);
            var result = (await conn.QueryAsync<Producto>("masters.SP_ActualizarProducto", values, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result;
        }

        public async Task<Producto> CrearProducto(Producto producto)
        {
            var values = new { producto.Nombre, producto.Descripcion, producto.Precio, producto.Estado };
            using var conn = new SqlConnection(_dataBase);
            var result = (await conn.QueryAsync<Producto>("masters.SP_CrearProducto", values, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result;
        }

        public async Task<Producto> EliminarProducto(Producto producto)
        {
            var values = new { producto.Id, producto.Estado };
            using var conn = new SqlConnection(_dataBase);
            var result = (await conn.QueryAsync<Producto>("masters.SP_EliminarProducto", values, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result;
        }

        public async Task<Producto> ObtenerProductoPorId(int id)
        {
            var values = new { id };
            using var conn = new SqlConnection(_dataBase);
            var result = (await conn.QueryAsync<Producto>("masters.SP_ObtenerProductoPorId", values, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result;
        }

        public async Task<IReadOnlyList<Producto>> ObtenerProductoPorNombre(string nombre)
        {
            var values = new { nombre };
            using var conn = new SqlConnection(_dataBase);
            var result = await conn.QueryAsync<Producto>("masters.SP_ObtenerProductoPorNombre", values, commandType: CommandType.StoredProcedure);
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result.ToList();
        }

        public async Task<IReadOnlyList<Producto>> ObtenerTodosProductosAsync()
        {
            using var conn = new SqlConnection(_dataBase);
            var result = await conn.QueryAsync<Producto>("EXEC masters.SP_ObtenerProductos");
            await conn.CloseAsync();
            await conn.DisposeAsync();
            return result.ToList();
        }
    }
}
