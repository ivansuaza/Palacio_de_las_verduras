using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Empleado : Usuario
    {
        public string Cargo { get; private set; }

        public Empleado(int id, string nombre, string apellido, string correo, string cargo)
            : base(id, nombre, apellido, correo)
        {
            Cargo = cargo;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Empleado: {Nombre} {Apellido} - Cargo: {Cargo}");
        }
    }
}
