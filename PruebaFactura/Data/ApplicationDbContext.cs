using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaFactura.Models;

namespace PruebaFactura.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {        }

        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<EncabezadoFactura> EncabezadoFacturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
