//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiFruverSAS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDireccionEmpleado
    {
        public int Codigo { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public int idCuidad { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    
        public virtual tblCuidad tblCuidad { get; set; }
        public virtual tblEmpleado tblEmpleado { get; set; }
    }
}
