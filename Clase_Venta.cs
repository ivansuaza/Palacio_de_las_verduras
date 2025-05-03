using System;
using System.Collections.Generic;

namespace Palacio_de_las_verduras
{
    public class Venta
    {
        public int IdVenta { get; private set; }
        public Cliente Cliente { get; private set; }
        public Empleado Empleado { get; private set; }
        public List<ProductoVendido> ProductosVendidos { get; private set; }
        public decimal Total { get; private set; }

        public Venta(int id, Cliente cliente, Empleado empleado, List<ProductoVendido> productosVendidos)
        {
            IdVenta = id;
            Cliente = cliente;
            Empleado = empleado;
            ProductosVendidos = productosVendidos;
            Total = CalcularTotal(); 
        }


        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var pv in ProductosVendidos)
            {
                total += pv.Producto.Precio * pv.Cantidad;
            }
            return total;
        }

        public void MostrarVenta()
        {
            Console.WriteLine($"Venta ID: {IdVenta} - Cliente: {Cliente.Nombre} - Empleado: {Empleado.Nombre} - Total: ${Total}");

            Console.WriteLine("Productos vendidos:");
            foreach (var pv in ProductosVendidos)
            {
                Console.WriteLine($"- {pv.Producto.Nombre} | Cantidad: {pv.Cantidad}");
            }
        }
    }
}
