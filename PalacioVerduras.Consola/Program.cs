using System;

namespace Palacio_de_las_verduras
{
    class Program
    {
        static void Main()
        {
            var metodos = new Metodos();

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

                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion <= 0 || opcion > 9)
                {
                    Console.WriteLine("\nOpción Inválida\n");
                    Console.WriteLine("Presione ENTER para volver al menú...");
                    Console.ReadLine();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        metodos.AgregarProducto();
                        break;
                    case 2:
                        metodos.AgregarCliente();
                        break;
                    case 3:
                        metodos.AgregarEmpleado();
                        break;
                    case 4:
                        metodos.MostrarProductos();
                        break;
                    case 5:
                        metodos.MostrarClientes();
                        break;
                    case 6:
                        metodos.MostrarEmpleados();
                        break;
                    case 7:
                        metodos.RealizarVenta();
                        break;
                    case 8:
                        metodos.MostrarVentas();
                        break;
                }
            } while (opcion != 9);
        }
    }
}