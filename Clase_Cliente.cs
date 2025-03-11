using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5{
   
    
        public class Cliente : Usuario
        {
            public Cliente(int id, string nombre, string apellido, string correo)
                : base(id, nombre, apellido, correo) { }

            public override void MostrarDatos()
            {
                Console.WriteLine($"Cliente: {Nombre} {Apellido} - Correo: {Correo}");
            }
        }
    }

