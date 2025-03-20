using InventarioCCL.DataAccess.Repositories;
using InventarioCCL.Domain.Common;
using InventarioCCL.Domain.Dtos;
using InventarioCCL.Domain.Models;

namespace InventarioCCL.Core.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Producto>> GetInventarioAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> RegistrarMovimientoAsync(MovimientoDto movimiento)
        {
            var producto = await _repository.GetByIdAsync(movimiento.ProductoId);
            if (producto == null)
                return false;

            // Calcular nueva cantidad
            int nuevaCantidad;
            if (movimiento.Tipo == 1)
            {
                nuevaCantidad = producto.Cantidad + movimiento.Cantidad;
            }
            else // Salida
            {
                nuevaCantidad = producto.Cantidad - movimiento.Cantidad;
                if (nuevaCantidad < 0)
                    return false;
            }

            return await _repository.UpdateCantidadAsync(movimiento.ProductoId, nuevaCantidad);
        }
        public async Task<bool> AgregarProducto(Producto producto)
        {
            return await _repository.AddAsync(producto);
        }

        public async Task<bool> EliminarProducto(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
