using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
{


    // Programa Principal con Menú de Consola
    class Program
    {
        static List<Producto> productos = new List<Producto>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Empleado> empleados = new List<Empleado>();
        static List<Venta> ventas = new List<Venta>();

        static void Main()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Agregar Cliente");
                Console.WriteLine("3. Agregar Empleado");
                Console.WriteLine("4. Mostrar Inventario");
                Console.WriteLine("5. Mostrar Clientes");
                Console.WriteLine("6. Mostrar Empleados");
                Console.WriteLine("7. Realizar Venta");
                Console.WriteLine("8. Mostrar Ventas");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion <= 0 || opcion > 9) { 
                
                    Console.WriteLine("\nOpción Inválida\n");
                    Console.WriteLine("Presione ENTER para volver al menú y digitar una opción válida");
                    Console.ReadLine();
                }

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        AgregarCliente();
                        break;
                    case 3:
                        AgregarEmpleado();
                        break;
                    case 4:
                        MostrarProductos();
                        break;
                    case 5:
                        MostrarClientes();
                        break;
                    case 6:
                        MostrarEmpleados();
                        break;
                    case 7:
                        RealizarVenta();
                        break;
                    case 8:
                        MostrarVentas();
                        break;
                }
            } while (opcion != 9);

        }

        static void AgregarProducto()
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

        static void AgregarCliente()
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

        static void AgregarEmpleado()
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

        static void RealizarVenta()
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

            List<Producto> productosVendidos = new List<Producto>();
            decimal totalVenta = 0;

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
                totalVenta += productoSeleccionado.Precio * cantidad;
                productosVendidos.Add(productoSeleccionado);

                Console.WriteLine($" ✅ {cantidad} unidades de {productoSeleccionado.Nombre} añadidas a la venta.");
            }

            ventas.Add(new Venta(ventas.Count + 1, clientes[idCliente], empleados[idEmpleado], productosVendidos, totalVenta));

            Console.WriteLine("\n ✅ Venta registrada exitosamente.");
        }


        static void MostrarProductos()
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
        static void MostrarClientes()
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

        static void MostrarEmpleados()
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


        static void MostrarVentas()
        {
            foreach (var venta in ventas)
            {
                venta.MostrarVenta();
            }
        }
    }

}