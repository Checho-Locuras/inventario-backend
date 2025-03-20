using InventarioCCL.Domain.Dtos;
using InventarioCCL.Domain.Models;

namespace InventarioCCL.Core.Services
{
    public interface IProductoService
    {
        Task<bool> AgregarProducto(Producto producto);
        Task<bool> EliminarProducto(int id);
        Task<List<Producto>> GetInventarioAsync();
        Task<bool> RegistrarMovimientoAsync(MovimientoDto movimiento);
    }
}