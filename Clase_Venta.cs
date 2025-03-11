using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
{
    public class Venta
    {
        public int IdVenta { get; private set; }
        public Cliente Cliente { get; private set; }
        public Empleado Empleado { get; private set; }
        public List<Producto> Productos { get; private set; }
        public decimal Total { get; private set; }

        public Venta(int id, Cliente cliente, Empleado empleado, List<Producto> productos, decimal total)
        {
            IdVenta = id;
            Cliente = cliente;
            Empleado = empleado;
            Productos = productos;
            Total = total; // Usamos el total que se pasa como argumento
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
            Console.WriteLine($"Venta ID: {IdVenta} - Cliente: {Cliente.Nombre} - Empleado: {Empleado.Nombre} - Total: ${Total}");
        }
    }
}
