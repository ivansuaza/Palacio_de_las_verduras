using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
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

        public int ObtenerStock()
        {
            return Stock;
        }

        public void ReducirStock(int cantidad)
        {
            if (Stock >= cantidad)
            {
                Stock -= cantidad;
            }
            else
            {
                Console.WriteLine("Stock insuficiente.");
            }
        }

        public void MostrarProducto()
        {
            Console.WriteLine($" ID Producto: {IdProducto} - Producto: {Nombre} - Precio: ${Precio} - Stock: {Stock}");
        }
    }
}
