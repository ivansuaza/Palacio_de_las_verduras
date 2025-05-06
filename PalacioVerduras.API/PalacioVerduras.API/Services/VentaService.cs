using PalacioVerduras.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PalacioVerduras.API.Services
{
    public class VentaService : IVentaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IClienteService _clienteService;
        private readonly IEmpleadoService _empleadoService;
        private readonly IProductoService _productoService;
        private static List<Venta> _ventas = new List<Venta>();

        public VentaService(ApplicationDbContext context, IClienteService clienteService, IEmpleadoService empleadoService, IProductoService productoService)
        {
            _context = context;
            _clienteService = clienteService;
            _empleadoService = empleadoService;
            _productoService = productoService;
        }

        public async Task<IEnumerable<Venta>> GetAllVentasAsync()
        {
            return await _context.Ventas.ToListAsync();
        }

        public async Task<Venta> GetVentaByIdAsync(int id)
        {
            return await _context.Ventas.FindAsync(id);
        }

        public async Task<Venta> CreateVentaAsync(Venta venta)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(venta.Cliente.IdUsuario);
            var empleado = await _empleadoService.GetEmpleadoByIdAsync(venta.Empleado.IdUsuario);

            if (cliente == null || empleado == null)
            {
                throw new Exception("Cliente o Empleado no encontrado.");
            }

            decimal total = 0;
            foreach (var productoVendido in venta.ProductosVendidos)
            {
                var producto = await _productoService.GetProductoByIdAsync(productoVendido.Producto.IdProducto);
                if (producto == null)
                {
                    throw new Exception($"Producto con ID {productoVendido.Producto.IdProducto} no encontrado.");
                }

                if (producto.Stock < productoVendido.Cantidad)
                {
                    throw new Exception($"No hay suficiente stock para el producto {producto.Nombre}.");
                }

                total += producto.Precio * productoVendido.Cantidad;

                producto.Stock -= productoVendido.Cantidad;
                _context.Productos.Update(producto);
            }

            venta.Total = total;
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return venta;
        }

        public async Task UpdateVentaAsync(Venta venta)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteVentaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}