using InventarioCCL.DataAccess.DataBase;
using InventarioCCL.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioCCL.DataAccess.Repositories
{

    public class ProductoRepository : IProductoRepository
    {
        private readonly CCLContext _context;

        public ProductoRepository(CCLContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> UpdateCantidadAsync(int id, int cantidad)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return false;

            producto.Cantidad = cantidad;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAsync(Producto producto)
        {
            try
            {
                await _context.Productos.AddAsync(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                    return false;

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Si ocurre un error, retorna false
                return false;
            }
        }
    }
}
