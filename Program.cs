using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
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
                Console.WriteLine("4. Realizar Venta");
                Console.WriteLine("5. Mostrar Ventas");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

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
                        RealizarVenta();
                        break;
                    case 5:
                        MostrarVentas();
                        break;
                }
            } while (opcion > 0 && opcion >  6);

            Console.WriteLine("Opcion Inválida");
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
        }

        static void RealizarVenta()
        {
            if (clientes.Count == 0 || empleados.Count == 0 || productos.Count == 0)
            {
                Console.WriteLine("Debe haber al menos un cliente, empleado y producto para realizar una venta.");
                return;
            }

            Console.Write("Seleccione Cliente (ID): ");
            int idCliente = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Seleccione Empleado (ID): ");
            int idEmpleado = int.Parse(Console.ReadLine()) - 1;

            List<Producto> productosVendidos = new List<Producto>();
            productosVendidos.Add(productos[0]); // Para simplificar, agrega el primer producto

            ventas.Add(new Venta(ventas.Count + 1, clientes[idCliente], empleados[idEmpleado], productosVendidos));
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