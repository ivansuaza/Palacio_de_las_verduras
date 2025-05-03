using System;
using System.Collections.Generic;
using System.Linq;

namespace Palacio_de_las_verduras
{
    public class Metodos
    {
        // Listas de datos
        private List<Producto> productos = new List<Producto>();
        private List<Cliente> clientes = new List<Cliente>();
        private List<Empleado> empleados = new List<Empleado>();
        private List<Venta> ventas = new List<Venta>();

        // Método AgregarProducto
        public void AgregarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());
            productos.Add(new Producto(productos.Count + 1, nombre, precio, stock));
            Console.WriteLine("\nProducto Agregado Correctamente.\n");
        }

        // Método AgregarCliente
        public void AgregarCliente()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Correo: ");
            string correo = Console.ReadLine();
            clientes.Add(new Cliente(clientes.Count + 1, nombre, apellido, correo));
            Console.WriteLine("\nCliente Agregado Correctamente.\n");
        }

        // Método AgregarEmpleado
        public void AgregarEmpleado()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Correo: ");
            string correo = Console.ReadLine();
            Console.Write("Cargo: ");
            string cargo = Console.ReadLine();
            empleados.Add(new Empleado(empleados.Count + 1, nombre, apellido, correo, cargo));
            Console.WriteLine("\nEmpleado Agregado Correctamente.\n");
        }

        // Método MostrarProductos
        public void MostrarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine("\nNo hay productos registrados.");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE PRODUCTOS ---\n");
                foreach (var producto in productos)
                {
                    producto.MostrarProducto();
                }
            }
        }

        // Método MostrarClientes
        public void MostrarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("\nNo hay clientes registrados.");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE CLIENTES ---\n");
                foreach (var cliente in clientes)
                {
                    cliente.MostrarDatos();
                }
            }
        }

        // Método MostrarEmpleados
        public void MostrarEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("\nNo hay empleados registrados.");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE EMPLEADOS ---\n");
                foreach (var empleado in empleados)
                {
                    empleado.MostrarDatos();
                }
            }
        }

        // Método RealizarVenta
        public void RealizarVenta()
        {
            if (clientes.Count == 0 || empleados.Count == 0 || productos.Count == 0)
            {
                Console.WriteLine("\nERROR: Debe haber al menos un cliente, un empleado y productos disponibles para realizar una venta.");
                return;
            }

            Console.Write("\nSeleccione Cliente (ID): ");
            int idCliente = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Seleccione Empleado (ID): ");
            int idEmpleado = int.Parse(Console.ReadLine()) - 1;

            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            Console.WriteLine("\n--- Productos Disponibles ---");
            foreach (var producto in productos)
            {
                producto.MostrarProducto();
            }

            while (true)
            {
                Console.Write("\nIngrese el ID del producto que desea comprar (0 para finalizar): ");
                int idProducto = int.Parse(Console.ReadLine());

                if (idProducto == 0) break;

                Producto productoSeleccionado = productos.FirstOrDefault(p => p.IdProducto == idProducto);

                if (productoSeleccionado == null)
                {
                    Console.WriteLine("ERROR: Producto no encontrado.");
                    continue;
                }

                Console.Write($"Ingrese la cantidad de {productoSeleccionado.Nombre}: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (cantidad > productoSeleccionado.ObtenerStock())
                {
                    Console.WriteLine("ERROR: No hay suficiente stock disponible.");
                    continue;
                }

                productoSeleccionado.ReducirStock(cantidad);
                productosVendidos.Add(new ProductoVendido(productoSeleccionado, cantidad));

                Console.WriteLine($" ✅ {cantidad} unidades de {productoSeleccionado.Nombre} añadidas a la venta.");
            }

            ventas.Add(new Venta(ventas.Count + 1, clientes[idCliente], empleados[idEmpleado], productosVendidos));
            Console.WriteLine("\n ✅ Venta registrada exitosamente.");
        }


        // Método MostrarVentas
        public void MostrarVentas()
        {
            foreach (var venta in ventas)
            {
                venta.MostrarVenta();
            }
        }
    }
}