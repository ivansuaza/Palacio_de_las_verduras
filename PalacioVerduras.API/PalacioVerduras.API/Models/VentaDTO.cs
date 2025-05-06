using System.Collections.Generic;

namespace PalacioVerduras.API.Models
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public List<ProductoVendidoDTO> ProductosVendidos { get; set; } = new List<ProductoVendidoDTO>();
        public decimal Total { get; set; }
    }
}