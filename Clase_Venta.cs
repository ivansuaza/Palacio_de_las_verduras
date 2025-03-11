using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Venta
    {
        public int IdVenta { get; private set; }
        public Cliente Cliente { get; private set; }
        public Empleado Empleado { get; private set; }
        public List<Producto> Productos { get; private set; }
        public decimal Total { get; private set; }

        public Venta(int id, Cliente cliente, Empleado empleado, List<Producto> productos)
        {
            IdVenta = id;
            Cliente = cliente;
            Empleado = empleado;
            Productos = productos;
            Total = CalcularTotal();
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var producto in Productos)
            {
                total += producto.Precio;
            }
            return total;
        }

        public void MostrarVenta()
        {
            Console.WriteLine($"Venta ID: {IdVenta} - Cliente: {Cliente.Nombre} - Total: ${Total}");
        }
    }
}
