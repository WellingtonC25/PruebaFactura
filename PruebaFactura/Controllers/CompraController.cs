using Microsoft.AspNetCore.Mvc;
using PruebaFactura.Data;
using PruebaFactura.Models;
using PruebaFactura.ViewModel;
using System;
using System.Linq;

namespace PruebaFactura.Controllers
{
    public class CompraController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CompraController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public IActionResult Comprar()
        {
            var productos = _db.Productos.Select(c=>new ProductoViewModel { 
            Nombre = c.Nombre,
            Precio = c.Precio
            }).ToList();

            var model = new CompraViewModel
            {
                Productos = productos
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Comprar(CompraViewModel model)
        {
            var encabezadoFactura = new EncabezadoFactura
            {
                DireccionCliente = model.Direccion,
                NombreCliente = model.NombreCliente,
                TotalCompra = model.Productos.Where(c => c.Comprar).Sum(c => c.Precio)
            };

            var detalleFacturas = model.Productos
                .Where(c => c.Comprar)
                .Select(c=>new DetalleFactura
            {
                NombreProducto = c.Nombre,
                CodigoFactura = encabezadoFactura.CodigoFactura,
                PrecioProducto = c.Precio
            }
            );

            _db.EncabezadoFacturas.Add(encabezadoFactura);
            _db.DetalleFacturas.AddRange(detalleFacturas);

            _db.SaveChanges();
                
            return RedirectToAction("Comprar");
        }

        public IActionResult VisualizarFactura(Guid codigoFactura)
        {
            var encabezado = _db.EncabezadoFacturas.SingleOrDefault(c => c.CodigoFactura == codigoFactura);
            var detalleFactura = _db.DetalleFacturas.Where(c => c.CodigoFactura == codigoFactura).ToList();
            var factura = new VisualizarFacturaViewModel
            {
                Encabezado = encabezado,
                Detalle = detalleFactura
            };
            return View(factura);
        }

    }
}