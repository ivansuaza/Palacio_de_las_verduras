using Microsoft.EntityFrameworkCore;
using PalacioVerduras.API.Models;  

namespace PalacioVerduras.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ProductoVendido> ProductosVendidos { get; set; }  //  Si tienes esta tabla directamente
    }
}