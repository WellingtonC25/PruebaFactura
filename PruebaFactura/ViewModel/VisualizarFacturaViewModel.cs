using PruebaFactura.Models;
using System.Collections.Generic;

namespace PruebaFactura.ViewModel
{
    public class VisualizarFacturaViewModel
    {
        public EncabezadoFactura Encabezado { get; set; }
        public List<DetalleFactura> Detalle { get; set; } = new List<DetalleFactura>();
    }
}
