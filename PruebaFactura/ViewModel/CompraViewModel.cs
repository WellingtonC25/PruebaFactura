using PruebaFactura.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaFactura.ViewModel
{
    public class CompraViewModel
    {
        [Display(Name ="Nombre")]
        public string NombreCliente { get; set; }

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        public decimal Total { get; set; }
        public List<ProductoViewModel> Productos { get; set; } = new List<ProductoViewModel>();
    }
}
