public class Empleado
{
	 public int Codigo { get; set; }
	 public int NroDoc { get; set; }
	 public int idEmpleado { get; set; }
	 public float Salario { get; set; }
	 public string Nombre { get; set; }
	 public string Apellido { get; set; }
	 public string FechaIngreso { get; set; }

	public Empleado(int codigo, int nroDoc, int IdEmpleado, float salario, string nombre, 
		string apellido, string fechaIngreso)
	{
		Codigo = codigo;
		NroDoc = nroDoc;
		idEmpleado = IdEmpleado;
		Salario = salario;
		Nombre = nombre;
		Apellido = apellido;
		FechaIngreso = fechaIngreso;


	}
	public void MostrarInformacion()
	{
		Console.WriteLine($"Empleado: {Nombre} {Apellido}, Documento: {NroDoc}," +
			$"Identificacion: {idEmpleado}, Fecha de ingreso: {FechaIngreso}, Salario: {Salario}  ");
	}
}
