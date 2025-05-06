using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto() { }

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