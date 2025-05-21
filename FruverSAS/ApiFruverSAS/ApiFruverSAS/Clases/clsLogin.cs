using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiFruverSAS.Clases
{
    [Table("tblUsuario")] // Vinculación con la tabla en la base de datos
    public class Usuario
    {
        [Key] // Indica que esta es la clave primaria
        public int Codigo { get; set; }

        public int Codigo_Empleado { get; set; }

        [Required] // Campo obligatorio
        [MaxLength(50)] // Limita el tamaño de la cadena
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }

        public bool Activo { get; set; }
    }
}