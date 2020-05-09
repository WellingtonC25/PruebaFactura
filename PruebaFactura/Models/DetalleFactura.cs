using System;

namespace PruebaFactura.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public Guid CodigoFactura { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
    }
}
