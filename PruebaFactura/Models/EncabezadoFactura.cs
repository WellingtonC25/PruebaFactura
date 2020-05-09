using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaFactura.Models
{
    public class EncabezadoFactura
    {

        [Key]
        public Guid CodigoFactura { get; set; } = Guid.NewGuid();
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
