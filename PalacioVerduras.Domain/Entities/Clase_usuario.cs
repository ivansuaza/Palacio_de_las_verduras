using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_de_las_verduras
{
        public abstract class Usuario : IPersona
        {
            public int IdUsuario { get; protected set; }
            public string Nombre { get; protected set; }
            public string Apellido { get; protected set; }
            public string Correo { get; protected set; }

            public Usuario(int id, string nombre, string apellido, string correo)
            {
                IdUsuario = id;
                Nombre = nombre;
                Apellido = apellido;
                Correo = correo;
            }

            public abstract void MostrarDatos();
        }
    }
