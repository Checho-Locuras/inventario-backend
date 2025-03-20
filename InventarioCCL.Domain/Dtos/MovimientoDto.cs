using InventarioCCL.Domain.Common;

namespace InventarioCCL.Domain.Dtos
{
    public class MovimientoDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Tipo { get; set; }
    }
}
