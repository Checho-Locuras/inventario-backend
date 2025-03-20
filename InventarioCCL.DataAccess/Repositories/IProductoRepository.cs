using InventarioCCL.Domain.Models;

namespace InventarioCCL.DataAccess.Repositories
{
    public interface IProductoRepository
    {
        Task<bool> AddAsync(Producto producto);
        Task<bool> DeleteAsync(int id);
        Task<List<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task<bool> UpdateCantidadAsync(int id, int cantidad);
    }
}