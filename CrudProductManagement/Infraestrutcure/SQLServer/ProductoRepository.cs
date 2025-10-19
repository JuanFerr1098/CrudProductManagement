using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestrutcure.SQLServer
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string? _dataBase;
        public ProductoRepository(IConfiguration configuration) {
            _dataBase = configuration.GetConnectionString("Server = localhost, 1433; Database = CrudProduct; User Id = sa; Password = Juanferr1098!; TrustServerCertificate = True; ");
        }

        public Task<Producto> ActualizarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CrearProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> EliminarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> ObtenerProductoPorId(int id)
        {
            throw new NotImplementedException();
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
