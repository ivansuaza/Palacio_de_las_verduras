namespace PalacioVerduras.API.Models
{
    public class EmpleadoDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cargo { get; set; }
    }
}