using InventarioCCL.Core.Services;
using InventarioCCL.Domain.Dtos;
using InventarioCCL.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventarioCCL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("inventario")]
        public async Task<IActionResult> GetInventario()
        {
            var productos = await _productoService.GetInventarioAsync();
            return Ok(productos);
        }

        [HttpPost("movimiento")]
        public async Task<IActionResult> RegistrarMovimiento([FromBody] MovimientoDto movimiento)
        {
            if (movimiento.Cantidad <= 0)
                return BadRequest("La cantidad debe ser mayor a cero");

            var resultado = await _productoService.RegistrarMovimientoAsync(movimiento);
            if (!resultado)
                return BadRequest("No se pudo registrar el movimiento");

            return Ok(resultado);
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarProducto([FromBody] Producto producto)
        {
            var resultado = await _productoService.AgregarProducto(producto);
            if (!resultado)
                return BadRequest("No se pudo agregar el producto");

            return Ok(resultado);
        }

        [HttpPost("eliminar")]
        public async Task<IActionResult> EliminarProducto([FromBody] EliminarProductoDto input)
        {
            var id = (input.Id);
            var resultado = await _productoService.EliminarProducto(id);
            if (!resultado)
                return BadRequest("No se pudo eliminar el producto");

            return Ok(resultado);
        }
    }
}
