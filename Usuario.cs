public class Usuario
{
	public int Codigo { get; set; }
	public int Codigo_Empleado { get; set; }
	public string NombreUsuario { get; set; }

	public Usuario(int codigo, int codigo_empleado, string nombreusuario)
	{
		Codigo = codigo;
		Codigo_Empleado = codigo_empleado;
		NombreUsuario = nombreusuario;
	}
    public void MostrarInformacion()
    {
		Console.WriteLine($"Codigo de ususario: {Codigo},Codigo del empleado: {Codigo_Empleado}," +
			$"Nombre del usuario: {NombreUsuario}");

    }
}
