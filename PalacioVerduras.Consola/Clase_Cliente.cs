using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
{
   
        public class Cliente : Usuario
        {
            public Cliente(int id, string nombre, string apellido, string correo)
                : base(id, nombre, apellido, correo) { }

            public override void MostrarDatos()
            {
                Console.WriteLine($"ID Cliente: {IdUsuario} - Cliente: {Nombre} {Apellido} - Correo: {Correo}");
            }
        }
    }

