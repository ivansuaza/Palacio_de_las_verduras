public class ClienteDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }

    public ClienteDTO() { }

    public ClienteDTO(int id, string nombre, string telefono, string correo)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Correo = correo;
    }
}
