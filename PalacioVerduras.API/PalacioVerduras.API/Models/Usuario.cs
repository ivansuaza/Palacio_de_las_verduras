using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalacioVerduras.API.Models
{
    public abstract class Usuario : IPersona
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public Usuario() { }

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