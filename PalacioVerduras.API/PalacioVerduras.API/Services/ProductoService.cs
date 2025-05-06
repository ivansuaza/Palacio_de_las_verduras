using PalacioVerduras.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PalacioVerduras.API.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;
        private static List<Producto> _productos = new List<Producto>();

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
            if (_productos.Count == 0)
            {
                _productos.Add(new Producto(1, "Zanahoria", 1500, 100));
                _productos.Add(new Producto(2, "Tomate", 2000, 50));
            }
        }

        public async Task<IEnumerable<Producto>> GetAllProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}