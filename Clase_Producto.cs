using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Producto
    {
        public int IdProducto { get; private set; }
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }

        public Producto(int id, string nombre, decimal precio, int stock)
        {
            IdProducto = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void MostrarProducto()
        {
            Console.WriteLine($"Producto: {Nombre} - Precio: ${Precio} - Stock: {Stock}");
        }
    }
}
