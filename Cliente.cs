public class Cliente
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int NroDoc { get; set; }
    public int TipoCliente { get; set; }

    public Cliente (int codigo, string nombre, string apellido, int nroDoc, int tipoCliente)
    {
        Codigo = codigo;
        Nombre = nombre;
        Apellido = apellido;
        TipoCliente = tipoCliente;
        NroDoc = nroDoc; 
        TipoCliente = tipoCliente;

    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Cliente: {Nombre} {Apellido}, Documento {NroDoc}, Tipo: {TipoCliente}" );
    }

   
}
